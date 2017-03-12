import React from 'react'
import '../../styles/core.scss'

import EHeader from '../../components/Header'
import EDrawer from '../../components/Drawer'
import EFooter from '../../components/Footer'
import { Layout } from 'react-mdl'
import './CoreLayout.scss'
export const CoreLayout = (props) => (
  <div>
    <Layout>
      <EHeader />
      <EDrawer />
      <div className='wrapper'>
        <div className='container text-center'>
          <div className='core-layout__viewport'>
            {props.children}
          </div>
        </div>
      </div>
      <EFooter categories={props.categories} />
    </Layout>
  </div>
)

CoreLayout.propTypes = {
  children: React.PropTypes.element.isRequired,
  categories: React.PropTypes.object
}

export default CoreLayout
