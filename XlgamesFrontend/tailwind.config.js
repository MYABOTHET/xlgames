/** @type {import('tailwindcss').Config} */
export default {
  content: ['./src/**/*.{html,js,svelte}'],
  theme: {
    extend: {
      colors: {
        'primary': '#15181F',
        'secondary': '#212329',
        'ternary': '#FFB400',
        'quaternary': '#62687A',
      },
      fontFamily: {
        'inter': 'Inter'
      },
      fontWeight: {
        'light-up': '350',
        'base-up': '450',
        'medium-up': '550',
        'semibold-up': '650',
      },
      fontSize: {
        'sm-up': '0.9375rem'
      }
    },
    screens: {
      'primary': '72rem',
      'secondary': '68.75rem',
      'ternary': '56.25rem',
      'quaternary': '42.5rem',
      'quinary': '48rem',
      'hexadecimal': '36.5rem',
      'septenary': '31.25rem',
      'octal': '75rem',
      'nine': '37.5rem'
    },
  },
  plugins: [],
}

