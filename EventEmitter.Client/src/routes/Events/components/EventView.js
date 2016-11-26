import React from 'react'
import Label from 'grommet/components/Label'
import Image from 'grommet/components/Image'
import Tiles from 'grommet/components/Tiles'
import Tile from 'grommet/components/Tile'
import Button from 'grommet/components/Button'
import './EventView.scss'

export const Event = (props) => (
  <div className='event'>
    <Image src={props.Image} />
    <Tiles>
      <Tile>
        <Label>Start:</Label>
      </Tile>
      <Tile>
        <Label>{props.Start}</Label>
      </Tile>
    </Tiles>

    <Tiles>
      <Tile>
        <Label>Duration:</Label>
      </Tile>
      <Tile>
        <Label>{props.Duration}</Label>
      </Tile>
    </Tiles>
    <Tiles>
      <Tile>
        <Label>Price:</Label>
      </Tile>
      <Tile>
        <Label>{props.Price}</Label>
      </Tile>
    </Tiles>
    <Tiles>
      <Tile>
        <Label>Description:</Label>
      </Tile>
      <Tile>
        <Label>{props.Description}</Label>
      </Tile>
    </Tiles>
    <Tiles>
      <Tile>
        <Label>Slots:</Label>
      </Tile>
      <Tile>
        <Label>{props.Slots}</Label>
      </Tile>
    </Tiles>
    <Tiles>
      <Tile>
        <Label>Name:</Label>
      </Tile>
      <Tile>
        <Label>{props.Name}</Label>
      </Tile>
    </Tiles>
    <Button label='Go!' onClick={props.register} />
  </div>
)

Event.propTypes = {
  Start: React.PropTypes.string,
  Duration: React.PropTypes.number,
  Price: React.PropTypes.number,
  Description: React.PropTypes.string,
  Slots: React.PropTypes.number,
  Image: React.PropTypes.string,
  Name: React.PropTypes.string,
  Id: React.PropTypes.string,
  register:React.PropTypes.function
}

export default Event
