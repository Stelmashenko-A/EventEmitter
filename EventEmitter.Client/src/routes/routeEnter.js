import { initEvents } from '../store/eventList'
export const loadEvents = (store) => (nextState, replace) => {
  store.dispatch(initEvents())
}
