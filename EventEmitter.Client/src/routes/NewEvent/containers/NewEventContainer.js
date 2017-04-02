import { connect } from 'react-redux'
import NewEvent from '../components/NewEventView'
import {
    nameChanged,
    descriptionChanged,
    slotsChanged,
    durationChanged,
    categoryChanged,
    startChanged,
    imgChanged,
    blockedChanged,
    submit,
    toastClosed
  } from '../modules/newEvent'

const mapDispatchToProps = {
  nameChanged,
  descriptionChanged,
  slotsChanged,
  durationChanged,
  categoryChanged,
  startChanged,
  imgChanged,
  blockedChanged,
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
  Blocked: state.newEvent.Blocked,
  Saved: state.newEvent.Saved,
  Categories: state.categories,
  Category: state.newEvent.Category
})

export default connect(mapStateToProps, mapDispatchToProps)(NewEvent)

