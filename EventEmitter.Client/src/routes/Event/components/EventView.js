import React from 'react'
import Image from 'grommet/components/Image'
import { Button, Grid, Cell } from 'react-mdl'

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
function rowH4 (label, value) {
  console.log(value)
  return <h4 style={{ marginTop: '0' }}>{label} {value}</h4>
}
function rowH2 (label, value) {
  return <h2 style={{ margin: '0' }}>{label} {value}</h2>
}
function rowH6 (label, value) {
  return <h6 style={{ margin: '0' }}>{label} {value}</h6>
}


export const Event = (props) => (
  <div className='event'>
    <Grid>
      <Cell col={12}>
        {rowH2('', props.Name)}
      </Cell>
      <Cell col={6}>
        <Image src={props.Image} />
      </Cell>
      <Cell col={6}>
        {rowH4('Start', props.Start)}
        {rowH4('Duration:', props.Duration)}
        {rowH4('Price:', props.Price === undefined ? 'Free' : props.Price)}
        {rowH4('Slots:', props.Slots)}
        {renderButtons(props.RegistrationType, props.register, props.interested, props.dismiss)}
      </Cell>
      <Cell col={12}>
        {rowH6('', props.Description)}
        <textarea id='input-id' name='name' type='text' value={props.Message} onChange={props.messageChanged} />    
      </Cell>
      <Cell col={12}>
        <Button onClick={props.sendMessage} >Send feedback</Button>
      </Cell>
    </Grid>
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
