// ------------------------------------
// Constants
// ------------------------------------
export const INIT_EVENTS = 'INIT_EVENTS'
export const ADD_EVENTS = 'ADD_EVENTS'
export const LOAD_EVENTS = 'LOAD_EVENTS'
export const LOADING_START = 'LOADING_START'
export const SUCCESS_LOADING = 'SUCCESS_LOADING'
export const FAILED_LOADING = 'FAILED_LOADING'

// ------------------------------------
// Actions
// ------------------------------------
export const initEvents = (categoryCode) => {
  return {
    type    : INIT_EVENTS,
    payload: categoryCode
  }
}

export function addEvents (newState) {
  return {
    type    : ADD_EVENTS,
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
    var state = getstate()
    var fetchInit = { method: 'GET',
      cache: 'default',
      headers: {
        'Authorization': 'Bearer ' + state.user.access_token
      }
    }
    var url = `http://localhost:3001/api/Event?page=` + state.eventList.page
    if (state.eventList.categoryCode !== '') {
      url = url + '&category' + state.eventList.categoryCode
    }
    console.log(url)
    return fetch(url, fetchInit)
      .then(response => response.json())
      .then(json => {
        dispatch(addEvents(json))
      })
  }
}

export function fetchEvents (user, page, categoryCode) {
  return function (dispatch) {
    dispatch(loadingStart())
    var fetchInit = { method: 'GET',
      cache: 'default',
      headers: {
        'Authorization': 'Bearer ' + user.access_token
      }
    }
    var url = `http://localhost:3001/api/Event?page=` + page
    if (categoryCode !== '' && categoryCode !== undefined) {
      url = url + '&category' + categoryCode
    }
    console.log(url)
    return fetch(url, fetchInit)
      .then(response => response.json())
      .then(json => {
        console.log(json)
        dispatch(addEvents(json))
      })
  }
}
export const actions = {
  addEvents,
  loading,
  fetchEvents,
  successLoading
}

// ------------------------------------
// Action Handlers
// ------------------------------------

const ACTION_HANDLERS = {
  [ADD_EVENTS] : (state, action) =>
  Object.assign({}, { 'events':state.events.concat(action.payload.events) }, { 'page':state.page + 1 }),

  [INIT_EVENTS] : (state, action) =>
  Object.assign({}, { 'events':[] }, { 'page':1, 'category': action.payload })

}


// ------------------------------------
// Reducer
// ------------------------------------
const initialState = {
  'events': [],
  'page':1,
  'category':''
}

export default function eventListReducer (state = initialState, action) {
  const handler = ACTION_HANDLERS[action.type]

  return handler ? handler(state, action) : state
}

