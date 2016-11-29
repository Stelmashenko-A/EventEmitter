import { connect } from 'react-redux'
import Event from '../components/EventView'
import { register, interested, dismiss } from '../modules/event'

const mapDispatchToProps = {
  register: register,
  interested: interested,
  dismiss: dismiss
}

const mapStateToProps = (state) => ({
  Name: state.event.Name,
  Description: state.event.Description,
  Duration: state.event.Duration,
  Slots: state.event.Slots,
  Start: state.event.Start,
  Image: state.event.Image,
  Id: state.event.Id,
  RegistrationType: state.event.Type
})

export default connect(mapStateToProps, mapDispatchToProps)(Event)
