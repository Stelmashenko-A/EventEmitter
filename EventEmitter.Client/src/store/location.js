// ------------------------------------
// Constants
// ------------------------------------
export const LOCATION_CHANGE = 'LOCATION_CHANGE'
export const INIT_STATE = 'INIT_STATE'

// ------------------------------------
// Actions
// ------------------------------------
export function locationChange (location = '/') {
  return {
    type    : LOCATION_CHANGE,
    payload : location
  }
}
export function initState () {
  return {
    type    : INIT_STATE
  }
}
// ------------------------------------
// Specialized Action Creator
// ------------------------------------
export const updateLocation = ({ dispatch }) => {
  return (nextLocation) => dispatch(locationChange(nextLocation))
}

// ------------------------------------
// Reducer
// ------------------------------------
const initialState = null
export default function locationReducer (state = initialState, action) {
  return action.type === LOCATION_CHANGE
    ? action.payload
    : state
}
