import React from 'react'
import { IndexLink, Link } from 'react-router'
import { connect } from 'react-redux'
import { switchMobileMenu } from './../../store/header'
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

/*  This is a container component. Notice it does not contain any JSX,
    nor does it import React. This component is **only** responsible for
    wiring in the actions and state necessary to render a presentational
    component - in this case, the counter:   */


/*  Object of action creators (can also be function that returns object).
    Keys will be passed as props to presentational components. Here we are
    implementing our wrapper around increment; the component doesn't care   */

const mapDispatchToProps = {
  switchMobileMenu
}

const mapStateToProps = (state) => ({
  header : state.header
})

/*  Note: mapStateToProps is where you should use `reselect` to create selectors, ie:

    import { createSelector } from 'reselect'
    const counter = (state) => state.counter
    const tripleCount = createSelector(counter, (count) => count * 3)
    const mapStateToProps = (state) => ({
      counter: tripleCount(state)
    })

    Selectors can compute derived data, allowing Redux to store the minimal possible state.
    Selectors are efficient. A selector is not recomputed unless one of its arguments change.
    Selectors are composable. They can be used as input to other selectors.
    https://github.com/reactjs/reselect    */

export default connect(mapStateToProps, mapDispatchToProps)(Header)
