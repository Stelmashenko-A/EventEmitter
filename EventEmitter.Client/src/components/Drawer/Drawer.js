import React from 'react'
import { Link } from 'react-router'
import { Navigation, Drawer } from 'react-mdl'
export const EDrawer = (props) => (
  <Drawer title='Title'>
    <Navigation>
      <Link
        to='/'
        activeClassName='route--active'>Home</Link>
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
  </Drawer>
  // <IndexLink to='/' activeClassName='route--active'>
  // Home
  // </IndexLink>


)
EDrawer.propTypes = {
  switchMobileMenu: React.PropTypes.func.isRequired,
  header: React.PropTypes.bool.isRequired,
  user: React.PropTypes.object
}

export default EDrawer
