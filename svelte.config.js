import _static from '@sveltejs/adapter-static'
import fs from 'fs-extra'

/*
	DOCS
	====
	https://kit.svelte.dev/docs/configuration
*/

export const CURRENT_ADAPTER = 'static'

const adapters = {
	static: _static({
		fallback: '/index.html',
		trailingSlash: 'always'
	})
}

/** @type {import('@sveltejs/kit').Config} */

export default (await ( async e => {

	/* add aliases for each app */

	let alias = {
		'$assets': 'assets',
		'$api': 'api'
	}
	const dirs = await fs.readdirSync('src', { withFileTypes: true } )
	for ( const dir of dirs ) {
		let key = dir.name.toLowerCase()
		if (key[0]=='_') key = key.substring(1)
		if (dir.isDirectory()) alias['$'+key] = 'src/'+dir.name
	}

	console.log(alias)

	return {
		kit: {
			alias,
			adapter: adapters[CURRENT_ADAPTER],
			files: {
			  assets: 'assets',
		      routes: 'src',
		      lib: 'src'
			}
		}
}})())