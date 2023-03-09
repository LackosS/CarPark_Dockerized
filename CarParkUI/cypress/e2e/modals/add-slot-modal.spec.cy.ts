import { CypressHelper } from "cypress/cypress.helper"

describe('add-slot-modal spec', () => {
  it('passes', () => {
    cy.visit('/login')
    CypressHelper.login('company1', '123Lackos123')

    cy.get('[data-test-id="navbar"]').should('be.visible')
    cy.get('[data-test-id="navbar-slots"]').should('be.visible')
    cy.get('[data-test-id="navbar-slots"]').click()

    cy.get('[data-test-id="slots-form"]').should('be.visible')
    cy.get('[data-test-id="slots-form-parkinghouse-select"]').select(1,{ force: true })
    cy.get('[data-test-id="slots-form-level-select"]').select(1,{ force: true })
    cy.get('[data-test-id="slot-add-modal-open"]').click()

    cy.get('[data-test-id="slot-add-modal"]').should('be.visible')
    cy.get('[data-test-id="slot-add-modal-submit"]').click()
    cy.get('[data-test-id="slot-add-modal-cancel"]').should('be.visible')
    cy.get('[data-test-id="slot-add-modal-cancel"]').click()
    cy.get('[data-test-id="slot-add-modal"]').should('be.not.visible')
  })
})