import fetch from 'isomorphic-fetch'
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

function requestLogin (login) {
  return {
    type: REQUEST_LOGIN,
    login
  }
}

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
  return Object.assign(action.user, action.login)
}
// ------------------------------------
// Reducer
// ------------------------------------
const initialState = 0
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
               mode: 'cors',
               cache: 'default',
               headers: {
                 'Authorization': 'Bearer ' + login.access_token
               } }
    return fetch(`http://localhost/EventEmitter.Api/api/Account/UserInfo`, fetchInit)
      .then(response => response.json())
      .then(json => dispatch(receiveUser(login, json)))
  }
}

export function shouldFetchUser (state, subreddit) {
  return true
}
