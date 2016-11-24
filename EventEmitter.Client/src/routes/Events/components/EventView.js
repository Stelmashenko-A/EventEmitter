import React from 'react'
import Label from 'grommet/components/Label'
import Image from 'grommet/components/Image'

export const Event = (props) => (
  <div style={{ margin: '0 auto' }} >
    <Image src={props.Image} />
    <Label>Start:</Label><Label>{props.Start}</Label>
    <Label>Duration:</Label><Label>{props.Duration}</Label>
    <Label>Price:</Label><Label>{props.Price}</Label>
    <Label>Description:</Label><Label>{props.Description}</Label>
    <Label>Slots:</Label><Label>{props.Slots}</Label>
    <Label>Name:</Label><Label>{props.Name}</Label>
  </div>
)

Event.propTypes = {
  Start: React.PropTypes.string,
  Duration: React.PropTypes.number,
  Price: React.PropTypes.number,
  Description: React.PropTypes.string,
  Slots: React.PropTypes.number,
  Image: React.PropTypes.string,
  Name: React.PropTypes.string
}

export default Event
