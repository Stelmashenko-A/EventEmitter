import React from 'react'


export const NewEvent = (props) => (
  <div style={{ margin: '0 auto' }} >
  newevent
  </div>
)

NewEvent.propTypes = {
  Start: React.PropTypes.string.isRequired,
  Duration: React.PropTypes.number.isRequired,
  Price: React.PropTypes.number.isRequired,
  Description: React.PropTypes.string.isRequired,
  Slots: React.PropTypes.number.isRequired
}

export default NewEvent
