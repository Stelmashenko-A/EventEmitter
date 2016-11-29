import fetch from 'isomorphic-fetch'
// ------------------------------------
// Constants
// ------------------------------------

export const EVENT_LOADING_START = 'EVENT_LOADING_START'
export const EVENT_LOADED = 'EVENT_LOADED'
export const GO = 'GO'
export const REGISTER_START = 'REGISTER_START'
export const REGISTER_SUCCESS = 'REGISTER_SUCCESS'

export const INTERESTED = 'INTERESTED'
export const INTERESTED_START = 'INTERESTED_START'
export const INTERESTED_SUCCESS = 'INTERESTED_SUCCESS'

export const DISMISS = 'DISMISS'
export const DISMISS_START = 'DISMISS_START'
export const DISMISS_SUCCESS = 'DISMISS_SUCCESS'
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
export function registerStart () {
  return {
    type: REGISTER_START
  }
}

export function registerSuccess () {
  return {
    type: REGISTER_SUCCESS
  }
}

export function interestedStart () {
  return {
    type: INTERESTED_START
  }
}

export function interestedSuccess () {
  return {
    type: INTERESTED_SUCCESS
  }
}


export function dismissStart () {
  return {
    type: DISMISS_START
  }
}

export function dismissSuccess () {
  return {
    type: DISMISS_SUCCESS
  }
}

export function register () {
  return (dispatch, getstate) => {
    return dispatch(registerRequest(getstate().event.Id))
  }
}

export function interested () {
  return (dispatch, getstate) => {
    return dispatch(interestedRequest(getstate().event.Id))
  }
}

export function dismiss () {
  return (dispatch, getstate) => {
    return dispatch(dismissRequest(getstate().event.Id))
  }
}

export const registerRequest = (id) => {
  return (dispatch, getstate) => {
    dispatch(registerStart(id))
    var fetchInit = { method: 'POST',
               cache: 'default',
               headers: {
                 'Authorization': 'Bearer ' + getstate().user.access_token,
                 'Accept': 'application/json',
                 'Content-Type': 'application/json'
               } }
    return fetch(`http://localhost:3001/api/Registration/Register?id=` + id, fetchInit)
      .then(response => {
        if (response.status === 200) {
          dispatch(registerSuccess())
        }
      })
  }
}

export const interestedRequest = (id) => {
  return (dispatch, getstate) => {
    dispatch(interestedStart(id))
    var fetchInit = { method: 'POST',
               cache: 'default',
               headers: {
                 'Authorization': 'Bearer ' + getstate().user.access_token,
                 'Accept': 'application/json',
                 'Content-Type': 'application/json'
               } }
    return fetch(`http://localhost:3001/api/Registration/Interested?id=` + id, fetchInit)
      .then(response => {
        if (response.status === 200) {
          dispatch(interestedSuccess())
        }
      })
  }
}

export const dismissRequest = (id) => {
  return (dispatch, getstate) => {
    dispatch(dismissStart(id))
    var fetchInit = { method: 'POST',
               cache: 'default',
               headers: {
                 'Authorization': 'Bearer ' + getstate().user.access_token,
                 'Accept': 'application/json',
                 'Content-Type': 'application/json'
               } }
    return fetch(`http://localhost:3001/api/Registration/Dismiss?id=` + id, fetchInit)
      .then(response => {
        console.log(response.status)
        if (response.status === 200) {

          dispatch(dismissSuccess())
        }
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
  },

  [REGISTER_SUCCESS]: (state, action) => {
    console.log(REGISTER_SUCCESS)
    return Object.assign({}, state, { Type:2 })
  },

  [INTERESTED_SUCCESS]: (state, action) => {
    console.log(INTERESTED_SUCCESS)
    return Object.assign({}, state, { Type:1 })
  },

  [DISMISS_SUCCESS]: (state, action) => {
              console.log(DISMISS_SUCCESS)
    return Object.assign({}, state, { Type:0 })
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

