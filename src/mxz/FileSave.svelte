<script>
	import { onMount } from 'svelte'
	import { browser } from '$app/environment'
	import * as Stores from '$mxz/store.js'
	import { AssignmentsToVDMX } from '$mxz/assignments/MIDI.js'
	import { compile, ALL } from './compiler'
	import { COMPILER_TAGS } from '$mxz/defs.js'
	import { SetStoresFromText, GetStoresAsText, _SEQUENCE, _ASSIGNMENTS } from '$mxz/store.js'

	const w = (browser) ? window : {}
	const SAY = (m, e) => console.log(`[FileSave] ${m}`, e || '')
	const KEY = 'MXZ'

	export function saveLocally() {
		const txt = GetStoresAsText()
		w.localStorage.setItem(KEY, txt )
		SAY(`💾 saved`, JSON.parse( txt ) )
	}

	export function clearLocally() {
		if (w.confirm('Clear?')) {
			w.localStorage.removeItem(KEY)
		}
	}

	export async function loadDefaultProject() {
		let data = await (await fetch('/default.fs')).text()
		const a = data.indexOf(COMPILER_TAGS.START)
		const b = data.indexOf(COMPILER_TAGS.END)
		const json = data.substring(a+COMPILER_TAGS.START.length,b)
		await loadLocally( json )
	}

	export async function loadLocally( data ) {
		SAY('loading from local storage')
		data = data || w.localStorage.getItem(KEY)
		SetStoresFromText(data)
	}

	const date = () => ((new Date()).toISOString())

	export function saveProject() {
		const link = document.createElement('a')
		link.setAttribute('href', `data:application/plain;charset=utf-8,${encodeURIComponent(compile({hide:true,isf:true}))}`)
		link.setAttribute('download', `synth.v1.${date()}.fs`)
		link.click()
	}

	export async function openProject() {
		const opts = {
			types: [
				{
					description: 'Shaders',
					accept: { 'text/*': ['.fs', '.glsl'] }
				},
			],
			excludeAcceptAllOption: true,
			multiple: false
		}
		const [handle] = await window.showOpenFilePicker(opts)
		try {
			const data = await(await handle.getFile()).text()
			const a = data.indexOf(COMPILER_TAGS.START)
			const b = data.indexOf(COMPILER_TAGS.END)
			const json = data.substring(a+COMPILER_TAGS.START.length,b)
			SetStoresFromText(json)
		} catch(err) {
			alert(`Could not open project: ${err.message}`)
		}


	}

	export async function clearAssignments() {
		if (w.confirm('Clear?')) {
			_ASSIGNMENTS.set( {} )
		}
	}

	export async function saveAssignments() {
		console.log('save assignments')
		const link = document.createElement('a')
		const midiConfig = await AssignmentsToVDMX()
		link.setAttribute('href', `data:application/plain;charset=utf-8,${encodeURIComponent( midiConfig )}`)
		link.setAttribute('download', `synth.v1.${date()}.VDMX.fs`)
		link.click()
	}

	onMount(loadLocally)

	const actions = {
		'L: Load': loadLocally,
		'D: Default': loadDefaultProject,
		'L: Save': saveLocally,
		'L: Clear': clearLocally,
		'P: Open': openProject,
		'P: Save': saveProject,
		'M: Clear': clearAssignments,
		'M: Save': saveAssignments,
	}
</script>


{#each Object.entries( actions ) as [name, action]}

	<button
		class="br plr1  grow ptb0-5 pop pointer"
		on:mousedown={action}>
		{ name }
	</button>

{/each}