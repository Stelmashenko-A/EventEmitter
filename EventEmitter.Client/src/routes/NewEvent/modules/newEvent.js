import moment from 'moment'
// ------------------------------------
// Constants
// ------------------------------------

export const DESCRIPCION_CHANGED = 'DESCRIPCION_CHANGED'
export const DURATION_CHANGED = 'DURATION_CHANGED'
export const SLOTS_CHANGED = 'SLOTS_CHANGED'
export const SUBMITED = 'SUBMITED'
export const START_CHANGED = 'START_CHANGED'

// ------------------------------------
// Actions
// ------------------------------------
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
export function startChanged (date,t,d) {
  console.log(t)
    console.log(d)
  return {
    type: START_CHANGED,
    payload: date
  }
}


export const actions = {
  descriptionChanged,
  durationChanged,
  slotsChanged,
  startChanged
}

// ------------------------------------
// Action Handlers
// ------------------------------------

const ACTION_HANDLERS = {
  [DESCRIPCION_CHANGED]: (state, action) => {
    return Object.assign({}, state, { Description : action.payload })
  },

  [DURATION_CHANGED]: (state, action) => {
    return Object.assign({}, state, { Duration : action.payload })
  },

  [SLOTS_CHANGED]: (state, action) => {
    return Object.assign({}, state, { Slots : action.payload })
  },

  [START_CHANGED]: (state, action) => {
    return Object.assign({}, state, { Start : Object.assign(action.payload) })
  }
}

// ------------------------------------
// Reducer
// ------------------------------------
const initialState = {
  Description: '12345',
  Start: moment()
}
export default function loginReducer (state = initialState, action) {
  const handler = ACTION_HANDLERS[action.type]

  return handler ? handler(state, action) : state
}

