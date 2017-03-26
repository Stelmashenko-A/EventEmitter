import React from 'react'
import { DataTable, TableHeader, Button, CardTitle, Card, Textfield } from 'react-mdl'
import { EditClaims } from './EditClaims'
import { NewUserType } from './NewUserType'

import './AdministrateRolesView.scss'

function button (callback, actived) {
  return <Button raised accent={actived} onClick={callback}>Button</Button>
}
function buildRows (userTypes, activeRole, selectedChanged, fetchGrantedClaims) {
  var rows = []
  userTypes.forEach(function (item, i, arr) {
    var callback = function () {
      selectedChanged(item.Id)
      fetchGrantedClaims(item.Id)
    }
    var obj = {
      Name: item.Name,
      Users: item.Users,
      ClaimsNumber: item.ClaimsNumber,
      Edit: button(callback, activeRole === item.Id)
    }
    rows.push(obj)
  })
  return rows
}

function renderEditTable (activeRole, claims, selectedClaims, selectedChanged, dispatch) {
  if (activeRole === '') return
  /*var callback = function (id) {
    dispatch(selectedChanged(id))
  }*/
  return <EditClaims Claims={claims} SelectedClaims={selectedClaims} claimChanged={selectedChanged} />
}

function renderAddUserTypeButton (addInProgress, startAddingUserType, saveNewUserType) {
  if (addInProgress) return <Button onClick={saveNewUserType} accent raised >Save New User Type</Button>
  return <Button onClick={startAddingUserType} colored raised>Add New User Type</Button>
}
function renderNewUserTypeSection (addInProgress, userTypeName, userTypeNameChanged) {
  if (addInProgress) {
    return <Card>
      <CardTitle>Enter new user type name</CardTitle>
      <Textfield
        onChange={userTypeNameChanged}
        value={userTypeName}
        floatingLabel
        label='Name'
            />
    </Card>
  }
}
export const AdministrateRolesView = (props) => (
  <div className='admin-user'>
    <DataTable
      shadow={0}
      rows={buildRows(props.UserTypes, props.ActiveRole, props.selectedChanged, props.fetchGrantedClaims)}>
      <TableHeader name="Name" tooltip="The amazing material name" className='row-name'>Name</TableHeader>
      <TableHeader numeric name="Users" tooltip="Number of materials">Users</TableHeader>
      <TableHeader numeric name="ClaimsNumber" tooltip="Number of materials">Claims number</TableHeader>
      <TableHeader name="Edit" tooltip="Number of materials">Edit</TableHeader>
    </DataTable>
    {renderAddUserTypeButton(props.AddInProgress, props.startAddingUserType, props.saveNewUserType)}
    {renderNewUserTypeSection(props.AddInProgress, props.UserTypeName, props.userTypeNameChanged)}
    {renderEditTable(props.ActiveRole, props.Claims, props.SelectedClaims, props.claimChanged)}
  </div>
)
AdministrateRolesView.propTypes = {
  UserTypes: React.PropTypes.array,
  ActiveRole: React.PropTypes.string,
  Claims: React.PropTypes.array,
  SelectedClaims: React.PropTypes.array,
  selectedChanged: React.PropTypes.func,
  claimChanged: React.PropTypes.func,
  fetchGrantedClaims: React.PropTypes.func,
  endAddingUserType: React.PropTypes.func,
  startAddingUserType: React.PropTypes.func,
  AddInProgress:React.PropTypes.bool,
  userTypeNameChanged:React.PropTypes.func,
  UserTypeName:React.PropTypes.string,
  saveNewUserType: React.PropTypes.func
}
export default AdministrateRolesView
