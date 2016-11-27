import fetch from 'isomorphic-fetch'
// ------------------------------------
// Constants
// ------------------------------------

export const EVENT_LOADING_START = 'EVENT_LOADING_START'
export const EVENT_LOADED = 'EVENT_LOADED'
export const GO = 'GO'
export const REGISTER_START = 'REGISTER_START'
export const REGISTER_SUCCESS = 'REGISTER_SUCCESS'
// ------------------------------------
// Actions
// ------------------------------------
export function loadingStart () {
  return {
    type: EVENT_LOADING_START
  }
}

export function eventLoaded (event) {
  return {
    type: EVENT_LOADED,
    payload:event
  }
}

export const startLoadEvent = (id) => {
  return (dispatch, getstate) => {
    dispatch(loadingStart())
    var fetchInit = { method: 'GET',
               cache: 'default',
               headers: {
                 'Authorization': 'Bearer ' + getstate().user.access_token,
                 'Accept': 'application/json',
                 'Content-Type': 'application/json'
               } }
    return fetch(`http://localhost:3001/api/Event?id=` + id, fetchInit)
      .then(response => response.json())
      .then(json => {
        dispatch(eventLoaded(json))
      })
  }
}
export function registerStart (id) {
  return {
    type: REGISTER_START,
    payload: id
  }
}

export function registerSuccess (id) {
  return {
    type: REGISTER_SUCCESS,
    payload: id
  }
}



export function register () {
  return (dispatch, getstate) => {
    return dispatch(registerRequest(getstate().event.Id))
  }
}
export const registerRequest = (id) => {
  return (dispatch, getstate) => {
    dispatch(registerStart(id))
    console.log(id)
    var fetchInit = { method: 'POST',
               cache: 'default',
               headers: {
                 'Authorization': 'Bearer ' + getstate().user.access_token,
                 'Accept': 'application/json',
                 'Content-Type': 'application/json'
               } }
    return fetch(`http://localhost:3001/api/Registration/Register?id=` + id, fetchInit)
      .then(response => response.json())
      .then(json => {
        dispatch(eventLoaded(json))
      })
  }
}

export const actions = {
  startLoadEvent,
  register
}

// ------------------------------------
// Action Handlers
// ------------------------------------

const ACTION_HANDLERS = {
  [EVENT_LOADED]: (state, action) => {
    return Object.assign({}, state, action.payload)
  }
}

// ------------------------------------
// Reducer
// ------------------------------------
const initialState = 0
export default function loginReducer (state = initialState, action) {
  const handler = ACTION_HANDLERS[action.type]

  return handler ? handler(state, action) : state
}

