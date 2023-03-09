import { CypressHelper } from "cypress/cypress.helper"

describe('system-admin-user spec', () => {
  it('passes', () => {
    cy.visit('/login')
    cy.get('[data-test-id="login-form"]').should('be.visible')
    CypressHelper.login('csonkal', '123Lackos123')

    cy.get('[data-test-id="navbar"]').should('be.visible')
    cy.get('[data-test-id="navbar-home"]').should('exist')
    cy.get('[data-test-id="navbar-companies"]').should('exist')
    cy.get('[data-test-id="navbar-users"]').should('not.exist')
    cy.get('[data-test-id="navbar-parkinghouses"]').should('not.exist')
    cy.get('[data-test-id="navbar-slots"]').should('not.exist')
    cy.get('[data-test-id="navbar-reservations"]').should('not.exist')
    cy.get('[data-test-id="navbar-reserve]').should('not.exist')

    cy.get('[data-test-id="navbar-sign-out"]').should('exist')
    cy.get('.navbar-change-password').should('be.visible')
  })
})