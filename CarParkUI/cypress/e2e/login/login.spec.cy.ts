import { CypressHelper } from "cypress/cypress.helper"

describe('login spec', () => {
  it('passes', () => {
    cy.visit('/')
    cy.get('[data-test-id="login-form"]').should('be.visible')
    cy.get('[data-test-id="login-username"]').should('be.visible')
    cy.get('[data-test-id="login-password"]').should('be.visible')
    cy.get('[data-test-id="login-submit"]').should('be.visible')
    CypressHelper.login('csonkal', '123Lackos123');
  })
})
