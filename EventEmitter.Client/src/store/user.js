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

export const receiveUser = (user) => {
  return {
    type: RECEIVE_USER,
    payload: user
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
  window.open('http://localhost:18292/api/Account/ExternalLogin?provider=Google&response_type=token&client_id=self&redirect_uri=http%3A%2F%2Flocalhost%3A18292%2F&', 'Authenticate Account', 'location=0,status=0,width=600,height=750')
  function receiveMessage (event) {
    console.log(event)
    // Do we trust the sender of this message?  (might be
    // different from what we originally opened, for example).
    // alert(event.data["access_token"]);
    /*if (event.origin !== "http://example.org")
        return;*/

    /*$.ajax({
      type: "Get",
      headers: {
        'Authorization': 'Bearer ' + event.data["access_token"]
      },
      url: "http://localhost:18292/api/Account/UserInfo",
      dataType: "json",
      success: function (data) {
        $.ajax({
          type: "GET",
          headers: {
            'Authorization': 'Bearer ' + event.data["access_token"]
          },
          url: "http://localhost:18292/api/Account/UserInfo",
          dataType: "json",
          data: {
            Email: "qwe"
          },
          success: function (data) {
            alert('Success');

          },
          error: function () {
            alert('Error 2S');
          }
        });

      },
      error: function () {
        alert('Error');
      }
    });*/

    // event.source is popup
    // event.data is "hi there yourself!  the secret response is: rheeeeet!"
  }
}

export function fetchUser (login) {
  return dispatch => {
    dispatch(requestUser(login))
    console.log(login)
    var fetchInit = { method: 'GET',
               mode: 'cors',
               cache: 'default',
               headers: {
                 'Authorization': 'Bearer ' + login.access_token
               } }
    return fetch(`http://localhost:18292/api/Account/UserInfo`, fetchInit)
      .then(response => response.json())
      .then(json => dispatch(receiveUser(login, json)))
  }
}

export function shouldFetchUser (state, subreddit) {
  return true
}
