// We only need to import the modules necessary for initial render
import CoreLayout from '../layouts/CoreLayout'
import Home from './Home'
import CounterRoute from './Counter'
import LoginRoute from './Login'
import NewEvent from './NewEvent'
import Event from './Event'
import Eventline from './Eventline'
import AdministrateUsers from './AdministrateUsers'
import AdministrateRoles from './AdministrateRoles'
import Registrations from './Registrations'
/*  Note: Instead of using JSX, we recommend using react-router
    PlainRoute objects to build route definitions.   */

export const createRoutes = (store) => ({
  path        : '/',
  component   : CoreLayout,
  indexRoute  : Home(store),
  childRoutes : [
    CounterRoute(store),
    LoginRoute(store),
    NewEvent(store),
    Event(store),
    Eventline(store),
    AdministrateUsers(store),
    AdministrateRoles(store),
    Registrations(store)
  ]
})

export default createRoutes
