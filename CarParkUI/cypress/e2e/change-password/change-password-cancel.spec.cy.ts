import { CypressHelper } from "cypress/cypress.helper"

describe('change-password-cancel spec', () => {
  it('passes', () => {
    cy.visit('/login')
    CypressHelper.login('csonkal', '123Lackos123')

    cy.get('[data-test-id="navbar"]').should('be.visible')
    cy.get('.navbar-change-password').should('be.visible')
    cy.get('.navbar-change-password').click()
    cy.get('[data-test-id="change-password-form"]').should('be.visible')
    cy.get('[data-test-id="change-password-cancel"]').should('be.visible')
    cy.get('[data-test-id="change-password-cancel"]').click()
  })
})