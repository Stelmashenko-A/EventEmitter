import { fetchEvents, initEvents } from '../store/eventList'
import { initState } from '../store/location'
import { startLoadEvent, startLoadMessages } from './Event/modules/event'
import { fetchUsers, fetchUserTypes } from './AdministrateUsers/modules/AdministrateUsers'
import { fetchUserTypesStat, fetchClaims } from './AdministrateRoles/modules/AdministrateRoles'
import { fetchRegistrations } from './Registrations/modules/Registrations'
function _loadEvents (store, nextState) {
  var state = store.getState()
  var code = nextState.location.query.cat !== undefined ? nextState.location.query.cat : ''

  store.dispatch(initEvents(code))
  store.dispatch(fetchEvents(state.user, 1, code))
}

export const loadEventsOnEnter = (store) => (nextState, replace) => {
  _loadEvents(store, nextState)
}

export const loadEventsOnChange = (store) => (prevState, nextState, replace) => {
  _loadEvents(store, nextState)
}

export const loadEvent = (store) => (nextState, replace) => {
  console.log(nextState)
  store.dispatch(startLoadEvent(nextState.params.userId))
  store.dispatch(startLoadMessages(nextState.params.userId))
}

export const adminUsersOnEnter = (store) => (nextState, replace) => {
  var state = store.getState()
  store.dispatch(fetchUsers(state.user, 1))
  store.dispatch(fetchUserTypes(state.user))
}

export const adminRolesOnEnter = (store) => (nextState, replace) => {
  var state = store.getState()
  store.dispatch(fetchUserTypesStat(state.user))
  store.dispatch(fetchClaims(state.user))
}

export const registrationsOnEnter = (store) => (nextState, replace) => {
  store.dispatch(fetchRegistrations())
}

export const InitState = (store) => (nextState, replace) => {
  console.log(nextState)
  store.dispatch(initState())
}
