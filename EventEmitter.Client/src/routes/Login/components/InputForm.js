import React from 'react'

export const InputForm = (props) => (
  <div>
    <input type='text' placeholder='Login' />
    <input type='password' placeholder='Password' />
    <button>Submit</button>
    <button onClick={props.google}>Google</button>
  </div>
)

InputForm.propTypes = {
  google : React.PropTypes.func.isRequired
}

export default InputForm
