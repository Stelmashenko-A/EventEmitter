import { connect } from 'react-redux'
import Calendar from '../components/CalendarView'
import { loadEvents } from '../modules/Calendar'

const mapDispatchToProps = {
  loadEvents
}

const mapStateToProps = (state) => ({
  events: state.Calendar.events
})

export default connect(mapStateToProps, mapDispatchToProps)(Calendar)
