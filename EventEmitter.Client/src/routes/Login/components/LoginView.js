import React from 'react'
import Description from './Description'
import InputForm from './InputForm'

export const Login = (props) => (
  <div style={{ margin: '0 auto' }} >

    <Description />
    <InputForm google={props.google} />

  </div>
)

Login.propTypes = {
  google: React.PropTypes.func.isRequired
}

export default Login
