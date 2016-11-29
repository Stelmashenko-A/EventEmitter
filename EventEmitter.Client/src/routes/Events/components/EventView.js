import React from 'react'
import Label from 'grommet/components/Label'
import Image from 'grommet/components/Image'
import Tiles from 'grommet/components/Tiles'
import Tile from 'grommet/components/Tile'
import Button from 'grommet/components/Button'
import Form from 'grommet/components/Form'
import FormFields from 'grommet/components/FormFields'
import FormField from 'grommet/components/FormField'
import Footer from 'grommet/components/Footer'
import './EventView.scss'

function renderButtons (registrationType, go, interested, dismiss) {
  if (registrationType === 0) {
    return <div className='buttons'>
      <Button label='Go!' onClick={go} />
      <Button label='Interested' onClick={interested} />
    </div>
  }
  return <div className='buttons'>
    <Button label='Remove registration' onClick={dismiss} />
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


    <Form>
      <FormFields>
        <fieldset>
          <FormField label='Field name' htmlFor='input-id'>
            <input id='input-id' name='name' type='text' value={props.Message} onChange={props.messageChanged} />
          </FormField>
        </fieldset>
      </FormFields>
      <Footer pad={{ vertical: 'medium' }}>
        <Button label='Send message' primary onClick={props.sendMessage} />
      </Footer>
    </Form>
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
  RegistrationType: React.PropTypes.number,
  register: React.PropTypes.function,
  interested: React.PropTypes.function,
  dismiss: React.PropTypes.function,
  sendMessage: React.PropTypes.function,
  messageChanged: React.PropTypes.function
}

export default Event
