import { connect } from 'react-redux'
import NewEvent from '../components/NewEventView'
import { descriptionChanged } from '../modules/NewEvent'
const mapDispatchToProps = {
  descriptionChanged
}

const mapStateToProps = (state) => ({
  Description: state.Description
})

export default connect(mapStateToProps, mapDispatchToProps)(NewEvent)

