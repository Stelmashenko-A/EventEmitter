// ------------------------------------
// Constants
// ------------------------------------
export const INIT_EVENTS = 'INIT_EVENTS'


// ------------------------------------
// Actions
// ------------------------------------
export function initEvents () {
  return {
    type    : INIT_EVENTS
  }
}

export const actions = {
  initEvents
}

// ------------------------------------
// Action Handlers
// ------------------------------------
var newState = { 'events': [
    { 'owner':'John Smith',
    'start':'11:11:11 10.10.1900',
     'duration':'10 minutes',
     'price':'0',
     'description':'isrhgyrgurbtgyurbgtubrgy',
     'slots':'123'
     },
     { 'owner':'Qwer Smith',
    'start':'12:12:12 10.10.1900',
     'duration':'10 minutes',
     'price':'0',
     'description':'isrhgyrgurbtgyurbgtubrgy',
     'slots':'123'
     },
     { 'owner':'asf asdfsadf',
    'start':'10:10:10 10.10.1900',
     'duration':'10 minutes',
     'price':'0',
     'description':'isrhgyrgurbtgyurbgtubrgy',
     'slots':'123'
     }] }

const ACTION_HANDLERS = {
  [INIT_EVENTS] : (state, action) => newState
}


// ------------------------------------
// Reducer
// ------------------------------------
const initialState = { 'events': [] }

export default function eventListReducer (state = initialState, action) {
  const handler = ACTION_HANDLERS[action.type]

  return handler ? handler(state, action) : state
}

