import { COMPILER_TYPES } from '$mxz/Defs.js'
import { get } from 'svelte/store'
import { LoopThroughSequence, GetISFFunctionArgsFromSchema } from '$mxz/API.js'
import { _UNIFORMS } from '$mxz/Store.js'
import * as Ops from '$mxz/ops'

export default e => {

	/* OPS FUNCTIONS */

	const UNIFORMS = get(_UNIFORMS)

	let OPS = {}
	let last
	LoopThroughSequence( op => {
		let { x, y, name, schema, source, uuid } = op
		let trueName = name
		if (schema.PASS) name += uuid
		if (!OPS[name]) {

			let body = Ops[trueName].GLSL.split('\n').map(l=>'\t'+l).join('\n')
			const texture = last ? last?.uuid : 'inputImage'
			body = body.replaceAll('TEXTURE',texture)
			OPS[name] = {
				type: COMPILER_TYPES.FUNC,
				name,
				prepend: 'vec4',
				arguments: GetISFFunctionArgsFromSchema( schema.INPUTS ),
				body

			}
		}
		last = op

	})

	return Object.values(OPS)
}