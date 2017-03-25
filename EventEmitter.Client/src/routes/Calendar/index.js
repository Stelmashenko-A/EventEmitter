import { injectReducer } from '../../store/reducers'
import { loadCalendarOnEnter } from '../routeEnter'
export default (store) => ({
  path: 'calendar',
  onEnter : loadCalendarOnEnter(store),
  /*  Async getComponent is only invoked when route matches   */
  getComponent (nextState, cb) {
    /*  Webpack - use 'require.ensure' to create a split point
        and embed an async module loader (jsonp) when bundling   */
    require.ensure([], (require) => {
      /*  Webpack - use require callback to define
          dependencies for bundling   */
      const Calendar = require('./containers/CalendarContainer').default
      const reducer = require('./modules/Calendar').default

      /*  Add the reducer to the store on key 'counter'  */
      injectReducer(store, { key: 'Calendar', reducer })

      /*  Return getComponent   */
      cb(null, Calendar)

      /* Webpack named bundle   */
    }, 'Calendar')
  }
})
