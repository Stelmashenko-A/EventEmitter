import { connect } from 'react-redux'
import Event from '../components/EventView'
import { register, interested, dismiss, sendMessage, messageChanged } from '../modules/event'

const mapDispatchToProps = {
  register: register,
  interested: interested,
  dismiss: dismiss,
  sendMessage: sendMessage,
  messageChanged: messageChanged
}

const mapStateToProps = (state) => ({
  Name: state.event.Name,
  Description: state.event.Description,
  Duration: state.event.Duration,
  Slots: state.event.Slots,
  Start: state.event.Start,
  Image: state.event.Image,
  Id: state.event.Id,
  RegistrationType: state.event.Type,
  Message: state.event.message
})

export default connect(mapStateToProps, mapDispatchToProps)(Event)
