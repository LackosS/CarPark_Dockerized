import { CypressHelper } from "cypress/cypress.helper"

describe('company-admin-user spec', () => {
  it('passes', () => {
    cy.visit('/login')
    cy.get('[data-test-id="login-form"]').should('be.visible')
    CypressHelper.login('company1', '123Lackos123')
    
    cy.get('[data-test-id="navbar"]').should('be.visible')
    cy.get('[data-test-id="navbar-home"]').should('be.visible')
    cy.get('[data-test-id="navbar-companies"]').should('not.exist')
    cy.get('[data-test-id="navbar-users"]').should('be.visible')
    cy.get('[data-test-id="navbar-parkinghouses"]').should('be.visible')
    cy.get('[data-test-id="navbar-slots"]').should('be.visible')
    cy.get('[data-test-id="navbar-reservations"]').should('be.visible')
    cy.get('.navbar-reserve').should('be.visible')
    
    cy.get('.navbar-change-password').should('be.visible')
    cy.get('[data-test-id="navbar-sign-out"]').should('be.visible')
  })
})