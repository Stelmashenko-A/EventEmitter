// ------------------------------------
// Constants
// ------------------------------------
export const SWITCH_MOBILE_MENU = 'SWITCH_MOBILE_MENU'

// ------------------------------------
// Actions
// ------------------------------------
export function switchMobileMenu (visible = false) {
  return {
    type    : SWITCH_MOBILE_MENU,
    payload : visible
  }
}

export const actions = {
  switchMobileMenu
}

// ------------------------------------
// Action Handlers
// ------------------------------------
const ACTION_HANDLERS = {
  [SWITCH_MOBILE_MENU] : (state, action) => !state
}

// ------------------------------------
// Reducer
// ------------------------------------
const initialState = false
export default function headerReducer (state = initialState, action) {
  const handler = ACTION_HANDLERS[action.type]

  return handler ? handler(state, action) : state
}
