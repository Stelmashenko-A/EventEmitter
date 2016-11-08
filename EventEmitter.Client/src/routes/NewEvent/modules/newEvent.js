
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
export const actions = {
}

// ------------------------------------
// Action Handlers
// ------------------------------------

const ACTION_HANDLERS = {
}

// ------------------------------------
// Reducer
// ------------------------------------
const initialState = 0
export default function loginReducer (state = initialState, action) {
  const handler = ACTION_HANDLERS[action.type]

  return handler ? handler(state, action) : state
}

