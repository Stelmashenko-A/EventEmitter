import React from 'react'
import './EventList.scss'
import Event from '../Event/Event'
export const EventList = (props) => (
  <div className='header'>
    {(props.events.map((event, i) =>
      <Event
        key={i}
        owner={event.Author}
        start={event.Start}
        duration={event.Duration}
        price={event.Price}
        description={event.Description}
        slots={event.Slots}
        name={event.Name}
        image={event.Image}
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
