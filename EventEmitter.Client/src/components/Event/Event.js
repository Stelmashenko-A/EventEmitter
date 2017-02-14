import React from 'react'
import './Event.scss'
import { Link } from 'react-router'
import { Button, Card, CardTitle, CardActions, CardText } from 'react-mdl'

export const Event = (props) => (
  <div className='event-block'>
    <Card shadow={3} className='card'>
      <CardTitle className='title' style={{ background: 'url(' + props.image + ') center / cover' }}>
        {props.name}
      </CardTitle>
      <CardText className='card-text'>
        <div className='owner'>{props.owner}</div>
        <div className='start'>Start: <span>{props.start}</span></div>
        <div className='owner'>About: <span>{props.description}</span></div>
      </CardText>
      <CardActions border>
        <Button className='button' raised accent ripple component={Link} to={'/event/' + props.id} >More info</Button>
      </CardActions>
    </Card>
  </div>

)
Event.propTypes = {
  owner: React.PropTypes.string.isRequired,
  name: React.PropTypes.string.isRequired,
  start: React.PropTypes.string.isRequired,
  duration: React.PropTypes.number.isRequired,
  price: React.PropTypes.number.isRequired,
  description: React.PropTypes.string.isRequired,
  slots: React.PropTypes.number.isRequired,
  image: React.PropTypes.string.isRequired,
  id: React.PropTypes.string.isRequired
}

export default Event
