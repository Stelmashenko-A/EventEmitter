import React from 'react'
import { DataTable, TableHeader, Button, Textfield } from 'react-mdl'
import UserLoader from '../../../components/UserLoader'
import './BlackListView.scss'

export const BlackListView = (props) => (
  <div className='blackList'>
    <div className='wrapper'>
      <h1 className='eventName'>{props.name}</h1>
      <h1 className='eventStart'>{props.start}</h1>

      <UserLoader value={props.user} onChange={props.userChanged} />

      <Textfield
        onChange={props.reasonChanged}
        label='Text...'
        floatingLabel
        value={props.reason}
        style={{ width: '200px' }} />

      <Button onClick={props.addToBlackList} colored raised>Add To Black List</Button>

      <DataTable
        shadow={0}
        rows={props.blackList}>
        <TableHeader name='user' tooltip='User name' className='row-name'>User name</TableHeader>
        <TableHeader name='added' tooltip='Date of adding'>Date of adding</TableHeader>
        <TableHeader name='desc' tooltip='Description'>Description</TableHeader>
      </DataTable>
    </div>
  </div>
)
BlackListView.propTypes = {
  blackList: React.PropTypes.array,
  name: React.PropTypes.string,
  start: React.PropTypes.string,
  forAddingChanged: React.PropTypes.func,
  reasonChanged: React.PropTypes.func,
  addToBlackList: React.PropTypes.func,
  reason:React.PropTypes.string,
  forAdding:React.PropTypes.string,
  users: React.PropTypes.array,
  loadUsers: React.PropTypes.func,
  user: React.PropTypes.object,
  userChanged: React.PropTypes.func
}
export default BlackListView
