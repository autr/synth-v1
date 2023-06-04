import { get } from 'svelte/store'
import { arrayMoveImmutable } from 'array-move'
import { browser } from '$app/environment'
import * as Ops from './ops/index.js'

import { DRAG_ACTIONS, COMPILER_MODES, DIMENSIONS, APP_VIEWS, TYPE_UNI_MAP, GUI_UNI_MAP, COMMON_ARGS } from './defs.js'
import BLEND_MODES from '$mxz/compiler/_BlendModes.js'
import { _SEQUENCE, _HIDDEN, _UNIFORMS, _recompile, _selected } from './store.js'

const SAY = (m, e) => console.log(`[API] ${m}`, e || '')

export const GetISFFunctionArgsFromSchema = schema => {

	let ARGS = [ 
		{ type: 'vec4', name: 'INPUT' },
		{ type: 'int', name: 'IN_PASS' },
		{ type: 'vec2', name: 'POS_NORM' },
		{ type: 'vec2', name: 'POS_FRAG' }
	]
	for (const [name, def] of Object.entries(schema)) {
		let { ignore, type } = def
		const common = name == COMMON_ARGS.BL_AMT || name == COMMON_ARGS.BL_MODE
		if (!ignore && !common) {
			type = GUI_UNI_MAP[def.gui] || TYPE_UNI_MAP[def.type] || type

			ARGS.push( {type, name } )
		}
	}
	return ARGS
}	

export function ScaleValue(value, sourceRangeMin, sourceRangeMax, targetRangeMin, targetRangeMax) {
    const targetRange = targetRangeMax - targetRangeMin
    const sourceRange = sourceRangeMax - sourceRangeMin
    return (value - sourceRangeMin) * targetRange / sourceRange + targetRangeMin
}

const CHANNEL = 'Channel'

const w = browser ? window : {}

export function SequenceUpdatedCallback() {


	SAY(`🎞 sequence changed`)
	let changed = false
	console.log('skipping channel adjustments (TODO)')


	// const seq = get(_SEQUENCE).map( (channel,i) => {
	// 	const ch = channel.map( uuid => uuid.split(':')[0])
	// 	const idx = ch.indexOf(CHANNEL)
	// 	const last = ch.length - 1

	// 	if (idx == -1) {
	// 		SAY(`🎞 -> channel added to ${GetLetterFromIdx(i)}`)
	// 		channel.push(GenerateUuidWithName(CHANNEL))
	// 		changed = true
	// 	} else if (idx < last) {
	// 		SAY(`🎞 -> moved channel from ${idx} to ${last}`)
	// 		channel = arrayMoveImmutable(channel, idx, last)
	// 		changed = true

	// 	}
	// 	return channel
	// })


	const seq = get(_SEQUENCE)
	let cp = []
	for (const ch of seq) {
		if (ch.length == 1 && ch[0].indexOf(CHANNEL) != -1)  {
			console.log('EMPTY CHANNEL')
			changed = true
		} else if (ch.length == 0) {
			changed = true
		} else {
			cp.push(ch)
		}
	}

	if (changed) _SEQUENCE.set(cp)
	return changed
}

export function ClearUpUniforms() {
	SAY(`🗑 clearing up uniforms`)
	const UNIFORMS = get(_UNIFORMS)
	let uniforms = {}
	for (const op of GetSequenceAsList()) {
		for (const [k,input] of Object.entries(op.schema.INPUTS)) {
			const key = op.uuid + k
			uniforms[key] = UNIFORMS[key]
		}
	}
	_UNIFORMS.set(uniforms)
}
export function ConvertVariableToString( value, type ) {
	try {
		if (type == 'float') return value.toFixed(3)
		if (type == 'int' || type == 'long' ) return parseInt(value)+''
		if (type == 'vec2' || type == 'vec3' || type == 'vec4' ) return `${type}(${value.map(v=>v.toFixed(3)).join(',')})`
	} catch(err) {}
	return value + ''
}

export function IndexFromRowAndCol(rowIdx, colIdx) {
	let out = 0
	for (const arr of get(_SEQUENCE).slice(0,rowIdx)) out += arr.length
	return out + colIdx
}

export function IsRowColSelected( position ) {
	const a = position
	const b = get(_selected)
	if (!b) return
	return (
		( a[0] == b[0][0] ? a[1] >= b[0][1] : a[0] > b[0][0] ) 
		&& 
		( a[0] == b[1][0] ? a[1] <= b[1][1] : a[0] <= b[0][0] )
	)
}

export function UuidToInt( uuid, alt ) {
	if (!alt) alt = -1
	if (!uuid) return alt
	return parseInt(uuid.substring(1))
}

export function IntToUuid( int, alt ) {
	return 'u' + (int+'').padStart(3,'0')
}

export function SetOpCallback( o ) {
	const { name, uuid, schema } = o
	let UNIFORMS = get(_UNIFORMS)
	for (const [k,def] of Object.entries(schema.INPUTS)) {
		const key = uuid + k
		if (def.link != null) {
			const linkKey = def.link.split(':')[0]
			const linkIdx = parseInt(def.link.split(':')[1])
			_HIDDEN.update( h => {
				h[key] = UNIFORMS[uuid+linkKey] != linkIdx
				return h
			})
		}
	}
}

