import fetch from 'isomorphic-fetch'
// ------------------------------------
// Constants
// ------------------------------------

export const EVENT_LOADING_START = 'EVENT_LOADING_START'
export const EVENT_LOADED = 'EVENT_LOADED'
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
    return fetch(`http://localhost:3001/api/Event?id=A46918BB-139B-4A97-A3CF-0C94A7D42312`, fetchInit)
      .then(response => response.json())
      .then(json => {
        console.log(json)
        dispatch(eventLoaded(json))
      })
  }
}
export const actions = {
  startLoadEvent
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

