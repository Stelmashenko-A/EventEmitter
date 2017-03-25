import axios from 'axios'
// ------------------------------------
// Constants
// ------------------------------------
export const EVENTS_LOADED = 'EVENTS_LOADED'
// ------------------------------------
// Actions
// ------------------------------------
export function eventsLoaded (events) {
  return {
    type: EVENTS_LOADED,
    payload:events
  }
}

function transformData (arr) {
  return arr.map(function (event) {
    event.start = new Date(event.start)
    event.end = new Date(event.end)
    return event
  })
}

export const loadEvents = (start, end) => {
  return (dispatch, getstate) => {
    return axios.post('http://localhost:3001/api/calendar', { Start:start, End:end })
        .then(response => dispatch(eventsLoaded(transformData(response.data))))
  }
}
export const actions = {

}

// ------------------------------------
// Action Handlers
// ------------------------------------

const ACTION_HANDLERS = {
  [EVENTS_LOADED] : (state, action) =>
  Object.assign({}, { 'events':state.events.concat(action.payload) })
}

// ------------------------------------
// Reducer
// ------------------------------------
const initialState = { events: [] }
export default function CalendarReducer (state = initialState, action) {
  const handler = ACTION_HANDLERS[action.type]
  return handler ? handler(state, action) : state
}

