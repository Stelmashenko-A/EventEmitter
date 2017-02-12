import EHeader from './Header'
import { connect } from 'react-redux'
import { switchMobileMenu } from './../../store/header'

const mapDispatchToProps = {
  switchMobileMenu
}

const mapStateToProps = (state) => ({
  header: state.header,
  user:state.user
})

export default connect(mapStateToProps, mapDispatchToProps)(EHeader)
