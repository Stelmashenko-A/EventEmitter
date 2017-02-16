import React from 'react'
import DatePicker from 'react-datepicker'
import 'react-datepicker/dist/react-datepicker.css'
import { Button, Textfield, CardTitle, Grid, Cell } from 'react-mdl'
import Label from 'grommet/components/Label'
import Toast from 'grommet/components/Toast'
import Dropzone from 'react-dropzone'
import './NewEventView.scss'
function saved(success, toastClosed) {
  if (success) {
    return <Toast status='ok' onClose={toastClosed} >
      A short message to let the user know something.
    </Toast>
  }
}

export const NewEvent = (props) => (
  <div className='new-event' style={{ margin: '0 auto' }} >
    {saved(props.Saved, props.toastClosed)}
    <h1>new event</h1>

    <div>
      <Dropzone onDrop={props.imgChanged} >

        <Label>Try dropping some files here, or click to select files to upload.</Label>
      </Dropzone>

      <div>
        <div className='field-name'><CardTitle className='title'>Name:</CardTitle></div>
        <Textfield
          onChange={props.nameChanged}
          label=''
          floatingLabel
          className='field-value' />
      </div>

      <div>
        <div className='field-name'><CardTitle className='title'>Description:</CardTitle></div>
        <Textfield
          onChange={props.descriptionChanged}
          label=''
          floatingLabel
          className='field-value' />
      </div>

      <div>
        <div className='field-name'><CardTitle className='title'>Duration:</CardTitle></div>
        <Textfield
          onChange={props.durationChanged}
          pattern='[0-9]*'
          error='Input is not a number!'
          label=''
          floatingLabel
          className='field-value' />
      </div>

      <div>
        <div className='field-name'><CardTitle className='title'>Slots:</CardTitle></div>
        <Textfield
          onChange={props.slotsChanged}
          pattern='[0-9]*'
          error='Input is not a number!'
          label=''
          floatingLabel
          className='field-value' />
      </div>

      <div>
        <div className='field-name'><CardTitle className='title'>Date:</CardTitle></div>
        <div className='field-value'><DatePicker onChange={props.startChanged} selected={props.Start} /></div>
      </div>

    </div>
    <Button onClick={props.submit} >Submit </Button>
  </div>
)

NewEvent.propTypes = {
  Start: React.PropTypes.object,
  Saved: React.PropTypes.bool,
  Duration: React.PropTypes.number,
  Price: React.PropTypes.number,
  Description: React.PropTypes.string,
  Slots: React.PropTypes.number,
  Image: React.PropTypes.object,
  Name: React.PropTypes.string,
  descriptionChanged: React.PropTypes.func.isRequired,
  slotsChanged: React.PropTypes.func.isRequired,
  durationChanged: React.PropTypes.func.isRequired,
  startChanged: React.PropTypes.func.isRequired,
  nameChanged: React.PropTypes.func.isRequired,
  imgChanged: React.PropTypes.func.isRequired,
  submit: React.PropTypes.func.isRequired,
  toastClosed: React.PropTypes.func.isRequired
}

export default NewEvent