export const R = e => (`${Math.floor(Math.random()*9)+1}`[0])

export function GenerateUuid() {
	const seq = GetSequenceAsList().map( s => s.uuid)
	for (let i = 0; i < 1000; i++) {
		const uuid = `u${R()}${R()}${R()}`
		if (seq.indexOf(uuid)==-1) return uuid
	}
	alert('error generating uuid')
}

export function GenerateUuidWithName( name ) {

	return name + ':' + GenerateUuid()
}

export function GetLabelFromOp( op, key ) {
	return `${GetLetterFromIdx(op.x)}${op.y+1} ${op.name} ${key}`
}

export function GetFunctionArgumentNames(func) {
	const STRIP_COMMENTS = /((\/\/.*$)|(\/\*[\s\S]*?\*\/))/mg
	const ARGUMENT_NAMES = /([^\s,]+)/g
	let fnStr = func.toString().replace(STRIP_COMMENTS, '')
	let result = fnStr.slice(fnStr.indexOf('(')+1, fnStr.indexOf(')')).match(ARGUMENT_NAMES)
	if(result === null) result = []
	return result
}

export function MakeJsonKeysUppercase(obj) {
	let key, keys = Object.keys(obj)
	let n = keys.length
	let NEU={}
	// debugger;
	while (n--) {
		key = keys[n]
		NEU[key.toUpperCase()] = obj[key]
	}
	for (const [kk, vv] of Object.entries(NEU)) {
		if (vv.constructor === Object) {
			// NEU[kk] = MakeJsonKeysUppercase(vv)
		}
	}
	return NEU
}

export function GetLetterFromIdx(idx) {
	return (String.fromCharCode(97 + idx).toUpperCase())
}

export function GetSelectedSequenceList() {
	const sel = get(_selected)
	const SEQ = get(_SEQUENCE)
	if (!sel) return []
	if (sel.length != 2) return []
	let out = []
	for (let x = sel[0][0]; x <= sel[1][0]; x++ ) {
		for (let y = sel[0][1]; y <= sel[1][1]; y++ ) {
			const name = SEQ?.[x]?.[y]
			if (name) out.push(name)
		}
	}
	return out
}

export function MakeSequenceAdjustment( type, rowIdx, colIdx, overrideCandidates ) {

	console.log(`[API] 💧 ${type} with [${rowIdx},${colIdx}]`)

	let cp = []
	let candidates = []

	if (overrideCandidates) candidates = overrideCandidates

	let x = 0
	let i = 0
	for (const channel of get(_SEQUENCE)) {
		let y = 0
		cp.push([])
		for (const item of channel) {
			let select = IsRowColSelected([x,y])
			if (select) candidates.push(item)
			if (!select) cp[x].push(item)
			y += 1
			i += 1
		}
		x += 1
	}


	if (type == DRAG_ACTIONS.MOVE) cp[rowIdx] = [...cp[rowIdx].slice(0,colIdx + 1), ...candidates, ...cp[rowIdx].slice(colIdx + 1)]
	if (type == DRAG_ACTIONS.INSERT) cp = [...cp.slice(0,rowIdx), candidates, ...cp.slice(rowIdx)]
	if (type == DRAG_ACTIONS.APPEND) cp = [...cp, candidates]

	_SEQUENCE.set( cp )

	return cp
}

export function IsSource(name) {
	const sources = ['Image', 'Video', 'Source', 'Media', 'Camera'] 
	return (sources.indexOf(name) != -1)
}
export function TotalSequenceLength() {
	return get(_SEQUENCE).map( col => (col.length)).reduce((sum, o) => sum + o, 0)
}

export function LoopThroughSequence(callback) {

	const _SEQ = get(_SEQUENCE)

	let x = 0
	for (const col of _SEQ) {
		let y = 0

		// ROW

		for (const row of col) {
			const name = row.split(':')[0]
			const uuid = row.split(':')[1]
			const schema = Ops[name].SCHEMA
			const source = IsSource(name)
			callback({name,schema,x,y,source,uuid})
			y += 1
		}
		x += 1
	}
}


export function GetSequenceAsList() {

	let LIST = []
	LoopThroughSequence( o => (LIST.push( o )) )
	return LIST
}

export function GetUuidsForPasses() {
	let prev
	let out = []
	for ( const op of GetSequenceAsList() ) {
		const isOpPass = op?.schema?.PASS && prev
		const isChannel = prev?.name == CHANNEL
		if ( (isOpPass||isChannel) && out.indexOf(prev.uuid) == -1 ) out.push(prev.uuid)
		prev = op
	}
	return out
}

export function GetOpByUuid( uuid ) {
	uuid = uuid.substring(0, 4)
	return GetSequenceAsList().find( op => op.uuid == uuid )
}

export function GetExpandedHiddenUniforms( expand ) {
	let HIDDEN = get(_HIDDEN)
	if (!expand) return HIDDEN
	for (const op of GetSequenceAsList()) {
		for (const [key,def] of Object.entries(op.schema.INPUTS)) {
			const isOpSelect = def.gui == 'OpSelect'
			const isBlendMode = key == COMMON_ARGS.BL_MODE
			if (isOpSelect) {
				HIDDEN[op.uuid+def.name] = true
			}
		}
	}
	return HIDDEN
}


