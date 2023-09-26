
import { browser } from '$app/environment'
import { get } from 'svelte/store'
import { COMPILER_TYPES, COMPILER_TAGS } from '$mxz/defs.js'
import { 
	_SOURCES, 
	_SEQUENCE, 
	_TITLES,
	_UNIFORMS, 
	_CURRENT_VIEW, 
	_HIDDEN, 
	_DIMENSIONS } from '$mxz/store.js'

import BLEND_MODES from './_BlendModes.js'
import BODY from './_Body.js'
import HELPERS from './_Helpers.js'
import JSON_CONFIG from './_Json.js'
import OPS from './_Ops.js'
import UTILS from './_Utils.js'

import { GetStoresAsText } from '$mxz/store.js'


const SAY = (m, e) => console.log(`[Compiler] ${m}`, e || '')
export const ALL = { JSON_CONFIG, HELPERS, BLEND_MODES, UTILS, OPS, BODY }

const INDENT_BODY = body => '\t'+body.trim().split('\n').map( str => str.trim() ).join('\n\t')

export const compile = args => {
	if (!args) args = {}
	if (!browser) return ''
	if (!args.keys) args.keys = Object.keys(ALL)
	SAY(`📚 parsing ${args.keys.join(' ')}`)
	const UNIFORMS = get(_UNIFORMS)
	let OUT = ''
	for (const key of args.keys) {
		const item = ALL[key]( args );
		if (!item) SAT(`❌ no such section called ${key}`)
		if (Array.isArray(item)) {
			OUT += item.map( o => {
				let OUT = ''
				OUT += `\n${o.prepend} ${o.name}`

				if (o.type == COMPILER_TYPES.VAR && o.body) {
					OUT += ` = `
				}
				if (o.type == COMPILER_TYPES.FUNC) {
					OUT += `( `
					OUT += (o.arguments || []).map( arg => {
						return `${arg.type} ${arg.name}`
					}).join(', ')
					OUT += `) {\n`
					OUT += `${INDENT_BODY(o.body || '')}`
				} else {
					OUT += `${o.body || ''};`

				}
				if (o.type == COMPILER_TYPES.FUNC) {
					OUT += `\n}`
				}
				return OUT
			}).join('\n')
		} else if ( typeof item == 'string' ) {
			OUT += item
		} else {
			OUT += `/*\n${JSON.stringify(item, null, 2)}\n*/`
		}
	}

	OUT += COMPILER_TAGS.START
	OUT += GetStoresAsText()
	OUT += COMPILER_TAGS.END


	console.log({OUT, UNIFORMS}, 'SHADER')
	window.HELLO = { OUT, UNIFORMS }
// tokenizer()
// parser()
// minify()
// deparser(false)

	// console.log(tokenizer(OUT))

	return OUT
} 