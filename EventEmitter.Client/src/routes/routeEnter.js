import { fetchEvents } from '../store/eventList'
import { initState } from '../store/location'
import { startLoadEvent, startLoadMessages } from './Events/modules/event'

export const loadEvents = (store) => (nextState, replace) => {
  var state = store.getState()
  store.dispatch(fetchEvents(state.user, state.eventList))
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
