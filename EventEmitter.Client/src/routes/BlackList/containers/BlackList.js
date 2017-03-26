import { connect } from 'react-redux'
import BlackListView from '../components/BlackListView'
import { 
} from '../modules/BlackList'
const mapDispatchToProps = {

}

const mapStateToProps = (state) => ({
  blackList: state.BlackList.blackList,
  start: state.BlackList.start,
  name: state.BlackList.name
})

export default connect(mapStateToProps, mapDispatchToProps)(BlackListView)
