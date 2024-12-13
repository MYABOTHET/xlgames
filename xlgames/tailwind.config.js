/** @type {import('tailwindcss').Config} */
export default {
  content: ['./src/**/*.{html,js,svelte,ts}'],

  theme: {
    extend: {
      colors: {
        'xlgames-1': '#15181F',
        'xlgames-2': '#212329',
        'xlgames-3': '#FFB400',
        'xlgames-4': '#62687A',
        'xlgames-5': '#CD3737'
      },
      fontFamily: {
        'inter': 'Inter'
      },
      screens: {
        'xlgames-1': '1200px'
      }
    }
  },

  plugins: []
};
