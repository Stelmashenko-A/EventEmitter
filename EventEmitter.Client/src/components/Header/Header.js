import React from 'react'
import { IndexLink, Link } from 'react-router'
import './Header.scss'

export const Header = (props) => (
  <div className='header'>
    <div className='container'>
      <nav className='navbar'>
        <div className='navbar-header' >
          <div className='logo'>Event Emitter</div>
          <button type='button' className='navbar-toggle' onClick={props.switchMobileMenu}>
            <span className='icon-bar' />
            <span className='icon-bar' />
            <span className='icon-bar' />
          </button>
        </div>
        <div className='navbar-collapse'>
          <ul className='navbar-nav'>
            <li>Link1</li>
            <li>Link2</li>
            <li>Link3</li>
          </ul>
        </div>
      </nav>
    </div>

    <h1>React Redux Starter Kit</h1>
    <IndexLink to='/' activeClassName='route--active'>
      Home
    </IndexLink>
    {' · '}
    <Link to='/counter' activeClassName='route--active'>
      Counter
    </Link>
  </div>
    // <IndexLink to='/' activeClassName='route--active'>
      // Home
    // </IndexLink>

)
Header.propTypes = {
  switchMobileMenu : React.PropTypes.func.isRequired
}

export default Header
