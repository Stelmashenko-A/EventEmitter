import React from 'react'
import './Event.scss'
import Card from 'grommet/components/Card'
import Label from 'grommet/components/Label'
import Heading from 'grommet/components/Heading'
import Paragraph from 'grommet/components/Paragraph'
import Image from 'grommet/components/Image'
import Tile from 'grommet/components/Tile'

export const Event = (props) => (
  <div className='event-block'>
    <Tile basis='small' colorIndex='neutral-2'>


      <Image src={props.image} s />
      <Heading tag='h2' strong>
        <div>{props.name}</div>
      </Heading>
      <Heading tag='h3'>
        <div>{props.owner}</div>
      </Heading>
      <Paragraph>
        <div>{props.start}</div>
        <div>{props.duration}</div>
        <div>{props.price}</div>
        <div>{props.slots}</div>
        <div>{props.description}</div>
      </Paragraph>

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
  image: React.PropTypes.string.isRequired
}

export default Event
