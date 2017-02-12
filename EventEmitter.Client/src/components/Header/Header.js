import React from 'react'
import { Link } from 'react-router'
import './Header.scss'
import { Header, Navigation } from 'react-mdl'
export const EHeader = (props) => (
  <Header title={<span><Link to='/'>Event Emitter</Link></span>}>
    <Navigation>
      <Link
        className={(!props.user.login ? '' : 'hidden')}
        to='/login'
        activeClassName='route--active'>Login</Link>

      <Link
        className={(props.user.login ? '' : 'hidden')}
        to='/newEvent'
        activeClassName='route--active'>New Event</Link>

      <li>Support</li>
      <li>Support</li>
    </Navigation>
  </Header>
)

EHeader.propTypes = {
  switchMobileMenu: React.PropTypes.func.isRequired,
  header: React.PropTypes.bool.isRequired,
  user: React.PropTypes.object
}

export default EHeader
