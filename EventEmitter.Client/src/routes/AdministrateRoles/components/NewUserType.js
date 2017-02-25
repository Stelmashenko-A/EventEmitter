import React from 'react'
import { Textfield, CardTitle } from 'react-mdl'


export const NewUserType = (props) => (
  <div className='new-user-type'>
    <CardTitle> weff</CardTitle>
    <Textfield
      onChange={props.nameChanged}
      label="Text..."
      style={{ width: '200px' }}
    />
  </div>
)
NewUserType.propTypes = {
  Name: React.PropTypes.string,
  nameChanged: React.PropTypes.func
}
export default NewUserType
