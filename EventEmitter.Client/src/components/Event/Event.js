import React from 'react'
import './Event.scss'
import Box from 'grommet/components/Box'
import Card from 'grommet/components/Card'
import Label from 'grommet/components/Label'
import Heading from 'grommet/components/Heading'
import Paragraph from 'grommet/components/Paragraph'
import Image from 'grommet/components/Image'
export const Event = (props) => (
  <div className=''>
    <Box colorIndex='light-2' pad='medium'>
      <Card label={
        <Label margin='none' uppercase>
          <div>{props.owner}</div>
        </Label>
      } thumbnail={<Image src='/img/carousel-1.png' />} heading={
        <Heading tag='h2' strong>
          <div>{props.name}</div>
        </Heading>
      } description={
        <Paragraph size='large' margin='medium'>
          <div>{props.start}</div>
          <div>{props.duration}</div>
          <div>{props.price}</div>
          <div>{props.slots}</div>
          <div>{props.description}</div>
        </Paragraph>
      } />
    </Box>
  </div>

)
Event.propTypes = {
  owner: React.PropTypes.string.isRequired,
  name: React.PropTypes.string.isRequired,
  start: React.PropTypes.string.isRequired,
  duration: React.PropTypes.number.isRequired,
  price: React.PropTypes.number.isRequired,
  description: React.PropTypes.string.isRequired,
  slots: React.PropTypes.number.isRequired
}

export default Event
