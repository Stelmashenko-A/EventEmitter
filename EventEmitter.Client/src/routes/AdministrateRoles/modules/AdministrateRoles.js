// ------------------------------------
// Constants
// ------------------------------------
export const SET_USER_TYPES = 'SET_USER_TYPES'
export const SET_CLAIMS = 'SET_CLAIMS'
export const SET_GRANTED_CLAIMS = 'SET_GRANTED_CLAIMS'
export const SELECTED_CHANGED = 'SELECTED_CHANGED'
// ------------------------------------
// Actions
// ------------------------------------

export const setUserTypes = (userTypes) => {
  return {
    type: SET_USER_TYPES,
    payload: userTypes
  }
}

export const setClaims = (claims) => {
  return {
    type: SET_CLAIMS,
    payload: claims
  }
}

export const setGrantedClaims = (claims) => {
  return {
    type: SET_GRANTED_CLAIMS,
    payload: claims
  }
}

export const selectedChanged = (id) => {
  return {
    type: SELECTED_CHANGED,
    payload: id
  }
}

export function fetchUserTypesStat (user) {
  return function (dispatch) {
    var fetchInit = {
      method: 'GET',
      cache: 'default',
      headers: {
        'Authorization': 'Bearer ' + user.access_token
      }
    }
    var url = `http://localhost:3001/api/UserType/Stat`
    return fetch(url, fetchInit)
      .then(response => response.json())
      .then(json => {
        dispatch(setUserTypes(json))
      })
  }
}

export function fetchClaims (user) {
  return function (dispatch) {
    var fetchInit = {
      method: 'GET',
      cache: 'default',
      headers: {
        'Authorization': 'Bearer ' + user.access_token
      }
    }
    var url = `http://localhost:3001/api/UserType/Claims`
    return fetch(url, fetchInit)
      .then(response => response.json())
      .then(json => {
        dispatch(setClaims(json))
      })
  }
}

export function fetchGrantedClaims (id) {
  return function (dispatch, getstate) {
    var fetchInit = {
      method: 'GET',
      cache: 'default',
      headers: {
        'Authorization': 'Bearer ' + getstate().user.access_token
      }
    }
    var url = `http://localhost:3001/api/UserType/GrantedClaims?id=` + id
    return fetch(url, fetchInit)
      .then(response => response.json())
      .then(json => {
        dispatch(setGrantedClaims(json))
      })
  }
}

export const actions = {
  setUserTypes,
  setClaims,
  fetchUserTypesStat,
  fetchClaims,
  selectedChanged,
  setGrantedClaims,
  fetchGrantedClaims
}

// ------------------------------------
// Action Handlers
// ------------------------------------

const ACTION_HANDLERS = {
  [SET_USER_TYPES]: (state, action) =>
    Object.assign({}, state, { 'userTypes': action.payload }),

  [SET_CLAIMS]: (state, action) =>
    Object.assign({}, state, { 'claims': action.payload }),

  [SET_GRANTED_CLAIMS]: (state, action) =>
    Object.assign({}, state, { 'grantedClaims': action.payload }),

  [SELECTED_CHANGED]: (state, action) => {
    setGrantedClaims([])
    if (action.payload !== state.selectedId) {
      fetchGrantedClaims(action.payload)
    }
    return Object.assign({}, state, { 'selectedId': action.payload === state.selectedId ? '' : action.payload })
  }
}

// ------------------------------------
// Reducer
// ------------------------------------
const initialState = {
  userTypes: [],
  selectedId: '',
  claims:[],
  grantedClaims:[]
}

export default function administrateRolesReducer (state = initialState, action) {
  const handler = ACTION_HANDLERS[action.type]

  return handler ? handler(state, action) : state
}

