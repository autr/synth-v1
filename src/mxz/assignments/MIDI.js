
import { browser } from '$app/environment'
import { get } from 'svelte/store'
import parseMidi from 'parse-midi'
import { 
	_contextmenu_learning, 
	_contextmenu_active, 
	_def_lookup, 
	_ASSIGNMENTS, 
	_UNIFORMS } from '$mxz/store.js'
import { ScaleValue, GetOpByUuid, GetLabelFromOp } from '$mxz/API.js'

const SAY = (m, e) => console.log(`[MIDI] 🎛 ${m}`, e || '')

const MIDI_TYPES = {
	CC: 'controlchange',
	NOTE: 'note',
	NOTEON: 'noteon',
	NOTEOFF: 'noteoff'
}

let SMOOTHED = {}
let DESTS = {}
const SMOOTH_AMOUNT = 0.92

const ECHO = true // TODO: make configurable

function tick() {

	const assignments = get( _ASSIGNMENTS )
	for ( const [lookupKey, list] of Object.entries(assignments)) {
		for ( const midiKey of list ) {
			if ( DESTS[midiKey] != undefined ) {
				let sm = SMOOTH_AMOUNT
				SMOOTHED[midiKey] = ( SMOOTHED[midiKey] * sm ) + ( DESTS[midiKey] * (1 - sm) )
				SetUniform( lookupKey, SMOOTHED[midiKey] ) // TODO (accumulate)
			}
		}
	}
	window.requestAnimationFrame( tick )
}

function MIDIToKey( e ) {

	const { manufacturer, name } = e.target
	const data = parseMidi( e.data )
	const { 
		messageCode,
		controlFunction,
		messageType, 
		controlNumber, 
		controlValue, 
		channel, 
		key, 
		velocity } = data

	if ( MIDI_TYPES.CC == messageType ) {
		return [ manufacturer, name, channel, messageType, controlNumber ].join(':')
	}
	if (MIDI_TYPES.NOTEON == messageType || MIDI_TYPES.NOTEOFF == messageType ) {
		return [ manufacturer, name, channel, MIDI_TYPES.NOTE, key ].join(':')
	}
	return null
}

function KeyToMIDI( key ) {
	let data = key.split(':')
	data[2] = parseInt(data[2]) // channel number
	data[4] = parseInt(data[4]) // key or cc number
	return data
}

function SetUniform( lookupKey, value ) {

	const split = lookupKey.split(':')
	const uniformKey = split[0]
	const uniformIdx = parseInt( split[1] )

	const lookup = get( _def_lookup )
	const def = lookup?.[uniformKey]
	if (!def) return SAY(`❌ no lookup for ${uniformKey}`)
	const { min, max, type } = def

	let uniforms = get(_UNIFORMS)

	if (def.type == 'float') {

		uniforms[uniformKey] = ScaleValue( value, 0, 127, min, max )
	} else if (def.type == 'point2D' || def.type == 'color') {
		let currentValue = uniforms[uniformKey]
		uniforms[uniformKey][uniformIdx] = ScaleValue( value, 0, 127, min[uniformIdx], max[uniformIdx] )
	} else if (def.type == 'long') {

		uniforms[uniformKey] = ScaleValue( value, 0, 127, 0, def.labels.length )
	} else if (def.type == 'bool' ) {

		// all are toggles, TODO: make configurable

		// uniforms[uniformKey] = value >= 64 ? true : false
		uniforms[uniformKey] = !uniforms[uniformKey]
	}

	_UNIFORMS.set( uniforms )
}

function OnMIDIMessage( e ) {

	const lookupKey = get(_contextmenu_learning)
	let assignments = get( _ASSIGNMENTS )

	const midiKey = MIDIToKey( e )

	// if assigning...

	if (lookupKey) {


		if (!assignments[lookupKey]) assignments[lookupKey] = []

		if (assignments[lookupKey].indexOf(midiKey) != -1) {
			alert('this assignment already exists.')
		} else {
			SAY(`adding assignment ${midiKey} to ${lookupKey}`)
			assignments[lookupKey] = [ ...assignments[lookupKey], midiKey ]


		}

		_ASSIGNMENTS.set( assignments )
		_contextmenu_learning.set( false )
		_contextmenu_active.set( false )
	}

	// set midi value to uniform

	for ( const [lookupKey, list] of Object.entries(assignments)) {

		if (list.indexOf(midiKey) != -1) {
			const data = parseMidi( e.data )
			const { 
				messageCode,
				controlFunction,
				messageType, 
				controlNumber, 
				controlValue, 
				channel, 
				key, 
				velocity } = data

			if (MIDI_TYPES.CC == messageType) {
				if (!SMOOTHED[midiKey]) SMOOTHED[midiKey] = controlValue
				DESTS[midiKey] = controlValue
			} else {

				// all are toggles, TODO: make configurable

				if (MIDI_TYPES.NOTEON == messageType) SetUniform( lookupKey, velocity )
				// if (MIDI_TYPES.NOTEOFF == messageType) SetUniform( lookupKey, 0 )
			}




		}

	}


}

