// We only need to import the modules necessary for initial render
import CoreLayout from '../layouts/CoreLayout'
import Home from './Home'
import CounterRoute from './Counter'
import LoginRoute from './Login'
import NewEvent from './NewEvent'
import Event from './Event'
import Category from './Category'


/*  Note: Instead of using JSX, we recommend using react-router
    PlainRoute objects to build route definitions.   */

export const createRoutes = (store, qwer) => ({
  path        : '/',
  component   : CoreLayout,
  indexRoute  : Home(store),
  childRoutes : [
    CounterRoute(store),
    LoginRoute(store),
    NewEvent(store),
    Event(store),
    Category(store)
  ]
})

export default createRoutes
