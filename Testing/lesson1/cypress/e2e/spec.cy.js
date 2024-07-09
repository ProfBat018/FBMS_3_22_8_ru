describe('template spec', () => {
  it('passes', () => {
    cy.visit('http://localhost:3000/');

    cy.contains('Add New Task').click();

    // заполнение формы



    cy.get('input[id="taskName"]').type('Buy bread');

    cy.get('textarea[id="description"]').type('with seeds');

    cy.get('input[id="deadline"]').type('2021-12-12');

    cy.contains('Add Task').click();

    cy.contains('Cancel').click();


    cy.contains('Show all tasks').click();


    for (let i = 0; i < 1000; i++) {

      cy.contains('Go back').click(); 
      cy.contains('Show all tasks').click();

    }

  })
})