import { connect } from 'react-redux'
import AdministrateRolesView from '../components/AdministrateRolesView'
import { selectedChanged, fetchGrantedClaims, changeGrantedClaims } from '../modules/AdministrateRoles'
const mapDispatchToProps = (dispatch) => ({
  selectedChanged : selectedChanged,
  fetchGrantedClaims: fetchGrantedClaims,
  claimChanged: changeGrantedClaims,
  dispatch
})

const mapStateToProps = (state) => ({
  UserTypes: state.administrateRoles.userTypes,
  ActiveRole: state.administrateRoles.selectedId,
  Claims: state.administrateRoles.claims,
  SelectedClaims: state.administrateRoles.grantedClaims
})

export default connect(mapStateToProps, mapDispatchToProps)(AdministrateRolesView)
