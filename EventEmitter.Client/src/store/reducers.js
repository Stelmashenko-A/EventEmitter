import { combineReducers } from 'redux'
import locationReducer from './location'
import headerReducer from './header'
import userReducer from './user'
import categoryReducer from './../modules/Categories'
import eventListReducer from './eventList'

export const makeRootReducer = (asyncReducers) => {
  return combineReducers({
    location: locationReducer,
    header: headerReducer,
    user: userReducer,
    eventList: eventListReducer,
    categories: categoryReducer,
    ...asyncReducers
  })
}

export const injectReducer = (store, { key, reducer }) => {
  store.asyncReducers[key] = reducer
  store.replaceReducer(makeRootReducer(store.asyncReducers))
}

export default makeRootReducer
