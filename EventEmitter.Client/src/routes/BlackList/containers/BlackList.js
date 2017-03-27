import { connect } from 'react-redux'
import BlackListView from '../components/BlackListView'
import { forAddingChanged, reasonChanged, addToBlackList } from '../modules/BlackList'
const mapDispatchToProps = {
  forAddingChanged,
  reasonChanged,
  addToBlackList
}

const mapStateToProps = (state) => ({
  blackList: state.BlackList.blackList,
  start: state.BlackList.start,
  name: state.BlackList.name,
  forAdding:state.BlackList.forAdding,
  reason:state.BlackList.reason
})

export default connect(mapStateToProps, mapDispatchToProps)(BlackListView)
