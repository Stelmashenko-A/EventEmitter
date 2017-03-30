import axios from 'axios'
// ------------------------------------
// Constants
// ------------------------------------
export const WHITE_LIST_LOADED = 'WHITE_LIST_LOADED'
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
export function whiteListLoaded (events) {
  return {
    type: WHITE_LIST_LOADED,
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

export const loadWhiteList = (eventId) => {
  return (dispatch, getstate) => {
    return axios.get('http://localhost:3001/api/event/whitelist?eventId=' + eventId)
        .then(response => dispatch(whiteListLoaded(response.data)))
  }
}

export const addToWhiteList = () => {
  return (dispatch, getstate) => {
    var bl = getstate().WhiteList
    console.log(bl)
    return axios.post('http://localhost:3001/api/event/whitelist',
     { user:bl.user.id, reason:bl.reason, eventId: bl.eventId })
        .then(response => dispatch(userAdded()))
  }
}

export const loadUsers = () => {
  return (dispatch, getstate) => {
    var bl = getstate().WhiteList
    return axios.get('http://localhost:3001/api/user/part?name=' + bl.forAdding)
        .then(response => dispatch(usersLoaded(response.data)))
  }
}

export const deleteUsers = () => {
  return (dispatch, getstate) => {
    var whiteList = getstate().WhiteList.whiteList
    var selected = getstate().WhiteList.selected
    var eventId = getstate().WhiteList.eventId

    var forRemoving = []
    selected.forEach((item) => { forRemoving.push(whiteList[item].userId) })
    return axios({
      method: 'delete',
      url: 'http://localhost:3001/api/event/whitelist',
      data: { event: eventId, users: forRemoving } })
      .then(response => dispatch(usersRemoved(forRemoving)))
  }
}

export const actions = {
  loadWhiteList,
  whiteListLoaded,
  reasonChanged,
  userAdded,
  addToWhiteList,
  setEventId,
  userChanged,
  deleteUsers
}

// ------------------------------------
// Action Handlers
// ------------------------------------

const ACTION_HANDLERS = {
  [WHITE_LIST_LOADED] : (state, action) =>
  Object.assign({}, state,
   { 'whiteList': action.payload.records },
   { 'name':action.payload.name },
   { 'start':action.payload.start }),

  [REASON_CHANGED] : (state, action) => Object.assign({}, state, { 'reason':action.payload }),
  [USER_ADDED] : (state, action) => Object.assign({}, state,
   { 'user': {}, 'reason':'', whiteList:getNewWhiteList(state.whiteList, state.user, action.payload, state.reason) }),
  [SET_EVENT_ID] : (state, action) => Object.assign({}, state, { 'eventId': action.payload }),
  [USERS_LOADED] : (state, action) => Object.assign({}, state, { 'users': setIndexes(action.payload) }),
  [USER_CHANGED] : (state, action) => Object.assign({}, state, { 'user': action.payload }),
  [SELECTED_CHANGED] : (state, action) => Object.assign({}, state, { 'selected': action.payload }),

  [USERS_REMOVED] : (state, action) =>
    Object.assign({}, state, { 'whiteList': removeUsers(state.whiteList, action.payload) })
}

function getNewWhiteList (whiteList, user, id, reason) {
  var result = whiteList.slice()
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

function removeUsers (whiteList, users) {
  var x = whiteList.filter((user) => {
    return users.indexOf(user.userId) === -1
  })
  console.log(x)
  return whiteList.filter((user) => {
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
  whiteList: [],
  name: '',
  start: '',
  reason: '',
  eventId: '',
  users: [],
  user: {},
  selected: {}
}
export default function WhiteListReducer (state = initialState, action) {
  const handler = ACTION_HANDLERS[action.type]
  return handler ? handler(state, action) : state
}

