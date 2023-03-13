const { defineConfig } = require('cypress')

module.exports = defineConfig({
  e2e: {
    baseUrl: 'http://localhost:4200',
    experimentalRunAllSpecs: true,
    fileServerFolder: '/usr/src/app/dist/car-park-ui',
    setupNodeEvents(on, config) {
      // `on` is used to hook into various events Cypress emits
      // `config` is the resolved Cypress config
    }
  },
})