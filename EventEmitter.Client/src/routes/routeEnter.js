import { loading } from '../store/eventList'
import { initState } from '../store/location'

export const loadEvents = (store) => (nextState, replace) => {
  store.dispatch(loading())
}

export const InitState = (store) => (nextState, replace) => {
  store.dispatch(initState())
}
