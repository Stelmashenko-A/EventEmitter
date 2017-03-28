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

export function userAdded () {
  return {
    type: USER_ADDED
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

export const loadUsers = (qw) => {
  return (dispatch, getstate) => {
    var bl = getstate().BlackList
    return axios.get('http://localhost:3001/api/user/part?name=' + bl.forAdding)
        .then(response => dispatch(usersLoaded(response.data)))
  }
}

export const actions = {
  loadBlackList,
  blackListLoaded,
  reasonChanged,
  userAdded,
  addToBlackList,
  setEventId,
  userChanged
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
  [USER_ADDED] : (state, action) => Object.assign({}, state, { 'user': {}, 'reason':'' }),
  [SET_EVENT_ID] : (state, action) => Object.assign({}, state, { 'eventId': action.payload }),
  [USERS_LOADED] : (state, action) => Object.assign({}, state, { 'users': setIndexes(action.payload) }),
  [USER_CHANGED] : (state, action) => Object.assign({}, state, { 'user': action.payload })

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
  user: {}
}
export default function BlackListReducer (state = initialState, action) {
  const handler = ACTION_HANDLERS[action.type]
  return handler ? handler(state, action) : state
}

