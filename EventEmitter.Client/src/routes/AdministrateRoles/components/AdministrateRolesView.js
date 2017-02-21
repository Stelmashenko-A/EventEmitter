import React from 'react'
import { DataTable, TableHeader, Button } from 'react-mdl'
import { EditClaims } from './EditClaims'
import './AdministrateRolesView.scss'

function button (callback, actived) {
  return <Button raised accent={actived} onClick={callback}>Button</Button>
}
function buildRows (userTypes, activeRole, selectedChanged, fetchGrantedClaims, dispatch) {
  var rows = []
  console.log(selectedChanged)
  userTypes.forEach(function (item, i, arr) {
    var callback = function () {
      dispatch(selectedChanged(item.Id))
      dispatch(fetchGrantedClaims(item.Id))
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

function renderEditTable (activeRole, claims, selectedClaims, dispatch) {
  if (activeRole === '') return

  var callback = function () {
  }

  return <EditClaims Claims={claims} SelectedClaims={selectedClaims} claimChanged={callback} />
}

export const AdministrateRolesView = (props) => (
  <div className='admin-user'>
    <DataTable
      shadow={0}
      rows={buildRows(props.UserTypes, props.ActiveRole, props.selectedChanged, props.fetchGrantedClaims, props.dispatch)}>
      <TableHeader name="Name" tooltip="The amazing material name" className='row-name'>Name</TableHeader>
      <TableHeader numeric name="Users" tooltip="Number of materials">Users</TableHeader>
      <TableHeader numeric name="ClaimsNumber" tooltip="Number of materials">Claims number</TableHeader>
      <TableHeader name="Edit" tooltip="Number of materials">Edit</TableHeader>
    </DataTable>
    {renderEditTable(props.ActiveRole, props.Claims, props.SelectedClaims, props.dispatch)}
  </div>
)
AdministrateRolesView.propTypes = {
  UserTypes: React.PropTypes.array,
  ActiveRole: React.PropTypes.string,
  Claims: React.PropTypes.array,
  SelectedClaims: React.PropTypes.array,
  selectedChanged: React.PropTypes.func,
  dispatch: React.PropTypes.func,
  claimChanged: React.PropTypes.func,
  fetchGrantedClaims: React.PropTypes.func
}
export default AdministrateRolesView
