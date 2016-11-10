import { connect } from 'react-redux'
import NewEvent from '../components/NewEventView'
import { descriptionChanged, slotsChanged, durationChanged } from '../modules/NewEvent'
const mapDispatchToProps = {
  descriptionChanged,
  slotsChanged,
  durationChanged
}

const mapStateToProps = (state) => ({
  Description: state.Description,
  Duration: state.Duration,
  Slots: state.Slots
})

export default connect(mapStateToProps, mapDispatchToProps)(NewEvent)

