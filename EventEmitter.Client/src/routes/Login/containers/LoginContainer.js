import { connect } from 'react-redux'
import { googleLogin } from '../modules/login'
import Login from '../components/LoginView'

const mapDispatchToProps = {
  google : googleLogin
}

const mapStateToProps = (state) => ({
  user : state.user
})

export default connect(mapStateToProps, mapDispatchToProps)(Login)
