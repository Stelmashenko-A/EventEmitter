// ------------------------------------
// Constants
// ------------------------------------
export const INIT_EVENTS = 'INIT_EVENTS'
export const LOAD_EVENTS = 'LOAD_EVENTS'
export const LOADING_START = 'LOADING_START'
export const SUCCESS_LOADING = 'SUCCESS_LOADING'
export const FAILED_LOADING = 'FAILED_LOADING'

// ------------------------------------
// Actions
// ------------------------------------
export function initEvents (newState) {
  return {
    type    : INIT_EVENTS,
    payload: newState
  }
}

export const loadEvents = () => {
  return {
    type:LOAD_EVENTS
  }
}

export const loadingStart = () => {
  return {
    type:LOADING_START
  }
}

export const successLoading = () => {
  return {
    type:SUCCESS_LOADING
  }
}
export const loading = () => {
  return (dispatch, getstate) => {
    dispatch(loadingStart())
    var fetchInit = { method: 'GET',
               cache: 'default',
               headers: {
                 'Authorization': 'Bearer ' + getstate().user.access_token
               } }
    return fetch(`http://localhost:3001/api/Event?page=` + getstate().eventList.page, fetchInit)
      .then(response => response.json())
      .then(json => {
        dispatch(initEvents(json))
      })
  }
}

export function fetchEvents (user, eventList) {
  return function (dispatch) {
    console.log(eventList)
    dispatch(loadingStart())
    var fetchInit = { method: 'GET',
      cache: 'default',
      headers: {
        'Authorization': 'Bearer ' + user.access_token
      }
    }
    return fetch(`http://localhost:3001/api/Event?page=` + eventList.page, fetchInit)
      .then(response => response.json())
      .then(json => {
        
        dispatch(initEvents(json))
      })
  }
}
export const actions = {
  initEvents,
  loading,
  fetchEvents,
  successLoading
}

// ------------------------------------
// Action Handlers
// ------------------------------------

const ACTION_HANDLERS = {
  [INIT_EVENTS] : (state, action) => Object.assign({}, { 'events':state.events.concat(action.payload.events) }, { 'page':state.page + 1 })
}


// ------------------------------------
// Reducer
// ------------------------------------
const initialState = {
  'events': [],
  'page':1
}

export default function eventListReducer (state = initialState, action) {
  const handler = ACTION_HANDLERS[action.type]

  return handler ? handler(state, action) : state
}

