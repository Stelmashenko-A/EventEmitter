import React from 'react'
import DatePicker from 'react-datepicker'
import 'react-datepicker/dist/react-datepicker.css'
import { Button, Textfield, CardTitle, Snackbar } from 'react-mdl'
import { SelectField, Option } from 'react-mdl-extra'
import Label from 'grommet/components/Label'
import Dropzone from 'react-dropzone'
import './NewEventView.scss'

function toArray (dict) {
  var arr = []
  for (var key in dict) {
    arr.push(dict[key])
  }
  return arr
}

export const NewEvent = (props) => (
  <div className='new-event'>
    <Snackbar
      active={props.Saved}
      timeout={5000}
      onTimeout={props.toastClosed}>
      Event is saved
    </Snackbar>
    <h1>new event</h1>

    <div className='form'>
      <Dropzone onDrop={props.imgChanged} >
        <Label>Try dropping some files here, or click to select files to upload.</Label>
      </Dropzone>

      <div>
        <div className='field-name'><CardTitle className='title'>Name:</CardTitle></div>
        <div className='field-value'>
          <Textfield
            onChange={props.nameChanged}
            label=''
            floatingLabel
            className='value'
            value={props.Name} />
        </div>
      </div>

      <div>
        <div className='field-name'><CardTitle className='title'>Description:</CardTitle></div>
        <div className='field-value'>
          <Textfield
            onChange={props.descriptionChanged}
            label=''
            floatingLabel
            className='value'
            value={props.Description} />
        </div>
      </div>

      <div>
        <div className='field-name'><CardTitle className='title'>Duration:</CardTitle></div>
        <div className='field-value'>
          <Textfield
            onChange={props.durationChanged}
            pattern='[0-9]*'
            error='Input is not a number!'
            label=''
            floatingLabel
            className='value'
            value={props.Duration} />
        </div>
      </div>

      <div>
        <div className='field-name'><CardTitle className='title'>Slots:</CardTitle></div>
        <div className='field-value'>
          <Textfield
            onChange={props.slotsChanged}
            pattern='[0-9]*'
            error='Input is not a number!'
            label=''
            floatingLabel
            className='value'
            value={props.Slots} />
        </div>
      </div>

      <div>
        <div className='field-name'><CardTitle className='title'>Date:</CardTitle></div>
        <div className='field-value datepicker'>
          <DatePicker onChange={props.startChanged} selected={props.Start} className='mdl-textfield__input' />
        </div>
      </div>
      <div>
        <div className='field-name'><CardTitle className='title'>Category:</CardTitle></div>
        <div className='field-value'>
          <SelectField label={'Select me'} value={props.Categories[0].Code} onChange={props.categoryChanged}>
            {(toArray(props.Categories).map((category, i) =>
              <Option value={category.Code}>{category.Name}</Option>
            ))}
          </SelectField>
        </div>
      </div>
    </div>

    <Button onClick={props.submit} >Submit </Button>
  </div >
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
  Categories: React.PropTypes.object,
  descriptionChanged: React.PropTypes.func.isRequired,
  slotsChanged: React.PropTypes.func.isRequired,
  durationChanged: React.PropTypes.func.isRequired,
  startChanged: React.PropTypes.func.isRequired,
  nameChanged: React.PropTypes.func.isRequired,
  categoryChanged: React.PropTypes.func.isRequired,
  imgChanged: React.PropTypes.func.isRequired,
  submit: React.PropTypes.func.isRequired,
  toastClosed: React.PropTypes.func.isRequired
}

export default NewEvent
