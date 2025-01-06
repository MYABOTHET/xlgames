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
      screens: {
        'xlgames-primary': '1152px',
        'xlgames-secondary': '1080px',
        'xlgames-ternary': '924px',
        'xlgames-quaternary': '694px',
        'xlgames-quinary': '580px',
      }
    },
  },
  plugins: [],
}

