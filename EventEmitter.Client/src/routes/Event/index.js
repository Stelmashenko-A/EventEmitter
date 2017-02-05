import { injectReducer } from '../../store/reducers'
import { loadEvent } from '../routeEnter'
export default (store) => ({
  path: 'event/:userId',
  onEnter : loadEvent(store),
  /*  Async getComponent is only invoked when route matches   */
  getComponent (nextState, cb) {
    /*  Webpack - use 'require.ensure' to create a split point
        and embed an async module loader (jsonp) when bundling   */
    require.ensure([], (require) => {
      /*  Webpack - use require callback to define
          dependencies for bundling   */
      const Event = require('./containers/EventContainer').default
      const reducer = require('./modules/event').default

      /*  Add the reducer to the store on key 'counter'  */
      injectReducer(store, { key: 'event', reducer })

      /*  Return getComponent   */
      cb(null, Event)

      /* Webpack named bundle   */
    }, 'event')
  }
})
