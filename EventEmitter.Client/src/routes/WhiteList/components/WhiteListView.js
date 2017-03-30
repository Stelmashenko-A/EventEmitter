import React from 'react'
import { DataTable, TableHeader, Button, Textfield } from 'react-mdl'
import UserLoader from '../../../components/UserLoader'
import './WhiteListView.scss'

export const WhiteListView = (props) => (
  <div className='whiteList'>
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

      <Button onClick={props.addToWhiteList} colored raised>Add To White List</Button>
      <Button onClick={props.deleteUsers} colored raised>Remove from wite list</Button>
      <DataTable
        selectable
        onSelectionChanged={props.selectedChanged}
        shadow={0}
        rows={props.whiteList}>
        <TableHeader name='user' tooltip='User name' className='row-name'>User name</TableHeader>
        <TableHeader name='added' tooltip='Date of adding'>Date of adding</TableHeader>
        <TableHeader name='desc' tooltip='Description'>Description</TableHeader>
      </DataTable>
    </div>
  </div>
)
WhiteListView.propTypes = {
  whiteList: React.PropTypes.array,
  name: React.PropTypes.string,
  start: React.PropTypes.string,
  forAddingChanged: React.PropTypes.func,
  reasonChanged: React.PropTypes.func,
  addToWhiteList: React.PropTypes.func,
  reason:React.PropTypes.string,
  forAdding:React.PropTypes.string,
  users: React.PropTypes.array,
  loadUsers: React.PropTypes.func,
  user: React.PropTypes.object,
  userChanged: React.PropTypes.func,
  selectedChanged: React.PropTypes.func,
  deleteUsers: React.PropTypes.func
}
export default WhiteListView
