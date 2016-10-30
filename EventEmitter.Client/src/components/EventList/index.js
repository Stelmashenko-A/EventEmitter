import EventList from './EventList'
import { connect } from 'react-redux'

const mapDispatchToProps = {
}

const mapStateToProps = (state) => ({
  events : state.eventList.events
})

export default connect(mapStateToProps, mapDispatchToProps)(EventList)
