import { defineConfig } from "cypress";

export default defineConfig({
  e2e: {
    baseUrl: 'http://localhost:4200',
    experimentalRunAllSpecs: true,
    defaultCommandTimeout: 10000,
    pageLoadTimeout: 10000,
    screenshotOnRunFailure: false,
    videoUploadOnPasses: false,
    setupNodeEvents(on, config) {
    },
  },
});
