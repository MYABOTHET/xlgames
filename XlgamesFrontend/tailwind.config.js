/** @type {import('tailwindcss').Config} */
export default {
  content: ['./src/**/*.{html,js,svelte}'],
  theme: {
    extend: {
      colors: {
        'xlgames-primary': '#15181F',
        'xlgames-secondary': '#212329',
        'xlgames-ternary': '#FFB400',
        'xlgames-quaternary': '#62687A',
      },
      fontFamily: {
        'inter': 'Inter'
      },
    },
  },
  plugins: [],
}

