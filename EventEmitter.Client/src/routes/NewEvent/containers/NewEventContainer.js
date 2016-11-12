import { connect } from 'react-redux'
import NewEvent from '../components/NewEventView'
import { descriptionChanged, slotsChanged, durationChanged, startChanged, submit } from '../modules/NewEvent'
const mapDispatchToProps = {
  descriptionChanged,
  slotsChanged,
  durationChanged,
  startChanged,
  submit
}

const mapStateToProps = (state) => ({
  Description: state.newEvent.Description,
  Duration: state.newEvent.Duration,
  Slots: state.newEvent.Slots,
  Start: state.newEvent.Start
})

export default connect(mapStateToProps, mapDispatchToProps)(NewEvent)

