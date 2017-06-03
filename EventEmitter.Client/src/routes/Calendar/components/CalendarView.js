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
    <div style={{ width:'100%', textAlign: 'right' }}>
      <h1>Calendar</h1>
      <Button style={{ right:0, marginBottom: 20 }}>Export Calendar</Button>
    </div>
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
