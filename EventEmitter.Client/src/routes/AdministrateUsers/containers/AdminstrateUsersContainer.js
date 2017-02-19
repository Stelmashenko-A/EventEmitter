import { connect } from 'react-redux'
import AdministrateUsersView from '../components/AdministrateUsersView'
import { postUserTypeChanged } from '../modules/AdministrateUsers'
const mapDispatchToProps = (dispatch) => ({
  postUserTypeChanged,
  dispatch
})

const mapStateToProps = (state) => ({
  UserTypes:state.administrateUsers.userTypes,
  Users:state.administrateUsers.users
})

export default connect(mapStateToProps, mapDispatchToProps)(AdministrateUsersView)
