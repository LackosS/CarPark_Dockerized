import { CypressHelper } from "cypress/cypress.helper"

describe('add-level-modal spec', () => {
  it('passes', () => {
    cy.visit('/login')
    CypressHelper.login('company1', '123Lackos123')

    cy.get('[data-test-id="navbar"]').should('be.visible')
    cy.get('[data-test-id="navbar-parkinghouses"]').should('be.visible')
    cy.get('[data-test-id="navbar-parkinghouses"]').click()

    cy.get('[data-test-id="level-table"]').should('be.visible')
    cy.get('[data-test-id="level-table-select"]').select(1,{ force: true })
    cy.get('[data-test-id="level-table-add-level"]').click()

    cy.get('[data-test-id="level-add-modal"]').should('be.visible')
    cy.get('[data-test-id="level-add-modal-submit"]').click()
    cy.get('[data-test-id="level-add-modal-cancel"]').should('be.visible')
    cy.get('[data-test-id="level-add-modal-cancel"]').click()
    cy.get('[data-test-id="level-add-modal"]').should('be.not.visible')
  })
})