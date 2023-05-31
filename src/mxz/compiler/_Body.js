import { get } from 'svelte/store'
import { COMPILER_TYPES, COMMON_ARGS } from '$mxz/Defs.js'
import { _UNIFORMS } from '$mxz/Store.js'
import { GetLetterFromIdx, LoopThroughSequence, UuidToInt, GetUuidsForPasses, IntToUuid } from '$mxz/API.js'

const GetISFFunctionCallFromSchema = (input, schema, prepend) => {

	let ARGS = [input, input+1, schema?.PASSES?.length || 0	]
	for (const [key, def] of Object.entries(schema.INPUTS)) {
		if (!def.ignore) {
			ARGS.push( prepend + key)
		}
	}
	return ARGS
}


export default e => {

	const UNIFORMS = get(_UNIFORMS)

	// PASSES

	const PassUuids = GetUuidsForPasses()

	let OPS = []
	LoopThroughSequence( op => {	
		if (op.schema?.PASSES?.length > 0) {
			for (let i = 0; i < op.schema?.PASSES?.length; i++) {
				OPS.push( { 
					...op, 
					uuid: op.uuid,
					pass: i
				})
			}
		}
		OPS.push( op )
	})

	let pass = 0

	return [
		{
			type: COMPILER_TYPES.FUNC,
			name: 'main',
			prepend: 'void',
			body: (e => {

				let init = false
				let text = ''
				text += `vec2 POS_NORM = POSITION_NORM();\n`
				text += `vec2 POS_FRAG = POSITION_FRAG();\n`
				text += `vec4 BG = vec4(0.0); // GRID(0.02, POS_FRAG);\n`
				text += `vec4 temp = BG;\n`
				let pass = 0
				let lastOpIdx
				let lastChIdx
				OPS.forEach( (op, idx) => {



					const isFinal = idx == OPS.length - 1
					const needsPass = PassUuids.indexOf(op.uuid) != -1 || isFinal
					const isChannel = op.name == 'Channel'
					const lastChUuid = UuidToInt(OPS[lastChIdx]?.uuid)
					const lastOpUuid = UuidToInt(OPS[lastOpIdx]?.uuid)
					const lastBackground = isChannel ? lastChUuid : lastOpUuid

					const GetBufferOrPassPixel = _uuid => {
						if (_uuid < 0 || _uuid == null) return `BG`
						const __uuid = IntToUuid(_uuid)
						const isPass = PassUuids.indexOf(__uuid) != -1
						return ( isPass ) ? `IMG_NORM_PIXEL(${__uuid}, POS_NORM)` : __uuid

					}

					const GetOpLine = e => {
						let txt = ''

						if (op.source) {


							const idxKey = op.uuid + 'Index'
							const rowKey = op.uuid + 'Rows'
							const colKey = op.uuid + 'Columns'

							const shrinkX = `(1. / float(${rowKey} ))`
							const moveX = `(${shrinkX} * float(${idxKey}) )`

							txt += `texture2D(`
							txt += op.uuid + 'Src'
							txt += `, (POS_NORM * vec2( ${shrinkX}, 1.0) + vec2(${moveX},0.0) ))`

						} else {

							// MAKE_PASS - operator functions


							let args = [ 
								GetBufferOrPassPixel(lastOpUuid), 
								pass, 
								'POS_NORM', 
								'POS_FRAG' 
							]

							for (const [name, def] of Object.entries(op.schema.INPUTS)) {
								const common = (name == COMMON_ARGS.BL_AMT || name == COMMON_ARGS.BL_MODE)
								if (!def.ignore && !common) {
									if (def.gui == 'OpSelect') {
										const opSelect = UNIFORMS[op.uuid+name] 
										const opPixel = GetBufferOrPassPixel( opSelect ) 
										args.push( opPixel )
									} else {
										args.push( op.uuid + name )
									}
								}
							}
							txt += op.name
							if (op.schema.PASS) txt += op.uuid
							txt += '(' 
							txt += args.join(',')
							txt += ')'
						}

						return txt

					}

					text += `\n/* ${needsPass ? 'PASS' : ''} ${isChannel ? 'CHANNEL	' : ''} ${op.name} ${op.uuid}  */\n`
					text += `temp = ${GetOpLine()};\n`

					// either gl_FragColor or uXXXX

					text += needsPass ? 'gl_FragColor = ' : op.uuid + ' = '


					// MAKE_PASS - background


					text += `MAKE_PASS( `
					text += `${op.uuid}${COMMON_ARGS.BL_MODE}` // arg 1: blendmode 
					text += `, ${lastBackground ? GetBufferOrPassPixel(lastBackground) : BG}` // arg 2: background
					text += `, temp` // arg 3: op function
					text += `, ${op.uuid}${COMMON_ARGS.BL_AMT})` // make pass blend 
					text += `;\n`
					
					if (needsPass) {
						text += `if ( PASSINDEX == ${pass} ) { return; }\n`
						pass += 1
					}

					lastOpIdx = idx
					if (isChannel) lastChIdx = idx
				})
				return text
			})()
		}
	]


}
