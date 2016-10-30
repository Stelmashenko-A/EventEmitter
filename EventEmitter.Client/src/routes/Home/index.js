/*import HomeView from './components/HomeView'

// Sync route definition
export default {
  component : HomeView
}*/
import { initEvents } from '../../store/eventList'
//import { injectReducer } from '../../store/reducers'
//import { successLogin } from './modules/login.js'
export default (store) => ({
  /*  Async getComponent is only invoked when route matches   */
  getComponent (nextState, cb) {
    /*  Webpack - use 'require.ensure' to create a split point
        and embed an async module loader (jsonp) when bundling   */
    store.dispatch(initEvents())
    require.ensure([], (require) => {
      /*  Webpack - use require callback to define
          dependencies for bundling   */
      const Home = require('./containers/HomeContainer').default
      //const reducer = require('./modules/login').default

      /*  Add the reducer to the store on key 'counter'  */
     // injectReducer(store, { key: 'login', reducer })

      /*  Return getComponent   */
      cb(null, Home)


      /* Webpack named bundle   */
    }, '/')

        
  }
})
