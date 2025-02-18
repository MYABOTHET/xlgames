const colors = require('tailwindcss/colors')

/** @type {import('tailwindcss').Config} */
export default {
  content: [
    "./index.html",
    "./src/**/*.{svelte,js}",
  ],
  theme: {
    extend: {
      fontFamily: {
        roboto: 'Roboto'
      },
      colors: {
        shared: colors.slate["300"]
      }
    },
  },
  plugins: [],
}

