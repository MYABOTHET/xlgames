import remToPx from 'tailwindcss-rem-to-px';

/** @type {import('tailwindcss').Config} */
export default {
  content: [
    "./index.html",
    "./src/**/*.{svelte,js,svg}",
  ],
  theme: {
    extend: {
      fontFamily: {
        roboto: 'Roboto'
      },
      maxWidth: {
        425: '425px'
      },
      colors: {
        'xlgames-dark-400': '#1b1f28'
      }
    },
  },
  plugins: [
    remToPx(),
  ],
}