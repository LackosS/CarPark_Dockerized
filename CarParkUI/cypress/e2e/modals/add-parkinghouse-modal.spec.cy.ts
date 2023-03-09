import { CypressHelper } from "cypress/cypress.helper"

describe('add-parkinghouse-modal spec', () => {
  it('passes', () => {
    cy.visit('/login')
    CypressHelper.login('company1', '123Lackos123')

    cy.get('[data-test-id="navbar"]').should('be.visible')
    cy.get('[data-test-id="navbar-parkinghouses"]').should('be.visible')
    cy.get('[data-test-id="navbar-parkinghouses"]').click()

    cy.get('[data-test-id="parkinghouse-table"]').should('be.visible')
    cy.get('[data-test-id="parkinghouse-table-add-parkinghouse"]').click()

    cy.get('[data-test-id="parkinghouse-add-modal"]').should('be.visible')
    cy.get('[data-test-id="parkinghouse-add-modal-submit"]').click()
    cy.get('[data-test-id="parkinghouse-add-modal-cancel"]').should('be.visible')
    cy.get('[data-test-id="parkinghouse-add-modal-cancel"]').click()
    cy.get('[data-test-id="parkinghouse-add-modal"]').should('be.not.visible')
  })
})