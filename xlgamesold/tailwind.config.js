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
      }
    },
  },
  plugins: [
    remToPx(),
  ],
}