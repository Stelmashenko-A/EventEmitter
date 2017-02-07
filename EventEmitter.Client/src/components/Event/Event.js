import React from 'react'
import './Event.scss'
import Heading from 'grommet/components/Heading'
import { Link } from 'react-router'
import Image from 'grommet/components/Image'
import Tile from 'grommet/components/Tile'
import { Button } from 'react-mdl'

export const Event = (props) => (
  <div className='event-block'>
    <Tile basis='small' colorIndex='neutral-2'>


      <Image src={props.image} />
      <Heading tag='h2' strong>
        <div>{props.name}</div>
      </Heading>
      <Heading tag='h3'>
        <div>{props.owner}</div>
      </Heading>

      <div>{props.start}</div>
      <div>{props.duration}</div>
      <div>{props.price}</div>
      <div>{props.slots}</div>
      <div>{props.description}</div>
      <Button raised accent ripple component={Link} to={'/event/' + props.id} >Button</Button>
    </Tile>
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
  id:React.PropTypes.string.isRequired
}

export default Event
