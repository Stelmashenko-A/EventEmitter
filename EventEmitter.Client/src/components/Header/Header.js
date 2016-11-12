import React from 'react'
import { IndexLink, Link } from 'react-router'
import './Header.scss'

export const Header = (props) => (
  <div className='header'>
    <div className='navbar-header' >
      <div className='logo'>Event Emitter</div>
      <button type='button' className='navbar-toggle' onClick={props.switchMobileMenu}>
        <span className='icon-bar' />
        <span className='icon-bar' />
        <span className='icon-bar' />
      </button>
    </div>
    <div className={'navbar-collapse ' + (props.header ? 'show-mobile' : 'hidden-mobile')} >
      <ul className='navbar-nav'>
        <li>Events</li>
        <li className={(!props.user.login ? '' : 'hidden')}>
          <Link to='/login' activeClassName='route--active'>Login</Link>
        </li>
        <li className={(props.user.login ? '' : 'hidden')}>
          <Link to='/newEvent' activeClassName='route--active'>New Event</Link>
        </li>
        <li>Support</li>
        <li>About us</li>
      </ul>
    </div>
  </div>
  // <IndexLink to='/' activeClassName='route--active'>
  // Home
  // </IndexLink>

)
Header.propTypes = {
  switchMobileMenu: React.PropTypes.func.isRequired,
  header: React.PropTypes.bool.isRequired,
  user: React.PropTypes.object
}

export default Header
