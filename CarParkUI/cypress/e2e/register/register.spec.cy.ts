describe('register spec', () => {
  it('passes', () => {
    cy.visit('/login')
    cy.get('[data-test-id="login-form"]').should('be.visible')
    cy.get('[data-test-id="login-signup"]').should('be.visible')
    cy.get('[data-test-id="login-signup"]').click()
    
    cy.get('[data-test-id="register-form"]').should('be.visible')
    cy.get('[data-test-id="register-company-name"]').should('be.visible')
    cy.get('[data-test-id="register-full-name"]').should('be.visible')
    cy.get('[data-test-id="register-username"]').should('be.visible')
    cy.get('[data-test-id="register-password"]').should('be.visible')
    cy.get('[data-test-id="register-confirm-password"]').should('be.visible')
    cy.get('[data-test-id="register-agree-checkbox"]').should('exist')
    cy.get('[data-test-id="register-submit"]').should('be.visible')

    cy.get('[data-test-id="register-company-name"]').type('Test Company')
    cy.get('[data-test-id="register-full-name"]').type('Test User')
    cy.get('[data-test-id="register-username"]').type('testuser')
    cy.get('[data-test-id="register-password"]').type('123Lackos123')
    cy.get('[data-test-id="register-confirm-password"]').type('123Lackos123')
    cy.get('[data-test-id="register-agree-checkbox"]').check()

    cy.get('[data-test-id="register-submit"]').click()
  })
})