import axios from 'axios'
// ------------------------------------
// Constants
// ------------------------------------
export const BLACK_LIST_LOADED = 'BLACK_LIST_LOADED'
export const FOR_ADDING_CHANGED = 'FOR_ADDING_CHANGED'
export const REASON_CHANGED = 'REASON_CHANGED'
export const USER_ADDED = 'USER_ADDED'
export const SET_EVENT_ID = 'SET_EVENT_ID'
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

export function forAddingChanged (e) {
  return {
    type: FOR_ADDING_CHANGED,
    payload: e.target.value
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
     { user:bl.forAdding, reason:bl.reason, eventId: bl.eventId })
        .then(response => dispatch(userAdded()))
  }
}

export const actions = {
  loadBlackList,
  blackListLoaded,
  forAddingChanged,
  reasonChanged,
  userAdded,
  addToBlackList,
  setEventId
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

  [FOR_ADDING_CHANGED] : (state, action) => Object.assign({}, state, { 'forAdding':action.payload }),
  [REASON_CHANGED] : (state, action) => Object.assign({}, state, { 'reason':action.payload }),
  [USER_ADDED] : (state, action) => Object.assign({}, state, { 'forAdding':'', 'reason':'' }),
  [SET_EVENT_ID] : (state, action) => Object.assign({}, state, { 'eventId': action.payload })
}


// ------------------------------------
// Reducer
// ------------------------------------
const initialState = {
  blackList: [],
  name: '',
  start: '',
  forAdding: '',
  reason: '',
  eventId: ''
}
export default function BlackListReducer (state = initialState, action) {
  const handler = ACTION_HANDLERS[action.type]
  return handler ? handler(state, action) : state
}

