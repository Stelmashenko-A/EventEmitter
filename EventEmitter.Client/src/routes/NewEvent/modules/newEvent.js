
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

export const actions = {
  descriptionChanged
}

// ------------------------------------
// Action Handlers
// ------------------------------------

const ACTION_HANDLERS = {
  [DESCRIPCION_CHANGED]: (state, action) => {
    console.log(action.payload)
    return { Description : action.payload }
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

