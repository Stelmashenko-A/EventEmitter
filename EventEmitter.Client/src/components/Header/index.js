import EHeader from './Header'
import { connect } from 'react-redux'
import { switchMobileMenu } from './../../store/header'
import { logout } from './../../store/user'


const mapDispatchToProps = {
  switchMobileMenu,
  logout
}

const mapStateToProps = (state) => ({
  header: state.header,
  user:state.user
})

export default connect(mapStateToProps, mapDispatchToProps)(EHeader)
