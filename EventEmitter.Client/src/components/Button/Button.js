import React from 'react'
export const Button = (props) => (
  <div>
    <div 
      onClick={props.onClick}
      className='mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect mdl-button--accent'>
      {props.label}
      <a href={props.href}></a>
    </div>
  </div>

)
Button.propTypes = {
  onClick: React.PropTypes.func,
  href: React.PropTypes.string,
  label: React.PropTypes.string.isRequired
}

export default Button
