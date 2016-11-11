import React from 'react'
import DatePicker from 'react-datepicker'
import 'react-datepicker/dist/react-datepicker.css'


export const NewEvent = (props) => (
  <div style={{ margin: '0 auto' }} >
  newevent
    <form>
        Name:
      <input type='text' value={props.Description} onChange={props.descriptionChanged} />
      <input type='text' value={props.Slots} onChange={props.slotsChanged} />
      <input type='text' value={props.Duration} onChange={props.durationChanged} />
      <input type='submit' value='Submit' />
      <DatePicker onChange={props.startChanged} selected={props.Start} />
    </form>
  </div>
)

NewEvent.propTypes = {
  Start: React.PropTypes.string.isRequired,
  Duration: React.PropTypes.number.isRequired,
  Price: React.PropTypes.number.isRequired,
  Description: React.PropTypes.string.isRequired,
  Slots: React.PropTypes.number.isRequired,
  descriptionChanged: React.PropTypes.func.isRequired,
  slotsChanged: React.PropTypes.func.isRequired,
  durationChanged: React.PropTypes.func.isRequired,
  startChanged: React.PropTypes.func.isRequired
}

export default NewEvent
