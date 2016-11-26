import { connect } from 'react-redux'
import Event from '../components/EventView'
import { register } from '../modules/event'

const mapDispatchToProps = {
  register:register
}

const mapStateToProps = (state) => ({
  Name: state.event.Name,
  Description: state.event.Description,
  Duration: state.event.Duration,
  Slots: state.event.Slots,
  Start: state.event.Start,
  Image: state.event.Image,
  Id: state.event.Id
})

export default connect(mapStateToProps, mapDispatchToProps)(Event)
