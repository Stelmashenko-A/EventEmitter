import EventList from './EventList'
import { connect } from 'react-redux'
import { loading } from '../../store/eventList'

const mapDispatchToProps = {
  loading
}

const mapStateToProps = (state) => ({
  eventList : state.eventList,
  user:state.user
})

export default connect(mapStateToProps, mapDispatchToProps)(EventList)
