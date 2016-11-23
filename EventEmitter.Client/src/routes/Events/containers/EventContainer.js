import { connect } from 'react-redux'
import Event from '../components/EventView'

const mapDispatchToProps = {
}

const mapStateToProps = (state) => ({
  Name: state.event.Name,
  Description: state.event.Description,
  Duration: state.event.Duration,
  Slots: state.event.Slots,
  Start: state.event.Start,
  Image: state.event.Image
})

export default connect(mapStateToProps, mapDispatchToProps)(Event)
