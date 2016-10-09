import React from 'react'
import Header from '../../components/Header'
import FirstSection from '../../components/FirstSection'
import './CoreLayout.scss'
import '../../styles/core.scss'
import { switchMobileMenu } from './../../store/header'

export const CoreLayout = ({ children }) => (
  <div className='container text-center'>
    <Header switchMobileMenu={switchMobileMenu} />
    <div className='core-layout__viewport'>
      {children}
    </div>
    <FirstSection />
  </div>
)

CoreLayout.propTypes = {
  children : React.PropTypes.element.isRequired
}

export default CoreLayout
