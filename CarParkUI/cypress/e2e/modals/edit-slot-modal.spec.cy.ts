import { CypressHelper } from "cypress/cypress.helper"

describe('edit-slot-modal spec', () => {
  it('passes', () => {
    cy.visit('/login')
    CypressHelper.login('company1', '123Lackos123')

    cy.get('[data-test-id="navbar"]').should('be.visible')
    cy.get('[data-test-id="navbar-slots"]').should('be.visible')
    cy.get('[data-test-id="navbar-slots"]').click()

    cy.get('[data-test-id="slots-form"]').should('be.visible')
    cy.get('[data-test-id="slots-form-parkinghouse-select"]').select(1,{ force: true })
    cy.get('[data-test-id="slots-form-level-select"]').select(1,{ force: true })
    cy.get('[data-test-id="slot-edit-modal-open"]').click()

    cy.get('[data-test-id="slot-edit-modal"]').should('be.visible')
    cy.get('[data-test-id="slot-edit-modal-save"]').click()
    cy.get('[data-test-id="slot-edit-modal-delete"]').should('be.visible')
    cy.get('[data-test-id="slot-edit-modal-delete"]').click()
    cy.get('[data-test-id="slot-edit-modal-open"]').click()
    cy.get('[data-test-id="slot-edit-modal-cancel"]').should('be.visible')
    cy.get('[data-test-id="slot-edit-modal-cancel"]').click()
    cy.get('[data-test-id="slot-edit-modal"]').should('be.not.visible')

  })
})