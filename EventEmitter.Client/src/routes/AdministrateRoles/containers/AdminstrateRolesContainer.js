import { connect } from 'react-redux'
import AdministrateRolesView from '../components/AdministrateRolesView'
import { selectedChanged, fetchGrantedClaims, changeGrantedClaims, endAddingUserType, startAddingUserType } from '../modules/AdministrateRoles'
const mapDispatchToProps = {
  selectedChanged : selectedChanged,
  fetchGrantedClaims: fetchGrantedClaims,
  claimChanged: changeGrantedClaims,
  endAddingUserType,
  startAddingUserType
}

const mapStateToProps = (state) => ({
  UserTypes: state.administrateRoles.userTypes,
  ActiveRole: state.administrateRoles.selectedId,
  Claims: state.administrateRoles.claims,
  SelectedClaims: state.administrateRoles.grantedClaims,
  AddInProgress:state.administrateRoles.addInProgress
})

export default connect(mapStateToProps, mapDispatchToProps)(AdministrateRolesView)
