import React from 'react'
import Select from 'react-select'
import 'react-select/dist/react-select.css'
import axios from 'axios'

const UserLoader = React.createClass({
  displayName: 'UserLoader',
  propTypes: {
    value: React.PropTypes.object,
    onChange: React.PropTypes.func
  },
  getInitialState () {
    return { }
  },

  getUsers (input) {
    if (!input) {
      return Promise.resolve({ options: [] })
    }

    return axios.get(`http://localhost:3001/api/user/part?name=${input}`)
             .then((responce) => {
               return { options: responce.data }
             })
  },

  render () {
    return (
      <div className='section'>
        <Select.Async
          value={this.props.value}
          onChange={this.props.onChange}
          valueKey='id'
          labelKey='name'
          loadOptions={this.getUsers} />
      </div>
    )
  }
})

module.exports = UserLoader
