import { sveltekit } from '@sveltejs/kit/vite'
import { default as glsl } from 'vite-plugin-glsl'
import svg from '@poppanator/sveltekit-svg';

/** @type {import('vite').UserConfig} */
const config = {
	server: {
		port: 3001
	},
	preview: {
		port: 3001
	},
	plugins: [
		sveltekit(),
		glsl.default(),
		svg({
			includePaths: ['./assets']
		})
	]
}

export default config