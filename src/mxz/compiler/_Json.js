import { get } from 'svelte/store'
import {  _SOURCES, _UNIFORMS, _HIDDEN } from '$mxz/store.js'
import { 
	GetLabelFromOp, 
	GetLetterFromIdx, 
	LoopThroughSequence, 
	MakeJsonKeysUppercase, 
	GetUuidsForPasses, 
	GetExpandedHiddenUniforms } from '$mxz/API.js'

export default args => {

	const UNIFORMS = get(_UNIFORMS)
	const HIDDEN = GetExpandedHiddenUniforms( args.hide )

	const PASSES = [...GetUuidsForPasses().map( TARGET => ({
		TARGET, 
		WIDTH: '$WIDTH', 
		HEIGHT: '$HEIGHT', 
		PERSISTENT: true
	})),{
		TARGET: 'u999',
		WIDTH: '$WIDTH', 
		HEIGHT: '$HEIGHT', 
		PERSISTENT: true
	}]

	let CATEGORIES = []
	let INPUTS = [
		{
			NAME: 'inputImage',
			TYPE: 'image'
		},
		{
			NAME: 'Preview',
			TYPE: 'bool',
			default: false
		},
		{
			NAME: 'PreviewSrc',
			TYPE: 'long',
			default: -1
		}
	]

	/* add inputs for each op */

	let lastOp
	LoopThroughSequence( op => {
		let { x, y, name, uuid, schema, source } = op

		// INPUTS

		for (const [key,def] of Object.entries(schema.INPUTS)) {

			/* check for ignored or hidden */

			const hidden = args.hide ? HIDDEN[uuid+key] : false

			if (!def.ignore && !hidden) {
				let INPUT = {
					...MakeJsonKeysUppercase(def),
					NAME: uuid + key,
					LABEL: GetLabelFromOp(op, key),
					DEFAULT: UNIFORMS[uuid+key] || def.default
				}
				if (def.labels) {
					INPUT.VALUES = def.labels.map((l,i) => {
						return i
					})
				}
				INPUTS.push(INPUT)
			}
		}

		// TRANSFORM

		for (let input of INPUTS) {
			if (input.GUI == 'Teleport') {
				input.LABELS = [ ...PASSES.map( p => p.TARGET ) ]
				input.MAX = PASSES.length
			}
		}

		// CATEGORIES

		if (CATEGORIES.indexOf(name) == -1) CATEGORIES.push(name)
		y += 1
		lastOp = op
	})

	const PERSISTENT_BUFFERS = PASSES.map( p => p.TARGET )
	const OUTPUT = {
		DESCRIPTION: 'COMPILED: ' + (new Date()).toLocaleString().toUpperCase().replaceAll(/[&\/\\#,+()$~%.'":*?<>{}]/g,'_'),
		CREDIT: 'MX',
		PERSISTENT_BUFFERS,
		CATEGORIES,
		INPUTS, 
		PASSES
	}
	return OUTPUT
}