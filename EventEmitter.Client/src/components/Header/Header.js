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
      <Link
        className={(props.user.login ? '' : 'hidden')}
        to='/calendar'
        activeClassName='route--active'>New Event</Link>
      <Link
        className={(props.user.login ? '' : 'hidden')}
        to='/admin/users'
        activeClassName='route--active'>Administrate System</Link>
      <li className={(props.user.login ? '' : 'hidden')} onClick={props.logout}>Log Out</li>
    </Navigation>
  </Header>
)

EHeader.propTypes = {
  switchMobileMenu: React.PropTypes.func.isRequired,
  header: React.PropTypes.bool.isRequired,
  user: React.PropTypes.object,
  logout: React.PropTypes.func.isRequired
}

export default EHeader
