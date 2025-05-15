import { sveltekit } from '@sveltejs/kit/vite';
import tailwindcss from '@tailwindcss/vite';
import { defineConfig } from 'vite';
import { SvelteKitPWA } from '@vite-pwa/sveltekit'

export default defineConfig({
	plugins: [sveltekit(), tailwindcss(),  SvelteKitPWA({
		base: '/',
		includeAssets: ['favicon.ico', 'favicon.svg'],
		manifest: {
			name: 'XLGAMES',
			short_name: 'XLGAMES',
			description: 'XLGAMES - Professional hosting of game servers',
			theme_color: '#15181f',
			icons: [
				{
					src: 'favicon.svg',
					sizes: '128x128',
					type: 'image/svg+xml'
				}
			]
		}
	})]
});
