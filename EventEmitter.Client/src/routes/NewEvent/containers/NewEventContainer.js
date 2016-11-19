import { connect } from 'react-redux'
import NewEvent from '../components/NewEventView'
import {
    nameChanged,
    descriptionChanged,
    slotsChanged,
    durationChanged,
    startChanged,
    imgChanged,
    submit
  } from '../modules/newEvent'

const mapDispatchToProps = {
  nameChanged,
  descriptionChanged,
  slotsChanged,
  durationChanged,
  startChanged,
  imgChanged,
  submit
}

const mapStateToProps = (state) => ({
  Name: state.newEvent.Name,
  Description: state.newEvent.Description,
  Duration: state.newEvent.Duration,
  Slots: state.newEvent.Slots,
  Start: state.newEvent.Start,
  Image: state.newEvent.Image
})

export default connect(mapStateToProps, mapDispatchToProps)(NewEvent)

