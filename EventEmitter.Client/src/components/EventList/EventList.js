import React from 'react'
import './EventList.scss'
import Event from '../Event/Event'
export const EventList = (props) => (
  <div className='header'>
    {(props.events.map((event, i) =>
      <Event
        owner={event.owner}
        start={event.start}
        duration={event.duration}
        price={event.price}
        description={event.description}
        slots={event.slots}
       />
    ))}
  </div>

)
EventList.propTypes = {
  events: React.PropTypes.object.isRequired
}

export default EventList
