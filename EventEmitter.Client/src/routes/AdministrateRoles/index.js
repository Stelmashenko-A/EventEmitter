import { injectReducer } from '../../store/reducers'
import { adminRolesOnEnter } from '../routeEnter'
export default (store) => ({
  path: 'admin/roles',
  onEnter : adminRolesOnEnter(store),
  /*  Async getComponent is only invoked when route matches   */
  getComponent (nextState, cb) {
    /*  Webpack - use 'require.ensure' to create a split point
        and embed an async module loader (jsonp) when bundling   */
    require.ensure([], (require) => {
      /*  Webpack - use require callback to define
          dependencies for bundling   */
      const AdminstrateRoles = require('./containers/AdminstrateRolesContainer').default
      const reducer = require('./modules/AdministrateRoles').default
      /*  Add the reducer to the store on key 'counter'  */
      injectReducer(store, { key: 'administrateRoles', reducer })
      /*  Return getComponent   */
      cb(null, AdminstrateRoles)

      /* Webpack named bundle   */
    }, 'administrateRoles')
  }
})
