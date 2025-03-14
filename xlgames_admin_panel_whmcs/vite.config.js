import { defineConfig } from 'vite'
import { svelte } from '@sveltejs/vite-plugin-svelte'

export default defineConfig({
  plugins: [svelte({
    compilerOptions: {
      customElement: true
    },
    emitCss: false
  })],
  server: {
    cors: "*"
  }
})
