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

/*  This is a thunk, meaning it is a function that immediately
    returns a function for lazy evaluation. It is incredibly useful for
    creating async actions, especially when combined with redux-thunk!

    NOTE: This is solely for demonstration purposes. In a real application,
    you'd probably want to dispatch an action of COUNTER_DOUBLE and let the
    reducer take care of this logic.  */

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
