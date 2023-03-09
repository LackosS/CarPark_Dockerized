import { CypressHelper } from "cypress/cypress.helper"

describe('add-user-modal spec', () => {
  it('passes', () => {
    cy.visit('/login')
    CypressHelper.login('company1', '123Lackos123')

    cy.get('[data-test-id="navbar"]').should('be.visible')
    cy.get('[data-test-id="navbar-users"]').should('be.visible')
    cy.get('[data-test-id="navbar-users"]').click()

    cy.get('[data-test-id="user-table"]').should('be.visible')
    cy.get('[data-test-id="user-table-add-user"]').click()

    cy.get('[data-test-id="user-add-modal"]').should('be.visible')
    cy.get('[data-test-id="user-add-modal-submit"]').click()
    cy.get('[data-test-id="user-add-modal-cancel"]').should('be.visible')
    cy.get('[data-test-id="user-add-modal-cancel"]').click()
    cy.get('[data-test-id="user-add-modal"]').should('be.not.visible')

  })
})