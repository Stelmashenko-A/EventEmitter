import React from 'react'
import { Link } from 'react-router'
import './Footer.scss'
import { Footer, FooterSection, FooterLinkList } from 'react-mdl'

function toArray (dict) {
  var arr = []
  for (var key in dict) {
    arr.push(dict[key])
  }
  return arr
}

function renderRow (category, i) {
  return <Link key={i} to={'/eventline?cat=' + category.Code} activeClassName='route--active'>{category.Name}</Link>
}

function renderCategories (categories, columnsNumber) {
  var data = toArray(categories)
  var columns = []
  var colunmSize = Math.floor(data.length / columnsNumber)
  var largeColumnsCount = data.length % colunmSize
  for (var i = 0; i < largeColumnsCount; i++) {
    columns.push(data.slice(i * (colunmSize + 1), (colunmSize + 1) + i * (colunmSize + 1)))
  }
  var skip = largeColumnsCount * (colunmSize + 1)
  for (i = 0; i < columnsNumber - largeColumnsCount; i++) {
    columns.push(data.slice(skip + colunmSize * i,
       skip + colunmSize * (i + 1)))
  }
  return columns.map((column, i) =>
    <FooterLinkList key={i}>
      {column.map((category, j) =>
         renderRow(category, j)
         )}
    </FooterLinkList>
      )
}

export const EFooter = (props) => (
  <div className='footer'>

    <Footer>
      <FooterSection type='middle' logo='Categories'>
        {renderCategories(props.categories, 3)}
      </FooterSection>
    </Footer>
  </div>

)
EFooter.propTypes = {
  categories: React.PropTypes.object
}
export default EFooter
