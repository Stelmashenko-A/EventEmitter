
import { shouldFetchUser, fetchUser } from '../../../store/user'
// ------------------------------------
// Constants
// ------------------------------------
export const COUNTER_INCREMENT = 'COUNTER_INCREMENT'
export const GOOGLE_LOGIN_CLICK = 'GOOGLE_LOGIN_CLICK'
export const SUCCESS_LOGIN = 'SUCCESS_LOGIN'
export const REQUEST_USER = 'REQUEST_USER'
export const RECEIVE_USER = 'RECEIVE_USER'


// ------------------------------------
// Actions
// ------------------------------------
export function increment (value = 1) {
  return {
    type: COUNTER_INCREMENT,
    payload: value
  }
}

export function googleLogin () {
  return {
    type: GOOGLE_LOGIN_CLICK
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

export const receiveUser = (user) => {
  return {
    type: RECEIVE_USER,
    payload: user
  }
}


export const actions = {
  googleLogin
}

// ------------------------------------
// Action Handlers
// ------------------------------------

const ACTION_HANDLERS = {
  [GOOGLE_LOGIN_CLICK]: (state, action) => {
    login()
    return state
  }
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

var login = function () {
  window.open('http://localhost:3001/api/Account/ExternalLogin?provider=Google&response_type=token&client_id=self&redirect_uri=http%3A%2F%2Flocalhost%3A3001%2F&', 'Authenticate Account', 'location=0,status=0,width=600,height=750')
}

