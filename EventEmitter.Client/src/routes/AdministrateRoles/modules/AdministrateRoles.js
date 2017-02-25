// ------------------------------------
// Constants
// ------------------------------------
export const SET_USER_TYPES = 'SET_USER_TYPES'
export const SET_CLAIMS = 'SET_CLAIMS'
export const SET_GRANTED_CLAIMS = 'SET_GRANTED_CLAIMS'
export const SELECTED_CHANGED = 'SELECTED_CHANGED'
export const CLAIM_ADDED = 'CLAIM_ADDED'
export const CLAIM_REMOVED = 'CLAIM_REMOVED'
export const START_ADDING_USERTYPE = 'START_ADDING_USERTYPE'
export const END_ADDING_USERTYPE = 'END_ADDING_USERTYPE'
export const NAME_CHANGED = 'NAME_CHANGED'
export const ADD_USER_TYPE = 'ADD_USER_TYPE'
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
export const claimAdded = (id) => {
  return {
    type: CLAIM_ADDED,
    payload: id
  }
}

export const claimRemoved = (id) => {
  return {
    type: CLAIM_REMOVED,
    payload: id
  }
}

export const endAddingUserType = () => {
  return {
    type: END_ADDING_USERTYPE
  }
}

export const startAddingUserType = (id) => {
  return {
    type: START_ADDING_USERTYPE,
    payload: id
  }
}

export const userTypeNameChanged = (e) => {
  return {
    type: NAME_CHANGED,
    payload: e.target.value
  }
}
export const addUserType = (userType) => {
  return {
    type: ADD_USER_TYPE,
    payload: userType
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
  return function (dispatch, getstate, qwe) {
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
        console.log(json)
        dispatch(setGrantedClaims(json))
      })
  }
}

export function changeGrantedClaims (id) {
  return function (dispatch, getstate) {
    var state = getstate().administrateRoles
    var selectedId = state.selectedId
    console.log(state.grantedClaims)
    console.log(id)
    var added = state.grantedClaims.indexOf(id) === -1

    var fetchInit = {
      method: 'DELETE',
      cache: 'default',
      headers: {
        'Authorization': 'Bearer ' + getstate().user.access_token
      }
    }
    if (added) {
      fetchInit.method = 'PUT'
    }
    var url = `http://localhost:3001/api/UserType/Claim?type=` + selectedId + '&claim=' + id
    return fetch(url, fetchInit)
      .then(response => {
        if (response.status !== 200) return
        if (added) {
          dispatch(claimAdded(id))
          return
        }
        dispatch(claimRemoved(id))
      })
  }
}

export function saveNewUserType () {
  return function (dispatch, getstate) {
    var fetchInit = {
      method: 'PUT',
      cache: 'default',
      headers: {
        'Authorization': 'Bearer ' + getstate().user.access_token
      }
    }
    var url = `http://localhost:3001/api/UserType?name=` + getstate().administrateRoles.newUserType
    return fetch(url, fetchInit)
      .then(response => response.json())
      .then(json => {
        console.log(json)
        dispatch(addUserType(json))
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
  fetchGrantedClaims,
  changeGrantedClaims,
  endAddingUserType,
  startAddingUserType,
  userTypeNameChanged,
  saveNewUserType
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
  },

  [CLAIM_ADDED]: (state, action) => {
    var claims = state.grantedClaims.slice()
    claims.push(action.payload)
    return Object.assign({}, state, { 'grantedClaims': claims })
  },

  [CLAIM_REMOVED]: (state, action) => {
    var claims = state.grantedClaims.slice()
    var index = claims.indexOf(action.payload)
    if (index > -1) {
      claims.splice(index, 1)
    }
    return Object.assign({}, state, { 'grantedClaims': claims })
  },

  [START_ADDING_USERTYPE]: (state, action) =>
    Object.assign({}, state, { 'addInProgress': true }),

  [END_ADDING_USERTYPE]: (state, action) =>
    Object.assign({}, state, { 'addInProgress': false }),

  [NAME_CHANGED]: (state, action) =>
    Object.assign({}, state, { 'newUserType': action.payload }),

  [ADD_USER_TYPE]: (state, action) => {
    if (action.payload.Id === undefined) return state
    var userTypes = state.userTypes.slice()
    userTypes.push(action.payload)
    return Object.assign({}, state, { 'userTypes' : userTypes, 'newUserType' : '', 'addInProgress' : false })
  }

}

// ------------------------------------
// Reducer
// ------------------------------------
const initialState = {
  userTypes: [],
  selectedId: '',
  claims:[],
  grantedClaims:[],
  addInProgress: false,
  newUserType:''
}

export default function administrateRolesReducer (state = initialState, action) {
  const handler = ACTION_HANDLERS[action.type]

  return handler ? handler(state, action) : state
}

