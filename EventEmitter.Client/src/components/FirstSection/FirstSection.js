import React from 'react'
import Slider from '../Slider'
import './FirstSection.scss'

export const FirstSection = () => (
  <div className='first-section'>

    <div className='section-content'>
      <div className='label'>Event Emitter</div>
      <div className='description'>Promote, manage, and host successful events.</div>
      <div className='btn'>Start</div>
    </div>
    <Slider />
  </div>
)

export default FirstSection
