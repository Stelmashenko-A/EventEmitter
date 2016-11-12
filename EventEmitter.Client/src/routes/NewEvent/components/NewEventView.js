import React from 'react'
import DatePicker from 'react-datepicker'
import 'react-datepicker/dist/react-datepicker.css'


export const NewEvent = (props) => (
  <div style={{ margin: '0 auto' }} >
  newevent

        Name:
    <input type='text' value={props.Description} onChange={props.descriptionChanged} />
    <input type='number' value={props.Slots} onChange={props.slotsChanged} />
    <input type='number' value={props.Duration} onChange={props.durationChanged} />
    <input type='button' value='Submit' onClick={props.submit} />
    <DatePicker onChange={props.startChanged} selected={props.Start} />

  </div>
)

NewEvent.propTypes = {
  Start: React.PropTypes.object,
  Duration: React.PropTypes.number,
  Price: React.PropTypes.number,
  Description: React.PropTypes.string,
  Slots: React.PropTypes.number,
  descriptionChanged: React.PropTypes.func.isRequired,
  slotsChanged: React.PropTypes.func.isRequired,
  durationChanged: React.PropTypes.func.isRequired,
  startChanged: React.PropTypes.func.isRequired,
  submit:React.PropTypes.func.isRequired
}

export default NewEvent
