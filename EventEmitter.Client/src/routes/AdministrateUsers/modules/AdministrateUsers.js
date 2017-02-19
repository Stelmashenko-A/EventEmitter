// ------------------------------------
// Constants
// ------------------------------------
export const LOAD_USERS = 'LOAD_USERS'
export const LOAD_USER_TYPES = 'LOAD_USER_TYPES'
export const EDIT_USER = 'EDIT_USER'
export const ADD_USERS = 'ADD_USERS'
export const SET_USER_TYPES = 'SET_USER_TYPES'
export const USER_TYPE_UPDATED = 'USER_TYPE_UPDATED'
// ------------------------------------
// Actions
// ------------------------------------

export const editUser = (user) => {
  return {
    type: EDIT_USER,
    payload: user
  }
}
export const addUsers = (users) => {
  return {
    type: ADD_USERS,
    payload: users
  }
}

export const setUserTypes = (userTypes) => {
  return {
    type: SET_USER_TYPES,
    payload: userTypes
  }
}

export const userTypeUpdated = (userTypeId, userId) => {
  return {
    type: USER_TYPE_UPDATED,
    userTypeId,
    userId
  }
}


export function fetchUsers(user, page) {
  return function (dispatch) {
    var fetchInit = {
      method: 'GET',
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

export function fetchUserTypes(user) {
  return function (dispatch) {
    var fetchInit = {
      method: 'GET',
      cache: 'default',
      headers: {
        'Authorization': 'Bearer ' + user.access_token
      }
    }
    var url = `http://localhost:3001/api/UserType`
    return fetch(url, fetchInit)
      .then(response => response.json())
      .then(json => {
        dispatch(setUserTypes(json))
      })
  }
}
export const postUserTypeChanged = (newUserTypeId, userId) => {
  return function (dispatch, getstate) {
    console.log(newUserTypeId)
    var state = getstate()
    var fetchInit = {
      method: 'POST',
      body: JSON.stringify({ UserId: userId, UserTypeId: newUserTypeId }),
      cache: 'default',
      headers: {
        'Authorization': 'Bearer ' + state.user.access_token,
        'Accept': 'application/json',
        'Content-Type': 'application/json'
      }
    }
    var url = `http://localhost:3001/api/User/ChangeUserType`
    return fetch(url, fetchInit)
      .then(function (responce) {
        if (responce.status === 200) {
          dispatch(userTypeUpdated(newUserTypeId, userId))
        }
      })
  }
}

export const actions = {
  addUsers,
  setUserTypes,
  fetchUsers,
  fetchUserTypes,
  postUserTypeChanged
}

// ------------------------------------
// Action Handlers
// ------------------------------------

const ACTION_HANDLERS = {
  [ADD_USERS]: (state, action) =>
    Object.assign({}, state, { 'users': state.users.concat(action.payload) }, { 'page': state.page + 1 }),

  [SET_USER_TYPES]: (state, action) =>
    Object.assign({}, state, { 'userTypes': state.userTypes.concat(action.payload) }),

  [USER_TYPE_UPDATED]: (state, action) => {
    return Object.assign({}, state, { 'users': updateUserType(state.users.slice(), action.userId, action.userTypeId) })
  }

}

function updateUserType (users, userId, userTypeId) {
  var user = users.filter(function (obj) {
    return obj.Id === userId
  })[0]
  user.UserTypeId = userTypeId
  return users
}

// ------------------------------------
// Reducer
// ------------------------------------
const initialState = {
  'users': [],
  'page': 1,
  'userTypes': []
}

export default function administrateUsersReducer(state = initialState, action) {
  const handler = ACTION_HANDLERS[action.type]

  return handler ? handler(state, action) : state
}

