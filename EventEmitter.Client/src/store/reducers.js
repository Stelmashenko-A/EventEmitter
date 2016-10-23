import { combineReducers } from 'redux'
import locationReducer from './location'
import headerReducer from './header'
import userReducer from './user'

export const makeRootReducer = (asyncReducers) => {
  return combineReducers({
    location: locationReducer,
    header: headerReducer,
    user: userReducer,
    ...asyncReducers
  })
}

export const injectReducer = (store, { key, reducer }) => {
  store.asyncReducers[key] = reducer
  store.replaceReducer(makeRootReducer(store.asyncReducers))
}

export default makeRootReducer
