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
    console.log(getstate().user)
    var fetchInit = { method: 'GET',
               mode: 'cors',
               cache: 'default',
               headers: {
                 'Authorization': 'Bearer ' + getstate().user.access_token
               } }
    return fetch(`http://localhost:3001/api/Event?page=3`, fetchInit)
      .then(response => response.json())
      .then(json => {
        console.log(json)
        dispatch(initEvents(json))
      })
  }
}

export function fetchEvents () {

}
export const actions = {
  initEvents,
  loading,
  successLoading
}

// ------------------------------------
// Action Handlers
// ------------------------------------
var newState = { 'events': [
    { 'owner':'John Smith',
    'start':'11:11:11 10.10.1900',
     'duration':'10 minutes',
     'price':'0',
     'description':'isrhgyrgurbtgyurbgtubrgy',
     'slots':'123'
     },
     { 'owner':'Qwer Smith',
    'start':'12:12:12 10.10.1900',
     'duration':'10 minutes',
     'price':'0',
     'description':'isrhgyrgurbtgyurbgtubrgy',
     'slots':'123'
     },
     { 'owner':'asf asdfsadf',
    'start':'10:10:10 10.10.1900',
     'duration':'10 minutes',
     'price':'0',
     'description':'isrhgyrgurbtgyurbgtubrgy',
     'slots':'123'
     }] }

const ACTION_HANDLERS = {
  [INIT_EVENTS] : (state, action) => action.payload
}


// ------------------------------------
// Reducer
// ------------------------------------
const initialState = { 'events': [] }

export default function eventListReducer (state = initialState, action) {
  const handler = ACTION_HANDLERS[action.type]

  return handler ? handler(state, action) : state
}

