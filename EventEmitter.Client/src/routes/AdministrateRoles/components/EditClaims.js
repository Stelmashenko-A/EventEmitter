import React from 'react'
import { DataTable, TableHeader, Checkbox } from 'react-mdl'

function checkbox (checked, claimChanged) {
  return <Checkbox ripple checked={checked} onChange={claimChanged} />
}

function buildRows (claims, selectedClaims, claimChanged) {
  var rows = []
  claims.forEach(function (item, i, arr) {
    var callback = function () {
      claimChanged(item.Id)
    }
    var obj = {
      Name: item.Name,
      Active: checkbox(selectedClaims.indexOf(item.Id) !== -1, callback)
    }
    rows.push(obj)
  })
  return rows
}

export const EditClaims = (props) => (
  <div className='admin-user'>
    <DataTable
      shadow={0}
      rows={buildRows(props.Claims, props.SelectedClaims, props.claimChanged)}>
      <TableHeader name='Name' tooltip='The amazing material name' className='row-name'>Name</TableHeader>
      <TableHeader name='Active' tooltip='Number of materials'>ACtive</TableHeader>
    </DataTable>
  </div>
)
EditClaims.propTypes = {
  Claims: React.PropTypes.array,
  SelectedClaims: React.PropTypes.array,
  claimChanged:React.PropTypes.func
}
export default EditClaims
