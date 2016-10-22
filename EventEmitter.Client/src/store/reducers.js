import { combineReducers } from 'redux'
import locationReducer from './location'
import headerReducer from './header'

export const makeRootReducer = (asyncReducers) => {
  return combineReducers({
    location: locationReducer,
    header: headerReducer,
    ...asyncReducers
  })
}

export const injectReducer = (store, { key, reducer }) => {
  store.asyncReducers[key] = reducer
  store.replaceReducer(makeRootReducer(store.asyncReducers))
}

export default makeRootReducer
