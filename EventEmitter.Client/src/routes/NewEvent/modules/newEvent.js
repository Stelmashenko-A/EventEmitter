
// ------------------------------------
// Constants
// ------------------------------------

export const DESCRIPCION_CHANGED = 'DESCRIPCION_CHANGED'
export const DURATION_CHANGED = 'DURATION_CHANGED'
export const SLOTS_CHANGED = 'SLOTS_CHANGED'
export const SUBMITED = 'SUBMITED'

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

export const actions = {
  descriptionChanged,
  durationChanged,
  slotsChanged
}

// ------------------------------------
// Action Handlers
// ------------------------------------

const ACTION_HANDLERS = {
  [DESCRIPCION_CHANGED]: (state, action) => {
    return Object.assign(state, { Description : action.payload })
  },

  [DURATION_CHANGED]: (state, action) => {
    console.log(state)
    return Object.assign(state, { Duration : action.payload })
  },

  [SLOTS_CHANGED]: (state, action) => {
    return Object.assign(state, { Slots : action.payload })
  }
}

// ------------------------------------
// Reducer
// ------------------------------------
const initialState = {
  Description: '12345'
}
export default function loginReducer (state = initialState, action) {
  const handler = ACTION_HANDLERS[action.type]

  return handler ? handler(state, action) : state
}

