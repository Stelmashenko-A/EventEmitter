import moment from 'moment'
import fetch from 'isomorphic-fetch'
// ------------------------------------
// Constants
// ------------------------------------
export const NAME_CHANGED = 'NAME_CHANGED'
export const DESCRIPCION_CHANGED = 'DESCRIPCION_CHANGED'
export const DURATION_CHANGED = 'DURATION_CHANGED'
export const SLOTS_CHANGED = 'SLOTS_CHANGED'
export const START_CHANGED = 'START_CHANGED'

export const SUBMITED = 'SUBMITED'


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

export function submit (date) {
  return (dispatch, getstate) => {
    console.log()
    return dispatch(createEvent(getstate().user, getstate().newEvent))
  }
}

export const actions = {
  nameChanged,
  descriptionChanged,
  durationChanged,
  slotsChanged,
  startChanged,
  submit
}

// ------------------------------------
// Action Handlers
// ------------------------------------

const ACTION_HANDLERS = {
  [NAME_CHANGED]: (state, action) => {
    return Object.assign({}, state, { Name : action.payload })
  },

  [DESCRIPCION_CHANGED]: (state, action) => {
    return Object.assign({}, state, { Description : action.payload })
  },

  [DURATION_CHANGED]: (state, action) => {
    return Object.assign({}, state, { Duration : parseInt(action.payload) })
  },

  [SLOTS_CHANGED]: (state, action) => {
    return Object.assign({}, state, { Slots : parseInt(action.payload) })
  },

  [START_CHANGED]: (state, action) => {
    return Object.assign({}, state, { Start : Object.assign(action.payload) })
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
  Duration: 1
}
export default function loginReducer (state = initialState, action) {
  const handler = ACTION_HANDLERS[action.type]

  return handler ? handler(state, action) : state
}

export function createEvent (login, newEvent) {
  return dispatch => {
    // dispatch(requestUser(login))
    console.log(login)
    var fetchInit = {
      body: JSON.stringify(newEvent),
      method: 'POST',
      cache: 'default',
      headers: {
        'Authorization': 'Bearer ' + login.access_token,
        'Accept': 'application/json',
        'Content-Type': 'application/json'
      }
    }
    return fetch(`http://localhost:3001/api/Event`, fetchInit)
      .then(response => response.json())
      .then(json => {
        // dispatch(receiveUser(login, json))
        // browserHistory.push('/')
      })
  }
}

