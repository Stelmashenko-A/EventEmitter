import moment from 'moment'
import fetch from 'isomorphic-fetch'
// ------------------------------------
// Constants
// ------------------------------------
export const NAME_CHANGED = 'NAME_CHANGED'
export const DESCRIPCION_CHANGED = 'DESCRIPCION_CHANGED'
export const DURATION_CHANGED = 'DURATION_CHANGED'
export const CATEGORY_CHANGED = 'CATEGORY_CHANGED'
export const SLOTS_CHANGED = 'SLOTS_CHANGED'
export const START_CHANGED = 'START_CHANGED'
export const IMG_CHANGED = 'IMG_CHANGED'
export const BLOCKED_CHANGED = 'BLOCKED_CHANGED'
export const IMG_CONVERTED = 'IMG_CONVERTED'
export const SUBMITED = 'SUBMITED'
export const ADDED = 'ADDED'
export const TOAST_CLOSED = 'TOAST_CLOSED'

// ------------------------------------
// Actions
// ------------------------------------
export function nameChanged (e) {
  return {
    type: NAME_CHANGED,
    payload: e.target.value
  }
}

export function descriptionChanged (e) {
  return {
    type: DESCRIPCION_CHANGED,
    payload: e.target.value
  }
}

export function durationChanged (e) {
  return {
    type: DURATION_CHANGED,
    payload: e.target.value
  }
}

export function slotsChanged (e) {
  return {
    type: SLOTS_CHANGED,
    payload: e.target.value
  }
}
export function startChanged (date) {
  return {
    type: START_CHANGED,
    payload: date
  }
}

export function imgChanged (img) {
  return {
    type: IMG_CHANGED,
    payload: img[0]
  }
}

export function blockedChanged (img) {
  return {
    type: BLOCKED_CHANGED
  }
}

export function categoryChanged (category) {
  return {
    type: CATEGORY_CHANGED,
    payload: category
  }
}

export function submit (date) {
  return (dispatch, getstate) => {
    return dispatch(createEvent(getstate().newEvent))
  }
}

export function imgConverted (text) {
  return (dispatch, getstate) => {
    return dispatch(sendEvent(getstate().user, getstate().newEvent, text))
  }
}

export function added () {
  return {
    type: ADDED
  }
}

export function toastClosed () {
  return {
    type: TOAST_CLOSED
  }
}

export const actions = {
  nameChanged,
  descriptionChanged,
  durationChanged,
  categoryChanged,
  slotsChanged,
  startChanged,
  imgChanged,
  blockedChanged,
  submit,
  toastClosed,
  added
}

// ------------------------------------
// Action Handlers
// ------------------------------------

const ACTION_HANDLERS = {
  [NAME_CHANGED]: (state, action) => {
    return Object.assign({}, state, { Name: action.payload, Saved: false })
  },

  [DESCRIPCION_CHANGED]: (state, action) => {
    return Object.assign({}, state, { Description: action.payload, Saved: false })
  },

  [DURATION_CHANGED]: (state, action) => {
    return Object.assign({}, state, { Duration: parseInt(action.payload), Saved: false })
  },

  [SLOTS_CHANGED]: (state, action) => {
    return Object.assign({}, state, { Slots: parseInt(action.payload), Saved: false })
  },

  [START_CHANGED]: (state, action) => {
    return Object.assign({}, state, { Start: Object.assign(action.payload), Saved: false })
  },

  [IMG_CHANGED]: (state, action) => {
    return Object.assign({}, state, { Image: Object.assign(action.payload), Saved: false })
  },

  [BLOCKED_CHANGED]: (state, action) => {
    return Object.assign({}, state, { Blocked: !state.Blocked, Saved: false })
  },

  [CATEGORY_CHANGED]: (state, action) => {
    return Object.assign({}, state, { Category: Object.assign(action.payload), Saved: false })
  },

  [ADDED]:(state, action) => {
    return Object.assign({}, initialState, { Saved: true })
  },

  [TOAST_CLOSED]:(state, action) => {
    return Object.assign({}, state, { Saved: false })
  }
}

// ------------------------------------
// Reducer
// ------------------------------------
const initialState = {
  Name: '',
  Description: '',
  Start: moment(),
  Slots: 1,
  Duration: 1,
  Category: '',
  Image: {},
  Blocked: false,
  Saved: false
}
export default function loginReducer (state = initialState, action) {
  const handler = ACTION_HANDLERS[action.type]

  return handler ? handler(state, action) : state
}

export function createEvent (newEvent) {
  return dispatch => {
    // dispatch(requestUser(login))
    var reader = new FileReader()

    reader.onload = function (readerEvt) {
      var binaryString = readerEvt.target.result
      var base64 = 'data:image;base64,' + btoa(binaryString)
      dispatch(imgConverted(base64))
    }

    reader.readAsBinaryString(newEvent.Image)
  }
}

export function sendEvent (login, newEvent, text) {
  return dispatch => {
    var fetchInit = {
      body: JSON.stringify(Object.assign({}, newEvent, { Image : text })),
      method: 'POST',
      cache: 'default',
      headers: {
        'Authorization': 'Bearer ' + login.access_token,
        'Accept': 'application/json',
        'Content-Type': 'application/json'
      }
    }
    return fetch(`http://localhost:3001/api/Event`, fetchInit)
      .then(response => {
        if (response.status === 204) {
          dispatch(added())
        }
      })
  }
}
