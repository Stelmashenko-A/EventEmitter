import { injectReducer } from '../../store/reducers'
export default (store) => ({
  path: 'newEvent',
  /*  Async getComponent is only invoked when route matches   */
  getComponent (nextState, cb) {
    /*  Webpack - use 'require.ensure' to create a split point
        and embed an async module loader (jsonp) when bundling   */
    require.ensure([], (require) => {
      /*  Webpack - use require callback to define
          dependencies for bundling   */
      const NewEvent = require('./containers/NewEventContainer').default
      const reducer = require('./modules/newEvent').default

      /*  Add the reducer to the store on key 'counter'  */
      injectReducer(store, { key: 'newEvent', reducer })

      /*  Return getComponent   */
      cb(null, NewEvent)

      /* Webpack named bundle   */
    }, 'newEvent')
  }
})
