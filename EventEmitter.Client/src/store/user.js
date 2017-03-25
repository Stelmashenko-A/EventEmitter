import fetch from 'isomorphic-fetch'
import { browserHistory } from 'react-router'
import axios from 'axios'
// ------------------------------------
// Constants
// ------------------------------------

export const SUCCESS_LOGIN = 'SUCCESS_LOGIN'
export const REQUEST_USER = 'REQUEST_USER'
export const RECEIVE_USER = 'RECEIVE_USER'
export const REQUEST_LOGIN = 'REQUEST_LOGIN'

// ------------------------------------
// Actions
// ------------------------------------

export const successLogin = (event) => {
  return (dispatch) => {
    if (shouldFetchUser(event.data)) {
      return dispatch(fetchUser(event.data))
    }
  }
}

export const requestUser = () => {
  return {
    type: REQUEST_USER
  }
}

export const receiveUser = (login, user) => {
  return {
    type: RECEIVE_USER,
    login,
    user
  }
}

/*  This is a thunk, meaning it is a function that immediately
    returns a function for lazy evaluation. It is incredibly useful for
    creating async actions, especially when combined with redux-thunk!

    NOTE: This is solely for demonstration purposes. In a real application,
    you'd probably want to dispatch an action of COUNTER_DOUBLE and let the
    reducer take care of this logic.  */

export const actions = {
}

// ------------------------------------
// Action Handlers
// ------------------------------------

const ACTION_HANDLERS = {
  [RECEIVE_USER] : (state, action) => receiveUserHandler(state, action)
}
function receiveUserHandler (state, action) {
  var newState = Object.assign({ login: true }, action.user, action.login)
  newState.Expired = new Date()
  newState.Expired.setSeconds(newState.Expired.getSeconds() + Number(newState.expires_in))
  localStorage.setItem('user', JSON.stringify(newState))
  return newState
}
// ------------------------------------
// Reducer
// ------------------------------------
function getInitialSate () {
  var storedUser = JSON.parse(localStorage.getItem('user'))
  storedUser.Expired = new Date(storedUser.Expired)
  if (storedUser !== null && new Date() < storedUser.Expired) {
    axios.defaults.headers.common['Authorization'] = 'Bearer ' + storedUser.access_token
    return storedUser
  }
  return { login: false }
}
const initialState = getInitialSate()
export default function loginReducer (state = initialState, action) {
  const handler = ACTION_HANDLERS[action.type]
  return handler ? handler(state, action) : state
}

window.callparent = function (obj) {
  alert(obj)
}

export function fetchUser (login) {
  return dispatch => {
    dispatch(requestUser(login))
    var fetchInit = { method: 'GET',
               cache: 'default',
               headers: {
                 'Authorization': 'Bearer ' + login.access_token
               } }
    return fetch(`http://localhost:3001/api/Account/UserInfo`, fetchInit)
      .then(response => response.json())
      .then(json => {
        dispatch(receiveUser(login, json))
        browserHistory.push('/')
      })
  }
}

export function shouldFetchUser (state, subreddit) {
  return true
}
