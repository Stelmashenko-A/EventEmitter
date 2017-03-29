import axios from 'axios'
// ------------------------------------
// Constants
// ------------------------------------
export const BLACK_LIST_LOADED = 'BLACK_LIST_LOADED'
export const REASON_CHANGED = 'REASON_CHANGED'
export const USER_ADDED = 'USER_ADDED'
export const SET_EVENT_ID = 'SET_EVENT_ID'
export const USERS_LOADED = 'USERS_LOADED'
export const USER_CHANGED = 'USER_CHANGED'
export const SELECTED_CHANGED = 'SELECTED_CHANGED'
export const USERS_REMOVED = 'USERS_REMOVED'
// ------------------------------------
// Actions
// ------------------------------------
export function blackListLoaded (events) {
  return {
    type: BLACK_LIST_LOADED,
    payload:events
  }
}

export function setEventId (eventId) {
  return {
    type: SET_EVENT_ID,
    payload:eventId
  }
}

export function reasonChanged (e) {
  return {
    type: REASON_CHANGED,
    payload: e.target.value
  }
}

export function userAdded (id) {
  return {
    type: USER_ADDED,
    payload: id
  }
}

export function usersLoaded (users) {
  return {
    type: USERS_LOADED,
    payload: users
  }
}

export function userChanged (user) {
  return {
    type: USER_CHANGED,
    payload: user
  }
}

export function selectedChanged (user) {
  return {
    type: SELECTED_CHANGED,
    payload: user
  }
}

export function usersRemoved (users) {
  return {
    type: USERS_REMOVED,
    payload: users
  }
}


export const loadBlackList = (eventId) => {
  return (dispatch, getstate) => {
    return axios.get('http://localhost:3001/api/event/blacklist?eventId=' + eventId)
        .then(response => dispatch(blackListLoaded(response.data)))
  }
}

export const addToBlackList = () => {
  return (dispatch, getstate) => {
    var bl = getstate().BlackList
    console.log(bl)
    return axios.post('http://localhost:3001/api/event/blacklist',
     { user:bl.user.id, reason:bl.reason, eventId: bl.eventId })
        .then(response => dispatch(userAdded()))
  }
}

export const loadUsers = () => {
  return (dispatch, getstate) => {
    var bl = getstate().BlackList
    return axios.get('http://localhost:3001/api/user/part?name=' + bl.forAdding)
        .then(response => dispatch(usersLoaded(response.data)))
  }
}

export const deleteUsers = () => {
  return (dispatch, getstate) => {
    var blackList = getstate().BlackList.blackList
    var selected = getstate().BlackList.selected
    var eventId = getstate().BlackList.eventId

    var forRemoving = []
    selected.forEach((item) => { forRemoving.push(blackList[item].userId) })
    console.log(forRemoving)
    return axios({
      method: 'delete',
      url: 'http://localhost:3001/api/event/blacklist',
      data: { event: eventId, users: forRemoving } })
      .then(response => dispatch(usersRemoved(forRemoving)))
  }
}

export const actions = {
  loadBlackList,
  blackListLoaded,
  reasonChanged,
  userAdded,
  addToBlackList,
  setEventId,
  userChanged,
  deleteUsers
}

// ------------------------------------
// Action Handlers
// ------------------------------------

const ACTION_HANDLERS = {
  [BLACK_LIST_LOADED] : (state, action) =>
  Object.assign({}, state,
   { 'blackList': action.payload.records },
   { 'name':action.payload.name },
   { 'start':action.payload.start }),

  [REASON_CHANGED] : (state, action) => Object.assign({}, state, { 'reason':action.payload }),
  [USER_ADDED] : (state, action) => Object.assign({}, state,
   { 'user': {}, 'reason':'', blackList:getNewBlackList(state.blackList, state.user, action.payload, state.reason) }),
  [SET_EVENT_ID] : (state, action) => Object.assign({}, state, { 'eventId': action.payload }),
  [USERS_LOADED] : (state, action) => Object.assign({}, state, { 'users': setIndexes(action.payload) }),
  [USER_CHANGED] : (state, action) => Object.assign({}, state, { 'user': action.payload }),
  [SELECTED_CHANGED] : (state, action) => Object.assign({}, state, { 'selected': action.payload }),

  [USERS_REMOVED] : (state, action) =>
    Object.assign({}, state, { 'blackList': removeUsers(state.blackList, action.payload) })
}

function getNewBlackList (blackList, user, id, reason) {
  var result = blackList.slice()
  var now = new Date()
  var day = now.getDate()
  var monthIndex = now.getMonth()
  var year = now.getFullYear()
  var hours = now.getHours()
  var minutes = now.getMinutes()
  var seconds = now.getSeconds()
  var formatedDate = year + '-' + monthIndex + '-' + day + 'T' + hours + ':' + minutes + ':' + seconds
  result.push({ id: id, desc: reason, user:user.name, userId:user.id, added: formatedDate })
  return result
}

function removeUsers (blackList, users) {
  console.log(blackList)
  console.log(users)
  var x = blackList.filter((user) => {
    return users.indexOf(user.userId) === -1
  })
  console.log(x)
  return blackList.filter((user) => {
    return users.indexOf(user.userId) === -1
  })
}

function setIndexes (users) {
  users.forEach(function (element, index) {
    element.index = index
  })
  return users
}

// ------------------------------------
// Reducer
// ------------------------------------
const initialState = {
  blackList: [],
  name: '',
  start: '',
  reason: '',
  eventId: '',
  users: [],
  user: {},
  selected: {}
}
export default function BlackListReducer (state = initialState, action) {
  const handler = ACTION_HANDLERS[action.type]
  return handler ? handler(state, action) : state
}

