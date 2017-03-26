import React from 'react'
import { DataTable, TableHeader } from 'react-mdl'

import './BlackListView.scss'



export const BlackListView = (props) => (
  <div className='blackList'>
    <div className='wrapper'>
      <h1 className='eventName'>{props.name}</h1>
      <h1 className='eventStart'>{props.start}</h1>
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
  start: React.PropTypes.string
}
export default BlackListView
