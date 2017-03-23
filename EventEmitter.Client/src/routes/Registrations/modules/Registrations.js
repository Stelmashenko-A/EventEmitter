import axios from 'axios'

// ------------------------------------
// Constants
// ------------------------------------

export const ADD_REGISTRATIONS = 'ADD_REGISTRATIONS'
export const NEXT = 'NEXT'
export const PAST = 'PAST'
export const GO = 'GO'
export const INTERESTED = 'INTERESTED'

// ------------------------------------
// Actions
// ------------------------------------

export const addRegistrations = (registrations) => {
  return {
    type: ADD_REGISTRATIONS,
    payload: registrations
  }
}

export const next = () => {
  return {
    type: NEXT
  }
}

export const past = () => {
  return {
    type: PAST
  }
}

export const go = () => {
  return {
    type: GO
  }
}

export const interested = () => {
  return {
    type: INTERESTED
  }
}

export function fetchRegistrations () {
  return function (dispatch, getstate) {
    var state = getstate().registrations
    var query = ''
    if (state !== undefined) {
      if (state.go && !state.interested) {
        query += '&OnlyGo=true'
      }
      if (!state.go && state.interested) {
        query += '&OnlyInterested=true'
      }
      if (state.next && !state.past) {
        query += '&OnlyNext=true'
      }
      if (!state.next && state.past) {
        query += '&OnlyPast=true'
      }
    }
    return axios.get('http://localhost:3001/api/registration?' + query.substr(1))
    .then(response => dispatch(addRegistrations(response.data)))
  }
}


export const actions = {
  fetchRegistrations,
  next,
  past,
  go,
  interested
}

// ------------------------------------
// Action Handlers
// ------------------------------------

const ACTION_HANDLERS = {
  [ADD_REGISTRATIONS]: (state, action) =>
    Object.assign({},
     state, { 'registrations': action.payload }, { 'page': state.page + 1 }),

  [NEXT]: (state, action) => Object.assign({}, state, { 'next': !state.next }),
  [PAST]: (state, action) => Object.assign({}, state, { 'past': !state.past }),
  [GO]: (state, action) => Object.assign({}, state, { 'go': !state.go }),
  [INTERESTED]: (state, action) => Object.assign({}, state, { 'interested': !state.interested })
}

// ------------------------------------
// Reducer
// ------------------------------------
const initialState = {
  next: true,
  past: true,
  go: true,
  interested: true,
  registrations: [],
  page: 1
}

export default function registrationsReducer (state = initialState, action) {
  const handler = ACTION_HANDLERS[action.type]

  return handler ? handler(state, action) : state
}

