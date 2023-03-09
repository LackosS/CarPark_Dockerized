import { CypressHelper } from "cypress/cypress.helper"

describe('simple-user spec', () => {
  it('passes', () => {
    cy.visit('/login')
    cy.get('[data-test-id="login-form"]').should('be.visible')
    CypressHelper.login('user5', '123Lackos123')
    cy.get('[data-test-id="navbar"]').should('be.visible')
    cy.get('[data-test-id="navbar-home"]').should('not.exist')
    cy.get('[data-test-id="navbar-companies"]').should('not.exist')
    cy.get('[data-test-id="navbar-users"]').should('not.exist')
    cy.get('[data-test-id="navbar-parkinghouses"]').should('not.exist')
    cy.get('[data-test-id="navbar-slots"]').should('not.exist')
    cy.get('[data-test-id="navbar-reservations"]').should('be.visible')
    cy.get('.navbar-reserve').should('be.visible')

    cy.get('[data-test-id="navbar-sign-out"]').should('be.visible')
    cy.get('.navbar-change-password').should('be.visible')
  })
})