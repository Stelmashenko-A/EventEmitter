import React from 'react'
import { Link } from 'react-router'
import { DataTable, TableHeader } from 'react-mdl'

function buildLink (name, id) {
  var link = '/event/' + id
  return <Link to={link} activeClassName='route--active'>{name}</Link>
}
function buildLinkForCalendar (id) {
  var link = 'http://localhost:3001/api/Event/cal?EventId=' + id
  return <a href={link}>Calendar</a>
}
function buildRows (registrations) {
  var rows = []
  console.log(registrations)
  registrations.forEach(function (item, i, arr) {
    var obj = {
      Name: buildLink(item.Name, item.EventId),
      Price: item.Price,
      Start: item.Start,
      RegistrationType: item.RegistrationType,
      Calendar:buildLinkForCalendar(item.EventId)
    }
    rows.push(obj)
  })
  return rows
}

export const RegistrationsView = (props) => (
  <div className='registrations-view'>
    <DataTable shadow={0} rows={buildRows(props.Registrations)} className='center'>
      <TableHeader name='Name' tooltip='The amazing material name' className='row-name'>Name</TableHeader>
      <TableHeader numeric name='Price' tooltip='Number of materials'>Price</TableHeader>
      <TableHeader name='Start' tooltip='Number of materials'>Start</TableHeader>
      <TableHeader name='RegistrationType' tooltip='Number of materials'>Registration type</TableHeader>
      <TableHeader name='Calendar' tooltip='Number of materials'> </TableHeader>
    </DataTable>
  </div>
)
RegistrationsView.propTypes = {
  Registrations: React.PropTypes.array
}
export default RegistrationsView
