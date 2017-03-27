import React from 'react'
import { Button } from 'react-mdl'
import BigCalendar from 'react-big-calendar'
import moment from 'moment'
import events from './events'
import './CalendarView.scss'
import 'react-big-calendar/lib/css/react-big-calendar.css'
BigCalendar.setLocalizer(
  BigCalendar.momentLocalizer(moment)
)

export const Calendar = (props) => (
  <div className='calendar'>
      <BigCalendar
        onNavigate={props.loadEvents}
        events={props.events}
        defaultDate={new Date()}
/>
  </div>
)

Calendar.propTypes = {
  events: React.PropTypes.array,
  loadEvents: React.PropTypes.func
}

export default Calendar
