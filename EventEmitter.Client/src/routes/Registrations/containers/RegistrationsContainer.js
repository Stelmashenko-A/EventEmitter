import { connect } from 'react-redux'
import RegistrationsView from '../components/RegistrationsView'
import { fetchRegistrations, next, past, interested, go } from '../modules/Registrations'
const mapDispatchToProps = {
  fetchRegistrations,
  next,
  past,
  go,
  interested
}

const mapStateToProps = (state) => ({
  Registrations: state.registrations.registrations,
  Next: state.registrations.next,
  Past: state.registrations.past,
  Go: state.registrations.go,
  Interested: state.registrations.interested
})

export default connect(mapStateToProps, mapDispatchToProps)(RegistrationsView)
