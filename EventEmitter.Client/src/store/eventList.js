// ------------------------------------
// Constants
// ------------------------------------



// ------------------------------------
// Actions
// ------------------------------------

export const actions = {
}

// ------------------------------------
// Action Handlers
// ------------------------------------
const ACTION_HANDLERS = {
}


// ------------------------------------
// Reducer
// ------------------------------------
const initialState = { 'events': [
    { 'owner':'John Smith',
    'start':'11:11:11 10.10.1900',
     'duration':'10 minutes',
     'price':'0',
     'descripion':'isrhgyrgurbtgyurbgtubrgy',
     'slots':'123'
     },
     { 'owner':'Qwer Smith',
    'start':'12:12:12 10.10.1900',
     'duration':'10 minutes',
     'price':'0',
     'descripion':'isrhgyrgurbtgyurbgtubrgy',
     'slots':'123'
     },
     { 'owner':'asf asdfsadf',
    'start':'10:10:10 10.10.1900',
     'duration':'10 minutes',
     'price':'0',
     'descripion':'isrhgyrgurbtgyurbgtubrgy',
     'slots':'123'
     }] }
    
export default function eventListReducer (state = initialState, action) {
  const handler = ACTION_HANDLERS[action.type]

  return handler ? handler(state, action) : state
}

