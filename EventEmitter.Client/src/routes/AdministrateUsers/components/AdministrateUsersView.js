import React from 'react'
import { DataTable, TableHeader } from 'react-mdl'
import { SelectField, Option } from 'react-mdl-extra'
import './AdministrateUsersView.scss'

function dropDown (value, id, dataArray, postUserTypeChanged) {
  return <SelectField label={'Select me'} value={value} onChange={postUserTypeChanged}>
    {(dataArray.map((item, i) =>
      <Option key={i} value={item.Id}>{item.Name}</Option>
    ))}
  </SelectField>
}

function block (className, value) {
  return <div className={className}>{value}</div>
}

function buildRows (users, userTypes, postUserTypeChanged, dispatch) {
  var rows = []
  users.forEach(function (item, i, arr) {
    function callback (data) {
      dispatch(postUserTypeChanged(data, item.Id))
    }
    var obj = {
      Name: block('row-name', item.Name),
      Events: item.Events,
      Messages: item.Events,
      InterestedTotal: item.Events,
      GoTotal: item.Events,
      WillGo: item.Events,
      Interested: item.Events,
      UserType: dropDown(item.UserTypeId, item.Id, userTypes, callback),
      LoginProvider: item.LoginProvider
    }
    rows.push(obj)
  })
  return rows
}

export const AdministrateUsersView = (props, dispatch) => (
  <div className='admin-user'>
    <DataTable
      shadow={0}
      rows={buildRows(props.Users, props.UserTypes, props.postUserTypeChanged, props.dispatch)}
    >
      <TableHeader name="Name" tooltip="The amazing material name" className='row-name'>Name</TableHeader>
      <TableHeader numeric name="Events" tooltip="Number of materials">Events</TableHeader>
      <TableHeader numeric name="Messages" tooltip="Number of materials">Messages</TableHeader>
      <TableHeader numeric name="InterestedTotal" tooltip="Number of materials">Interested total</TableHeader>
      <TableHeader numeric name="GoTotal" tooltip="Number of materials">Go Total</TableHeader>
      <TableHeader numeric name="Interested" tooltip="Number of materials">Interested</TableHeader>
      <TableHeader numeric name="WillGo" tooltip="Number of materials">Will go</TableHeader>
      <TableHeader name="UserType" tooltip="The amazing material name">User type</TableHeader>
      <TableHeader name="LoginProvider" tooltip="The amazing material name">Login provider</TableHeader>
    </DataTable>
  </div>
)
AdministrateUsersView.propTypes = {
  UserTypes: React.PropTypes.array,
  Users: React.PropTypes.array,
  postUserTypeChanged :React.PropTypes.func,
  dispatch:React.PropTypes.func
}
export default AdministrateUsersView
