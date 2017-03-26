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

export const loadEvents = (date) => {
  return (dispatch, getstate) => {
    return axios.post('http://localhost:3001/api/calendar', { Date:date })
        .then(response => dispatch(eventsLoaded(transformData(response.data))))
  }
}

export const actions = {
  loadEvents
}

// ------------------------------------
// Action Handlers
// ------------------------------------

const ACTION_HANDLERS = {
  [EVENTS_LOADED] : (state, action) =>
  Object.assign({}, { 'events': getNewEvents(state.events, action.payload) })
}
function getNewEvents (currentEvents, newEvents) {
  if (currentEvents.length === 0) {
    return newEvents
  }
  if (newEvents.length === 0) {
    return currentEvents
  }
  var forAdding = newEvents.filter((item) => {
    return currentEvents.map((ev) => ev.id).indexOf(item.id) === -1
  })
  if (forAdding === null || forAdding === undefined) {
    currentEvents
  }
  return currentEvents.concat(forAdding)
}

// ------------------------------------
// Reducer
// ------------------------------------
const initialState = { events: [] }
export default function CalendarReducer (state = initialState, action) {
  const handler = ACTION_HANDLERS[action.type]
  return handler ? handler(state, action) : state
}

