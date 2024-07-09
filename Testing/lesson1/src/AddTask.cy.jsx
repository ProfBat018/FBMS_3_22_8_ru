import React from 'react'
import AddTask from './AddTask'

describe('<AddTask />', () => {
  it('renders', () => {
    // see: https://on.cypress.io/mounting-react
    cy.mount(<AddTask />)
  })
})