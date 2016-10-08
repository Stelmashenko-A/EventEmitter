export default function (state, action) {
  switch (action.type) {
    case 'SWITCH_MOBILE_MENU':
      return !state
    default:
      return state
  }
}

