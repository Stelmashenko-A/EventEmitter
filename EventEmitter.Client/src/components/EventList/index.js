import EventList from './EventList'
import { connect } from 'react-redux'
import { loading } from '../../store/eventList'

const mapDispatchToProps = {
  loading
}

const mapStateToProps = (state) => ({
  events : state.eventList.events,
  user:state.user
})

export default connect(mapStateToProps, mapDispatchToProps)(EventList)
