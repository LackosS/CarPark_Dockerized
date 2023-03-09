import { CypressHelper } from "cypress/cypress.helper"

describe('change-password spec', () => {
  it('passes', () => {
    cy.visit('/login')
    CypressHelper.login('csonkal', '123Lackos123')

    cy.get('[data-test-id="navbar"]').should('be.visible')
    cy.get('.navbar-change-password').should('be.visible')
    cy.get('.navbar-change-password').click()
    cy.get('[data-test-id="change-password-form"]').should('be.visible')

    cy.get('[data-test-id="change-password-username"]').should('be.visible')
    cy.get('[data-test-id="change-password-username"]').type('csonkal')
    cy.get('[data-test-id="change-password-old-password"]').should('be.visible')
    cy.get('[data-test-id="change-password-old-password"]').type('123Lackos123')
    cy.get('[data-test-id="change-password-new-password"]').should('be.visible')
    cy.get('[data-test-id="change-password-new-password"]').type('123Lackos123')
    cy.get('[data-test-id="change-password-confirm-password"]').should('be.visible')
    cy.get('[data-test-id="change-password-confirm-password"]').type('123Lackos123')
    cy.get('[data-test-id="change-password-submit"]').should('be.visible')
    cy.get('[data-test-id="change-password-submit"]').click()


  })
})