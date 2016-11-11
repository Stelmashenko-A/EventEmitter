import { connect } from 'react-redux'
import NewEvent from '../components/NewEventView'
import { descriptionChanged, slotsChanged, durationChanged, startChanged } from '../modules/NewEvent'
const mapDispatchToProps = {
  descriptionChanged,
  slotsChanged,
  durationChanged,
  startChanged
}

const mapStateToProps = (state) => ({
  Description: state.newEvent.Description,
  Duration: state.newEvent.Duration,
  Slots: state.newEvent.Slots,
  Start: state.newEvent.Start
})

export default connect(mapStateToProps, mapDispatchToProps)(NewEvent)

