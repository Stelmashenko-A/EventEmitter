import React from 'react'
import './Event.scss'

export const Event = (props) => (
  <div className=''>
    <div>{props.owner}</div>
    <div>{props.start}</div>
    <div>{props.duration}</div>
    <div>{props.price}</div>
    <div>{props.description}</div>
    <div>{props.slots}</div>

  </div>

)
Event.propTypes = {
  owner: React.PropTypes.string.isRequired,
  start: React.PropTypes.string.isRequired,
  duration: React.PropTypes.number.isRequired,
  price: React.PropTypes.number.isRequired,
  description: React.PropTypes.string.isRequired,
  slots: React.PropTypes.number.isRequired
}

export default Event
