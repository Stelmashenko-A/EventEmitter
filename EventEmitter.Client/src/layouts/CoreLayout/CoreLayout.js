import React from 'react'
import 'grommet/scss/vanilla/index.scss'
import Header from '../../components/Header'
import './CoreLayout.scss'
import '../../styles/core.scss'
import App from 'grommet/components/App'
export const CoreLayout = ({ children }) => (
  <div>
    <App>
      <div className='wrapper'>
        <Header />
        <div className='container text-center'>
          <div className='core-layout__viewport'>
            {children}
          </div>
        </div>
      </div>
    </App>
  </div>
)

CoreLayout.propTypes = {
  children: React.PropTypes.element.isRequired
}

export default CoreLayout