export async function InitMIDI() {
	if (!browser) return console.log('skipping midi')
	const midi = await navigator.requestMIDIAccess()
	SAY( `requesting MIDI devices`)
	for (const [id, device] of midi.inputs) {
		device.onmidimessage = OnMIDIMessage
		SAY( `✅ attached ${device.manufacturer} ${device.name}`)
	}
	window.requestAnimationFrame( tick )
}

export async function AssignmentsToVDMX() {

	const boolTemplate = {
		mtxFlg: false,
		mtxGrp: 'Button Group', // unknown
		val: true, // starting value
		toggle: true, // always true? tog is set on rcvrs
		sendEnabled: true, // sure, why not
		rcvrs: []
	}

	const numTemplate = {
		publishNormOSCQ: true,
		minRange: 0,
		maxRange: 1,
		smth: 0.1234, // smoothing
		val: 0.1234, // starting value
		sendEnabled: true, // sure, why not
		publishNorm: true, // sure, why not
		rcvrs: []
	}

	const boolMidiTemplate = {
		echNm2: "Launch Control XL-Launch Control XL", // name of device
		echo: true, // true of false (always true, why not)
		src: "\/MIDI\/ch. 9\/note [41]",
		tog: true, // to toggle or not
		wantsEnbl: true, // sure, why not
	}

	const valMidiTemplate = {
		echNm2: "Launch Control XL-Launch Control XL", // name of device
		endM: 5, // threshold for button (I think)
		echo: true, // true of false (always true, why not)
		src: "\/MIDI\/ch. 9\/ctrl [77]",
		tog: true, // to toggle or not
		wantsEnbl: true, // sure, why not
	}

	const fileTemplate = {
		VVGridSize : '{-1, -1}', // sure, why not
		classArray: [
			// 'Button',
			// 'Slider'
		], // types only
		keyArray: [
			// 'slider123',
			// 'button123'
		], // names only
		uiBuilder: {
			// 'slider123': {} // templates
		}
	}

	let VDMX = {...fileTemplate}

	const assignments = get( _ASSIGNMENTS )
	let objectKeys = Object.keys( assignments )

	objectKeys = objectKeys.sort( (a,b) => {
		a = GetOpByUuid( a )
		b = GetOpByUuid( b )
		return a.x - b.x || a.y - b.y
	})

	console.log('HEY!')

	for ( const lookupKey of objectKeys) {

		const list = assignments[ lookupKey ]
		for ( const midiKey of list ) {
			const midiDef = KeyToMIDI( midiKey )
			const deviceName = `${midiDef[1]-midiDef[1]}`
			const op = GetOpByUuid( lookupKey )
			const name = GetLabelFromOp(op, lookupKey.substring(4))
			if (midiDef[3] == 'note') {

				VDMX.classArray.push( 'Button' )
				VDMX.keyArray.push( name )
				VDMX.uiBuilder[name] = {
					...boolMidiTemplate,
					rcvrs: [
						{ ...boolMidiTemplate }
					] 
				}
				VDMX.uiBuilder[name].rcvrs[0].echNm2 = deviceName
				VDMX.uiBuilder[name].rcvrs[0].src = `\/MIDI\/ch. ${midiDef[2]}\/note [${midiDef[4]}]`
			} else if (midiDef[3] == 'controlchange') {

				VDMX.classArray.push( 'Slider' )
				VDMX.keyArray.push( name )
				VDMX.uiBuilder[name] = {
					...valMidiTemplate,
					rcvrs: [
						{ ...valMidiTemplate }
					]
				}
				VDMX.uiBuilder[name].rcvrs[0].echNm2 = deviceName
				VDMX.uiBuilder[name].rcvrs[0].src = `\/MIDI\/ch. ${midiDef[2]}\/ctrl [${midiDef[4]}]`
			}
		}
	}

	const VDMX_TEXT = JSON.stringify( VDMX, null, '\t') 
	return VDMX_TEXT

}