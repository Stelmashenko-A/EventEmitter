import React from 'react'
import Label from 'grommet/components/Label'
import Image from 'grommet/components/Image'
import Tiles from 'grommet/components/Tiles'
import Tile from 'grommet/components/Tile'
import { Button } from 'react-mdl'

import './EventView.scss'

function renderButtons (registrationType, go, interested, dismiss) {
  if (registrationType === 0) {
    return <div className='buttons'>
      <Button raised colored onClick={go} >Go!</Button>
      <Button raised accent onClick={interested} >Interested</Button>
    </div>
  }
  if (registrationType === 3) {
    return <div className='buttons'>
      <span>Sorry you do not have permissions for registering</span>
    </div>
  }
  return <div className='buttons'>
    <Button onClick={dismiss} >Remove registration</Button>
  </div>
}
function row (label, value) {
  return <Tiles>
    <Tile>
      <Label>{label}</Label>
    </Tile>
    <Tile>
      <Label>{value}</Label>
    </Tile>
  </Tiles>
}


export const Event = (props) => (
  <div className='event'>
    <Image src={props.Image} />

    {row('Start', props.Start)}
    {row('Duration:', props.Duration)}
    {row('Price:', props.Price)}
    {row('Description:', props.Description)}
    {row('Slots:', props.Slots)}
    {row('Name:', props.Name)}
    {renderButtons(props.RegistrationType, props.register, props.interested, props.dismiss)}

    <input id='input-id' name='name' type='text' value={props.Message} onChange={props.messageChanged} />
    <Button onClick={props.sendMessage} >Send message</Button>

  </div>
)

Event.propTypes = {
  Start: React.PropTypes.string,
  Duration: React.PropTypes.number,
  Price: React.PropTypes.number,
  Description: React.PropTypes.string,
  Slots: React.PropTypes.number,
  Image: React.PropTypes.string,
  Name: React.PropTypes.string,
  Id: React.PropTypes.string,
  Message: React.PropTypes.string,
  Messages: React.PropTypes.array,
  RegistrationType: React.PropTypes.number,
  register: React.PropTypes.func,
  interested: React.PropTypes.func,
  dismiss: React.PropTypes.func,
  sendMessage: React.PropTypes.func,
  messageChanged: React.PropTypes.func
}

export default Event
