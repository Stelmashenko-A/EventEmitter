import React from 'react'
import Slick from 'react-slick'
import './Slider.scss'

var Slider = React.createClass({
  render: function() {
    var settings = {
      dots: true,
      infinite: true,
      speed: 500,
     // autoplay: true,
      autoplaySpeed: 7500,
      slidesToShow: 1,
      slidesToScroll: 1,
      arrows: false
    }
    return (
      <Slick {...settings}>
        <div className='img-wrapper img-1' ><div className='overlay' /></div>
        <div className='img-wrapper img-2' ><div className='overlay' /></div>
        <div className='img-wrapper img-3' ><div className='overlay' /></div>
        <div className='img-wrapper img-4' ><div className='overlay' /></div>
        <div className='img-wrapper img-5' ><div className='overlay' /></div>
        <div className='img-wrapper img-6' ><div className='overlay' /></div>
      </Slick>
        )
  }
})
export default Slider
