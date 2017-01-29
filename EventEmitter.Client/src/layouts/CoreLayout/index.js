import { connect } from 'react-redux'
import CoreLayout from './CoreLayout'

const mapDispatchToProps = {
}

const mapStateToProps = (state) => ({
  categories : state.categories
})

export default connect(mapStateToProps, mapDispatchToProps)(CoreLayout)
