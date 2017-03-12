import { connect } from 'react-redux'
import RegistrationsView from '../components/RegistrationsView'
import { postUserTypeChanged } from '../modules/Registrations'
const mapDispatchToProps = (dispatch) => ({
})

const mapStateToProps = (state) => ({
  Registrations:state.registrations.registrations
})

export default connect(mapStateToProps, mapDispatchToProps)(RegistrationsView)
