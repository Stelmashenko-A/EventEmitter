import React from 'react'

import Header from '../../components/Header'
import EFooter from '../../components/Footer'
import App from 'grommet/components/App'
export const CoreLayout = (props) => (
  <div>
    <App>
      <div className='wrapper'>
        <Header />
        <div className='container text-center'>
          <div className='core-layout__viewport'>
            {props.children}
          </div>
        </div>
        <EFooter categories={props.categories} />
      </div>
    </App>
  </div>
)

CoreLayout.propTypes = {
  children: React.PropTypes.element.isRequired,
  categories: React.PropTypes.object
}

export default CoreLayout
