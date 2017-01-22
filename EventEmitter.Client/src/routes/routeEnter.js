import { loading } from '../store/eventList'
import { initState } from '../store/location'
import { startLoadEvent, startLoadMessages } from './Events/modules/event'

export const loadEvents = (store) => (nextState, replace) => {
  store.dispatch(loading())
}

export const loadEvent = (store) => (nextState, replace) => {
  store.dispatch(startLoadEvent(nextState.params.userId))
  store.dispatch(startLoadMessages(nextState.params.userId))
}

export const InitState = (store) => (nextState, replace) => {
  store.dispatch(initState())
}
