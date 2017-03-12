import axios from 'axios'

// ------------------------------------
// Constants
// ------------------------------------

export const ADD_REGISTRATIONS = 'ADD_REGISTRATIONS'

// ------------------------------------
// Actions
// ------------------------------------

export const addRegistrations = (registrations) => {
  return {
    type: ADD_REGISTRATIONS,
    payload: registrations
  }
}

export function fetchRegistrations (page) {
  return function (dispatch) {
    return axios.get('http://localhost:3001/api/registration')
    .then(response => dispatch(addRegistrations(response.data)))
  }
}


export const actions = {
  fetchRegistrations
}

// ------------------------------------
// Action Handlers
// ------------------------------------

const ACTION_HANDLERS = {
  [ADD_REGISTRATIONS]: (state, action) =>
    Object.assign({},
     state, { 'registrations': state.registrations.concat(action.payload) }, { 'page': state.page + 1 })
}

// ------------------------------------
// Reducer
// ------------------------------------
const initialState = {
  registrations: [],
  page: 1
}

export default function administrateUsersReducer (state = initialState, action) {
  const handler = ACTION_HANDLERS[action.type]

  return handler ? handler(state, action) : state
}

