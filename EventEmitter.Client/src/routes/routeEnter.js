import { loading } from '../store/eventList'
export const loadEvents = (store) => (nextState, replace) => {
  store.dispatch(loading())
}
