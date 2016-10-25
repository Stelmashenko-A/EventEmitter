import fetch from 'isomorphic-fetch'
// ------------------------------------
// Constants
// ------------------------------------
export const COUNTER_INCREMENT = 'COUNTER_INCREMENT'
export const GOOGLE_LOGIN_CLICK = 'GOOGLE_LOGIN_CLICK'
export const SUCCESS_LOGIN = 'SUCCESS_LOGIN'

export const REQUEST_LOGIN = 'REQUEST_LOGIN'
function requestLogin (login) {
  return {
    type: REQUEST_LOGIN,
    login
  }
}

export const successLogin = (event) => {
  return {
    type: SUCCESS_LOGIN,
    payload: event.data
  }
}
// ------------------------------------
// Actions
// ------------------------------------
export function increment(value = 1) {
  return {
    type: COUNTER_INCREMENT,
    payload: value
  }
}

export function googleLogin() {
  return {
    type: GOOGLE_LOGIN_CLICK
  }
}

/*  This is a thunk, meaning it is a function that immediately
    returns a function for lazy evaluation. It is incredibly useful for
    creating async actions, especially when combined with redux-thunk!

    NOTE: This is solely for demonstration purposes. In a real application,
    you'd probably want to dispatch an action of COUNTER_DOUBLE and let the
    reducer take care of this logic.  */

export const doubleAsync = () => {
  return (dispatch, getState) => {
    return new Promise((resolve) => {
      setTimeout(() => {
        dispatch(increment(getState().counter))
        resolve()
      }, 200)
    })
  }
}

export const actions = {
  googleLogin
}

// ------------------------------------
// Action Handlers
// ------------------------------------

const successLoginHandler = (state, action) => {
  console.log(state)
  console.log(action)
  return state
}

const ACTION_HANDLERS = {
  [GOOGLE_LOGIN_CLICK]: (state, action) => {
    login()
    return state
  },
  [SUCCESS_LOGIN]: successLoginHandler
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

export function fetchPosts(login) {
  // Thunk middleware knows how to handle functions.
  // It passes the dispatch method as an argument to the function,
  // thus making it able to dispatch actions itself.

  return function (dispatch) {
    // First dispatch: the app state is updated to inform
    // that the API call is starting.

    dispatch(requestLogin(login))

    // The function called by the thunk middleware can return a value,
    // that is passed on as the return value of the dispatch method.

    // In this case, we return a promise to wait for.
    // This is not required by thunk middleware, but it is convenient for us.

    return fetch(`http://www.reddit.com/r/${subreddit}.json`)
      .then(response => response.json())
      .then(json =>

        // We can dispatch many times!
        // Here, we update the app state with the results of the API call.

        dispatch(receivePosts(subreddit, json))
      )

    // In a real world app, you also want to
    // catch any error in the network call.
  }
}