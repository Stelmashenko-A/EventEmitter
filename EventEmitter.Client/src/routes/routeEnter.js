import { fetchEvents, initEvents } from '../store/eventList'
import { initState } from '../store/location'
import { startLoadEvent, startLoadMessages } from './Event/modules/event'

function _loadEvents (store, nextState) {
  var state = store.getState()
 console.log("load")
  var code = nextState.location.query.cat !== undefined ? nextState.location.query.cat : ''

  store.dispatch(initEvents(code))
  store.dispatch(fetchEvents(state.user, 1, code))
}

export const loadEventsOnEnter = (store) => (nextState, replace) => {
  console.log("enter")
  _loadEvents(store, nextState)
}

export const loadEventsOnChange = (store) => (prevState, nextState, replace) => {
    console.log("change")
  _loadEvents(store, nextState)
}

export const loadEvent = (store) => (nextState, replace) => {
  console.log(nextState)
  store.dispatch(startLoadEvent(nextState.params.userId))
  store.dispatch(startLoadMessages(nextState.params.userId))
}

export const InitState = (store) => (nextState, replace) => {
  console.log(nextState)
  store.dispatch(initState())
}
