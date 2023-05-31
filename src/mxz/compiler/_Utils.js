import { COMPILER_TYPES, BLEND_MODES } from '$mxz/Defs.js'
import { TotalSequenceLength, GetSequenceAsList, UuidToInt, ConvertVariableToString, LoopThroughSequence, GetLetterFromIdx, GetUuidsForPasses, GetExpandedHiddenUniforms } from '$mxz/API.js'
import { _UNIFORMS, _HIDDEN, _SEQUENCE } from '$mxz/Store.js'
import { get } from 'svelte/store'

const MAKE_ARG = (type, name) => ({name, type})
const BG = 'GRID(0.02, POSITION_FRAG())'
export default args => {

	const UNIFORMS = get(_UNIFORMS)
	const HIDDEN = GetExpandedHiddenUniforms( args.hide )

	const typeUniformMap = {
	  float: 'float',
	  image: 'sampler2D',
	  bool: 'bool',
	  event: 'bool',
	  long: 'int',
	  color: 'vec4',
	  point2D: 'vec2',
	}

	/* hidden uniforms are explicit */

	let HIDDEN_UNIFORMS = []

	if (args.hide) {

		for (const op of GetSequenceAsList()) {
			const { schema, uuid } = op 
			for (const [key,def] of Object.entries(schema.INPUTS)) {
				if (HIDDEN[uuid+key]) {
					const type = typeUniformMap[def.type]
					const body = ConvertVariableToString( UNIFORMS[uuid+key] || def.default,  type )
					HIDDEN_UNIFORMS.push({
						type: COMPILER_TYPES.VAR,
						name: uuid + key,
						prepend: 'const ' + type,
						body
					})
				}
			}
		}
	}

	/* non-pass ops are explicit */

	const PassUuids = GetUuidsForPasses()

	const OP_VEC4S = GetSequenceAsList().filter( op => {
		return PassUuids.indexOf(op.uuid) == -1
	}).map( op => {
		return {
			type: COMPILER_TYPES.VAR,
			name: op.uuid,
			prepend: 'vec4'
		}
	})


	return [
		...OP_VEC4S,
		...HIDDEN_UNIFORMS,
		{
			type: COMPILER_TYPES.VAR,
			name: 'TOTAL_PASSES',
			prepend: 'int',
			body: `${TotalSequenceLength()}`
		},
		{
			type: COMPILER_TYPES.FUNC,
			name: 'POSITION_FRAG',
			prepend: 'vec2',
			body: `return gl_FragCoord.xy;`
		},
		{
			type: COMPILER_TYPES.FUNC,
			name: 'POSITION_NORM',
			prepend: 'vec2',
			body: `
				vec2 p = isf_FragNormCoord;
				// p *= 2.;
				// if (p.y < 0.5) p.y = p.y * 1.5;
				return p;`
		},
		{
			type: COMPILER_TYPES.FUNC,
			name: 'CENTER',
			arguments: [],
			prepend: 'vec2',
			body: 'return vec2( 0.5, 0.5 ) * RENDERSIZE;'
		},
		{
			type: COMPILER_TYPES.FUNC,
			name: 'BLEND',
			arguments: [
				MAKE_ARG('int','mode'),
				MAKE_ARG('vec3','a'),
				MAKE_ARG('vec3','b'),
				MAKE_ARG('float','amount'),
			],
			prepend: 'vec3',
			body: 'vec3 color;\n' + BLEND_MODES.map( (BM, i) => {
		    	return `${i==0?'if':'else if'} (mode == ${i}) { color = ${BM}(a, b); }`
			    }).join('\n')
				+ `\nreturn mix(a, color, amount);`
		},
		{
			type: COMPILER_TYPES.FUNC,
			name: 'MAKE_PASS',
			arguments: [
				MAKE_ARG('int','blendMode'),
				MAKE_ARG('vec4','srcA'),
				MAKE_ARG('vec4','srcB'),
				MAKE_ARG('float','slider'),
			],
			prepend: 'vec4',
			body: `
			float amt = slider * srcB.a;
			float first = clamp( amt * 2.0, 0.0, 1.0);
			float second = clamp( (amt - 0.5) * 2.0, 0.0, 1.0);

			vec3 blend = BLEND( blendMode, srcA.rgb, srcB.rgb, first);
			// 0.5 - 1.0 = 0.0 - 1.0
			return vec4( mix( blend, srcB.rgb, second), 1.0);
			`
		},
		// {
		// 	type: COMPILER_TYPES.FUNC,
		// 	name: 'PIXEL_IDX',
		// 	arguments: [
		// 		// {
		// 		// 	type: 'float',
		// 		// 	name: 'IN_IDX_FLOAT'
		// 		// },
		// 		{
		// 			type: 'int',
		// 			name: 'IN_IDX'
		// 		},
		// 		{
		// 			type: 'vec2', 
		// 			name: 'IN_POS'
		// 		}
		// 	],
		// 	prepend: 'vec3',
		// 	body: (e => {

		// 		let text = '' // 'int IN_IDX = int(IN_IDX_FLOAT);\n'
		// 		text += GetSequenceAsList().map( (op,i) => {
		// 			const isPass = GetUuidsForPasses().indexOf(op.uuid) != -1
		// 			const condition = i == 0 ? `if` : 'else if'
		// 			const returns = isPass ? `IMG_NORM_PIXEL( ${op.uuid}, IN_POS )` : op.uuid
		// 			return `/* ${op.name} ${op.uuid} ${isPass ? '[PASS]' : ''} */
		// 				${condition} (IN_IDX == ${UuidToInt(op.uuid)}) { return ${returns}; }`
		// 		}).join('\n')

		// 		text += (GetSequenceAsList()).length > 0 ? '\n else if ' : 'if '
		// 		text += `(IN_IDX == 999) { return IMG_NORM_PIXEL(u999, IN_POS); }\n` 
		// 		text += `\nreturn ${BG};`
		// 		return text
		// 	})()
		// },
		// {
		// 	type: COMPILER_TYPES.FUNC,
		// 	name: 'PIXEL_IDX',
		// 	arguments: [
		// 		{
		// 			type: 'float',
		// 			name: 'IN_IDX_F'
		// 		},
		// 		{
		// 			type: 'vec2', 
		// 			name: 'IN_POS'
		// 		}
		// 	],
		// 	prepend: 'vec4',
		// 	body: `int IN_IDX = int(IN_IDX_F);\nreturn PIXEL_IDX(IN_IDX, IN_POS);`
		// }

	]
}