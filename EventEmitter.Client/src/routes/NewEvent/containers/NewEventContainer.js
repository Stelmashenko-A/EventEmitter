import { connect } from 'react-redux'
import NewEvent from '../components/NewEventView'
import {
    nameChanged,
    descriptionChanged,
    slotsChanged,
    durationChanged,
    startChanged,
    imgChanged,
    submit,
    toastClosed
  } from '../modules/newEvent'

const mapDispatchToProps = {
  nameChanged,
  descriptionChanged,
  slotsChanged,
  durationChanged,
  startChanged,
  imgChanged,
  submit,
  toastClosed
}

const mapStateToProps = (state) => ({
  Name: state.newEvent.Name,
  Description: state.newEvent.Description,
  Duration: state.newEvent.Duration,
  Slots: state.newEvent.Slots,
  Start: state.newEvent.Start,
  Image: state.newEvent.Image,
  Saved: state.newEvent.Saved
})

export default connect(mapStateToProps, mapDispatchToProps)(NewEvent)

