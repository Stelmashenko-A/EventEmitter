import React from 'react'
import Header from '../../components/Header'
import FirstSection from '../../components/FirstSection'
import './CoreLayout.scss'
import '../../styles/core.scss'

export const CoreLayout = ({ children }) => (
  <div>
    <Header />
    <div className='container text-center'>
      <div className='core-layout__viewport'>
        {children}
      </div>
      <FirstSection />
    </div>
  </div>
)

CoreLayout.propTypes = {
  children : React.PropTypes.element.isRequired
}

export default CoreLayout
