export class CypressHelper {
    public static login(username: string, password: string) {
        cy.get('[data-test-id="login-username"]').type(username)
        cy.get('[data-test-id="login-password"]').type(password)
        cy.get('[data-test-id="login-submit"]').click()
    }
}