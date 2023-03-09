import { CypressHelper } from "cypress/cypress.helper"

describe('navbar-navigation spec', () => {
  it('passes', () => {
    cy.visit('/login')

    //System-Admin
    cy.get('[data-test-id="login-form"]').should('be.visible')
    CypressHelper.login('csonkal', '123Lackos123')

    cy.get('[data-test-id="navbar"]').should('be.visible')
    cy.get('[data-test-id="navbar-home"]').should('exist')
    cy.get('[data-test-id="navbar-home"]').click()

    cy.get('[data-test-id="navbar-companies"]').should('exist')
    cy.get('[data-test-id="navbar-companies"]').click()

    cy.get('[data-test-id="navbar-sign-out"]').should('be.visible')
    cy.get('[data-test-id="navbar-sign-out"]').click()

    //Company-Admin
    CypressHelper.login('company1', '123Lackos123')
    cy.get('[data-test-id="navbar"]').should('be.visible')
    cy.get('[data-test-id="navbar-home"]').should('be.visible')
    cy.get('[data-test-id="navbar-home"]').click()

    cy.get('[data-test-id="navbar-users"]').should('be.visible')
    cy.get('[data-test-id="navbar-users"]').click()

    cy.get('[data-test-id="navbar-parkinghouses"]').should('be.visible')
    cy.get('[data-test-id="navbar-parkinghouses"]').click()

    cy.get('[data-test-id="navbar-slots"]').should('be.visible')
    cy.get('[data-test-id="navbar-slots"]').click()

    cy.get('[data-test-id="navbar-reservations"]').should('be.visible')
    cy.get('[data-test-id="navbar-reservations"]').click()

    cy.get('.navbar-reserve').should('be.visible')
    cy.get('.navbar-reserve').click()

    cy.get('[data-test-id="navbar-sign-out"]').should('be.visible')
    cy.get('[data-test-id="navbar-sign-out"]').click()

    //Simple-User
    CypressHelper.login('user5', '123Lackos123')
    cy.get('[data-test-id="navbar"]').should('be.visible')

    cy.get('[data-test-id="navbar-reservations"]').should('be.visible')
    cy.get('[data-test-id="navbar-reservations"]').click()

    cy.get('.navbar-reserve').should('be.visible')
    cy.get('.navbar-reserve').click()

    cy.get('[data-test-id="navbar-sign-out"]').should('be.visible')
    cy.get('[data-test-id="navbar-sign-out"]').click()


  })
})