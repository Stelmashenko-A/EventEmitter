import React from 'react'
import './EventList.scss'
import Event from '../Event/Event'
import Tiles from 'grommet/components/Tiles'
import Button from './../../components/Button'

function renderEvent (event, i) {
  if (event != null) {
    return <Event
      key={i}
      owner={event.Author}
      start={event.Start}
      duration={event.Duration}
      price={event.Price}
      description={event.Description}
      slots={event.Slots}
      name={event.Name}
      image={event.Image}
      id={event.Id}
      />
  }
}

export const EventList = (props) => (
  <div className='event-list'>
    <Tiles colorIndex='light-2' justify='center'>
      {(props.events.map((event, i) =>
         renderEvent(event, i)
      ))}
    </Tiles>
    <Button label='Load more' onClick={props.loading} />
  </div>

)
EventList.propTypes = {
  events: React.PropTypes.array,
  loading: React.PropTypes.func.isRequired
}

export default EventList
