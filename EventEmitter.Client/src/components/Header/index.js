import Header from './Header'
import { connect } from 'react-redux'
import { switchMobileMenu } from './../../store/header'

const mapDispatchToProps = {
  switchMobileMenu
}

const mapStateToProps = (state) => ({
  header: state.header
})

export default connect(mapStateToProps, mapDispatchToProps)(Header)
