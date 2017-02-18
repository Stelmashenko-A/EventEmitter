import { injectReducer } from '../../store/reducers'
import { adminUsersOnEnter } from '../routeEnter'
export default (store) => ({
  path: 'admin/users',
  onEnter : adminUsersOnEnter(store),
  /*  Async getComponent is only invoked when route matches   */
  getComponent (nextState, cb) {
    /*  Webpack - use 'require.ensure' to create a split point
        and embed an async module loader (jsonp) when bundling   */
    require.ensure([], (require) => {
      /*  Webpack - use require callback to define
          dependencies for bundling   */
      const AdminstrateUsers = require('./containers/AdminstrateUsersContainer').default
      const reducer = require('./modules/AdministrateUsers').default

      /*  Add the reducer to the store on key 'counter'  */
      injectReducer(store, { key: 'administrateUsers', reducer })

      /*  Return getComponent   */
      cb(null, AdminstrateUsers)

      /* Webpack named bundle   */
    }, 'administrateUsers')
  }
})

