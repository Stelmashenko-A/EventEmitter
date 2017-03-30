import { connect } from 'react-redux'
import WhiteListView from '../components/WhiteListView'
import { reasonChanged, addToWhiteList, loadUsers, userChanged, selectedChanged, deleteUsers } from '../modules/WhiteList'
const mapDispatchToProps = {
  reasonChanged,
  addToWhiteList,
  loadUsers,
  userChanged,
  selectedChanged,
  deleteUsers
}

const mapStateToProps = (state) => ({
  whiteList: state.WhiteList.whiteList,
  start: state.WhiteList.start,
  name: state.WhiteList.name,
  reason:state.WhiteList.reason,
  users:state.WhiteList.users,
  user:state.WhiteList.user
})

export default connect(mapStateToProps, mapDispatchToProps)(WhiteListView)
