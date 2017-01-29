import fetch from 'isomorphic-fetch'

// ------------------------------------
// Constants
// ------------------------------------

export const FETCH_STATRT = 'FETCH_STATRT'
export const FETCH_SUCCESS = 'FETCH_SUCCESS'

// ------------------------------------
// Actions
// ------------------------------------

export function fetchStart () {
  return {
    type: FETCH_STATRT
  }
}

export function fetchSuccess (categories) {
  return {
    type: FETCH_SUCCESS,
    payload: categories
  }
}

export const actions = {
  fetchStart,
  fetchSuccess
}

// ------------------------------------
// Action Handlers
// ------------------------------------

const ACTION_HANDLERS = {
  [FETCH_SUCCESS]:(state, action) => {
    return Object.assign({}, state, Array.from(action.payload))
  }
}

// ------------------------------------
// Reducer
// ------------------------------------

const initialState = []

export default function categoryReducer (state = initialState, action) {
  const handler = ACTION_HANDLERS[action.type]

  return handler ? handler(state, action) : state
}

// ------------------------------------
// Functions
// ------------------------------------

export function fetchCategories () {
  return function (dispatch) {
    dispatch(fetchStart())
    var fetchInit = { method: 'GET',
      cache: 'default'
    }
    fetch(`http://localhost:3001/api/category`, fetchInit)
      .then(response => response.json())
      .then(json => {
        dispatch(fetchSuccess(json))
      })
  }
}
