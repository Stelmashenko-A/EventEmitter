import { connect } from 'react-redux'
import AdministrateRolesView from '../components/AdministrateRolesView'
import { selectedChanged,
  fetchGrantedClaims,
  changeGrantedClaims,
  endAddingUserType,
  startAddingUserType,
  userTypeNameChanged,
  saveNewUserType
} from '../modules/AdministrateRoles'
const mapDispatchToProps = {
  selectedChanged : selectedChanged,
  fetchGrantedClaims: fetchGrantedClaims,
  claimChanged: changeGrantedClaims,
  endAddingUserType,
  startAddingUserType,
  userTypeNameChanged,
  saveNewUserType
}

const mapStateToProps = (state) => ({
  UserTypes: state.administrateRoles.userTypes,
  ActiveRole: state.administrateRoles.selectedId,
  Claims: state.administrateRoles.claims,
  SelectedClaims: state.administrateRoles.grantedClaims,
  AddInProgress: state.administrateRoles.addInProgress,
  UserTypeName: state.administrateRoles.newUserType
})

export default connect(mapStateToProps, mapDispatchToProps)(AdministrateRolesView)
