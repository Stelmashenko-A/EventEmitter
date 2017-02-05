import { fetchEvents, initEvents } from '../store/eventList'
import { initState } from '../store/location'
import { startLoadEvent, startLoadMessages } from './Event/modules/event'

export const loadEvents = (store) => (nextState, replace) => {
  console.log(store)
  var state = store.getState()
  var code = nextState.params.categoryCode !== undefined ? nextState.params.categoryCode : ''
  store.dispatch(initEvents(code))
  store.dispatch(fetchEvents(state.user, 1, code))
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
