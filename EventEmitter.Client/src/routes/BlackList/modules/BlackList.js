import axios from 'axios'
// ------------------------------------
// Constants
// ------------------------------------
export const BLACK_LIST_LOADED = 'BLACK_LIST_LOADED'
// ------------------------------------
// Actions
// ------------------------------------
export function blackListLoaded (events) {
  return {
    type: BLACK_LIST_LOADED,
    payload:events
  }
}



export const loadBlackList = (eventId) => {
  return (dispatch, getstate) => {
    return axios.get('http://localhost:3001/api/event/blacklist?eventId=' + eventId)
        .then(response => dispatch(blackListLoaded(response.data)))
  }
}

export const actions = {
  loadBlackList
}

// ------------------------------------
// Action Handlers
// ------------------------------------

const ACTION_HANDLERS = {
  [BLACK_LIST_LOADED] : (state, action) =>
  Object.assign({},
   { 'blackList': action.payload.records },
   { 'name':action.payload.name },
   { 'start':action.payload.start })
}


// ------------------------------------
// Reducer
// ------------------------------------
const initialState = {
  blackList: [],
  name:'',
  start:''
}
export default function BlackListReducer (state = initialState, action) {
  const handler = ACTION_HANDLERS[action.type]
  return handler ? handler(state, action) : state
}

