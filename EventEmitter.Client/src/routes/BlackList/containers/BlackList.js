import { connect } from 'react-redux'
import BlackListView from '../components/BlackListView'
import { reasonChanged, addToBlackList, loadUsers, userChanged } from '../modules/BlackList'
const mapDispatchToProps = {
  reasonChanged,
  addToBlackList,
  loadUsers,
  userChanged
}

const mapStateToProps = (state) => ({
  blackList: state.BlackList.blackList,
  start: state.BlackList.start,
  name: state.BlackList.name,
  reason:state.BlackList.reason,
  users:state.BlackList.users,
  user:state.BlackList.user
})

export default connect(mapStateToProps, mapDispatchToProps)(BlackListView)
