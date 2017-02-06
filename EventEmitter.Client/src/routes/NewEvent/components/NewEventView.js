import React from 'react'
import DatePicker from 'react-datepicker'
import 'react-datepicker/dist/react-datepicker.css'
import { Button } from 'react-mdl'
import TextInput from 'grommet/components/TextInput'
import Label from 'grommet/components/Label'
import NumberInput from 'grommet/components/NumberInput'
import Table from 'grommet/components/Table'
import TableRow from 'grommet/components/TableRow'
import Heading from 'grommet/components/Heading'
import Toast from 'grommet/components/Toast'
import Dropzone from 'react-dropzone'

function saved (success, toastClosed) {
  if (success) {
    return <Toast status='ok' onClose={toastClosed} >
      A short message to let the user know something.
    </Toast>
  }
}

export const NewEvent = (props) => (
  <div style={{ margin: '0 auto' }} >
    {saved(props.Saved, props.toastClosed)}
    <Heading strong uppercase tag='h1' align='center' margin='medium'>new event</Heading>

    <Table>
      <tbody>
        <Dropzone onDrop={props.imgChanged} >

          <Label>Try dropping some files here, or click to select files to upload.</Label>
        </Dropzone>

        <TableRow>
          <td><Label>Name:</Label></td>
          <td><TextInput value={props.Name} onDOMChange={props.nameChanged} /></td>
        </TableRow>

        <TableRow>
          <td><Label>Description:</Label></td>
          <td><TextInput value={props.Description} onDOMChange={props.descriptionChanged} /></td>
        </TableRow>

        <TableRow>
          <td><Label>Duration:</Label></td>
          <td><NumberInput value={props.Duration} onChange={props.durationChanged} /></td>
        </TableRow>

        <TableRow>
          <td><Label>Slots:</Label></td>
          <td><NumberInput value={props.Slots} onChange={props.slotsChanged} /></td>
        </TableRow>

        <TableRow>
          <td><Label>Date:</Label></td>
          <td><DatePicker onChange={props.startChanged} selected={props.Start} /></td>
        </TableRow>
      </tbody>
    </Table>
    <Button onClick={props.submit} >Submit </Button>
  </div>
)

NewEvent.propTypes = {
  Start: React.PropTypes.object,
  Saved: React.PropTypes.bool,
  Duration: React.PropTypes.number,
  Price: React.PropTypes.number,
  Description: React.PropTypes.string,
  Slots: React.PropTypes.number,
  Image: React.PropTypes.object,
  Name: React.PropTypes.string,
  descriptionChanged: React.PropTypes.func.isRequired,
  slotsChanged: React.PropTypes.func.isRequired,
  durationChanged: React.PropTypes.func.isRequired,
  startChanged: React.PropTypes.func.isRequired,
  nameChanged: React.PropTypes.func.isRequired,
  imgChanged: React.PropTypes.func.isRequired,
  submit: React.PropTypes.func.isRequired,
  toastClosed: React.PropTypes.func.isRequired
}

export default NewEvent
