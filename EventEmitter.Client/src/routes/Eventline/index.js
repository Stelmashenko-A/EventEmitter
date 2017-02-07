import { injectReducer } from '../../store/reducers'
import { loadEventsOnEnter, loadEventsOnChange } from '../routeEnter'
export default (store) => ({
  path: 'eventline',
  onEnter : loadEventsOnEnter(store),
  onChange: loadEventsOnChange(store),
  /*  Async getComponent is only invoked when route matches   */
  getComponent (nextState, cb) {
    /*  Webpack - use 'require.ensure' to create a split point
        and embed an async module loader (jsonp) when bundling   */
    require.ensure([], (require) => {
      /*  Webpack - use require callback to define
          dependencies for bundling   */
      const Eventline = require('./containers/EventlineContainer').default
      const reducer = require('./modules/eventline').default

      /*  Add the reducer to the store on key 'counter'  */
      injectReducer(store, { key: 'eventline', reducer })

      /*  Return getComponent   */
      cb(null, Eventline)

      /* Webpack named bundle   */
    }, 'eventline')
  }
})

