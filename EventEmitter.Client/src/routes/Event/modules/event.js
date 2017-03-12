import fetch from 'isomorphic-fetch'
// ------------------------------------
// Constants
// ------------------------------------

export const EVENT_LOADING_START = 'EVENT_LOADING_START'
export const EVENT_LOADED = 'EVENT_LOADED'
export const MESSAGES_LOADED = 'MESSAGES_LOADED'
export const GO = 'GO'
export const REGISTER_START = 'REGISTER_START'
export const REGISTER_SUCCESS = 'REGISTER_SUCCESS'

export const INTERESTED = 'INTERESTED'
export const INTERESTED_START = 'INTERESTED_START'
export const INTERESTED_SUCCESS = 'INTERESTED_SUCCESS'

export const DISMISS = 'DISMISS'
export const DISMISS_START = 'DISMISS_START'
export const DISMISS_SUCCESS = 'DISMISS_SUCCESS'

export const MESSAGE_CHANGED = 'MESSAGE_CHANGED'

export const SEND_MESSAGE = 'SEND_MESSAGE'
export const SEND_MESSAGE_START = 'SEND_MESSAGE_START'
export const SEND_MESSAGE_SUCCESS = 'SEND_MESSAGE_SUCCESS'
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

export function messagesLoaded (event) {
  return {
    type: MESSAGES_LOADED,
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

export const startLoadMessages = (id) => {
  return (dispatch, getstate) => {
    var fetchInit = { method: 'GET',
      cache: 'default',
      headers: {
        'Authorization': 'Bearer ' + getstate().user.access_token,
        'Accept': 'application/json',
        'Content-Type': 'application/json'
      }
    }
    return fetch(`http://localhost:3001/api/Message?id=` + id, fetchInit)
      .then(response => response.json())
      .then(json => {
        dispatch(messagesLoaded(json))
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

export function messageChanged (e) {
  return {
    type: MESSAGE_CHANGED,
    payload: e.target.value
  }
}

export function sendMessageStart () {
  return {
    type: SEND_MESSAGE_START
  }
}

export function sendMessageSuccess (message) {
  return {
    type: SEND_MESSAGE_SUCCESS,
    payload: message
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

export function sendMessage () {
  return (dispatch, getstate) => {
    return dispatch(sendMessageRequest(getstate().event.Id, getstate().event.message))
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
      }
    }
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
      }
    }
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
      }
    }
    return fetch(`http://localhost:3001/api/Registration/Dismiss?id=` + id, fetchInit)
      .then(response => {
        console.log(response.status)
        if (response.status === 200) {
          dispatch(dismissSuccess())
        }
      })
  }
}

export const sendMessageRequest = (eventId, message) => {
  return (dispatch, getstate) => {
    dispatch(sendMessageStart())
    var data = {
      text:message,
      eventId:eventId
    }
    var fetchInit = { method: 'POST',
      cache: 'default',
      body:JSON.stringify(data),
      headers: {
        'Authorization': 'Bearer ' + getstate().user.access_token,
        'Accept': 'application/json',
        'Content-Type': 'application/json'
      }
    }
    return fetch(`http://localhost:3001/api/Message`, fetchInit)
      .then(response => {
        console.log(response.status)
        if (response.status === 200) {
          dispatch(sendMessageSuccess(message))
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

  [MESSAGES_LOADED]: (state, action) => {
    return Object.assign({}, state, { messages: action.payload })
  },

  [REGISTER_SUCCESS]: (state, action) => {
    return Object.assign({}, state, { Type:2 })
  },

  [INTERESTED_SUCCESS]: (state, action) => {
    return Object.assign({}, state, { Type:1 })
  },

  [DISMISS_SUCCESS]: (state, action) => {
    return Object.assign({}, state, { Type:0 })
  },

  [MESSAGE_CHANGED]: (state, action) => {
    return Object.assign({}, state, { message:action.payload })
  }
}

// ------------------------------------
// Reducer
// ------------------------------------
const initialState = { message:'' }
export default function loginReducer (state = initialState, action) {
  const handler = ACTION_HANDLERS[action.type]
  return handler ? handler(state, action) : state
}

