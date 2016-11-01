import React from 'react'
import './EventList.scss'
import Event from '../Event/Event'
export const EventList = (props) => (
  <div className='header'>
    {(props.events.map((event, i) =>
      <Event
        key={i}
        owner={event.owner}
        start={event.start}
        duration={event.duration}
        price={event.price}
        description={event.description}
        slots={event.slots}
       />
    ))}

    <button className='btn btn-default' onClick={props.loading}>
      Increment
    </button>
  </div>

)
EventList.propTypes = {
  events: React.PropTypes.array.isRequired,
  loading: React.PropTypes.func.isRequired
}

export default EventList
