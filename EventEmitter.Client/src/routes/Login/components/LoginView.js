import React from 'react'
import Description from './Description'
import InputForm from './InputForm'

export const Login = (props) => (
  <div style={{ margin: '0 auto' }} >

    <Description />
    <InputForm />

  </div>
)

Login.propTypes = {
  counter: React.PropTypes.number.isRequired,
  doubleAsync: React.PropTypes.func.isRequired,
  increment: React.PropTypes.func.isRequired
}

export default Login
