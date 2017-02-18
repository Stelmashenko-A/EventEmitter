// ------------------------------------
// Constants
// ------------------------------------
export const LOAD_USERS = 'LOAD_USERS'
export const LOAD_USER_TYPES = 'LOAD_USER_TYPES'
export const EDIT_USER = 'EDIT_USER'
export const ADD_USERS = 'ADD_USERS'
export const SET_USER_TYPES = 'SET_USER_TYPES'
// ------------------------------------
// Actions
// ------------------------------------

export const editUser = (user) => {
  return {
    type   :EDIT_USER,
    payload: user
  }
}
export const addUsers = (users) => {
  return {
    type   :ADD_USERS,
    payload: users
  }
}

export const setUserTypes = (userTypes) => {
  return {
    type   :SET_USER_TYPES,
    payload: userTypes
  }
}


export function fetchUsers (user, page) {
  return function (dispatch) {
    var fetchInit = { method: 'GET',
      cache: 'default',
      headers: {
        'Authorization': 'Bearer ' + user.access_token
      }
    }
    var url = `http://localhost:3001/api/User?page=` + page
    return fetch(url, fetchInit)
      .then(response => response.json())
      .then(json => {
        console.log(json)
        dispatch(addUsers(json))
      })
  }
}

export function fetchUserTypes (user, page) {
  return function (dispatch) {
    var fetchInit = { method: 'GET',
      cache: 'default',
      headers: {
        'Authorization': 'Bearer ' + user.access_token
      }
    }
    var url = `http://localhost:3001/api/UserTypes`
    return fetch(url, fetchInit)
      .then(response => response.json())
      .then(json => {
        dispatch(setUserTypes(json))
      })
  }
}

export const actions = {
  addUsers,
  setUserTypes,
  fetchUsers,
  fetchUserTypes
}

// ------------------------------------
// Action Handlers
// ------------------------------------

const ACTION_HANDLERS = {
  [ADD_USERS] : (state, action) =>
  Object.assign({}, { 'users':state.users.concat(action.payload) }, { 'page':state.page + 1 }),

  [SET_USER_TYPES] : (state, action) =>
  Object.assign({}, { 'userTypes':state.userTypes.concat(action.payload) })

}


// ------------------------------------
// Reducer
// ------------------------------------
const initialState = {
  'users': [],
  'page':1,
  'userTypes':[]
}

export default function administrateUsersReducer (state = initialState, action) {
  const handler = ACTION_HANDLERS[action.type]

  return handler ? handler(state, action) : state
}

