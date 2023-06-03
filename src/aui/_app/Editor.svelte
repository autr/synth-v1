<script>
	import Knob from '$aui/_elements/Knob.svelte'
	import Slider from '$aui/_elements/Slider.svelte'
	import Color from '$aui/_elements/Color.svelte'
	import Waveform from '$aui/_elements/Waveform.svelte'
	import Selector from '$aui/_elements/Selector.svelte'
	import Joystick from '$aui/_elements/Joystick.svelte'
	import Icon from '$aui/_elements/Icon.svelte'
	import Numbox from '$aui/_elements/Numbox.svelte'
	import Toggle from '$aui/_elements/Toggle.svelte'
	import Textbox from '$aui/_elements/Textbox.svelte'
	import Props from '$lib/aui/_app/Props.svelte'
	import Colors from '$lib/aui/_app/Colors.svelte'
	import Vars from '$aui/vars.js'


	import { page } from '$app/stores'
	import { browser } from '$app/environment'
	import { goto } from '$app/navigation'
	import { SCHEMA, PROTOTYPE, Defaults } from '$lib/aui/defs.js'
	import { onMount } from 'svelte'
	import { CalculatePixels } from '$lib/API.js'
	const components = { Knob, Slider, Color, Waveform, Selector, Joystick, Numbox, Icon, Toggle, Textbox }

	const defaultProps = Object.keys( Defaults )
	const prototypeNames = Object.keys( PROTOTYPE )

	$: title = $page?.params?.type || ''
	$: name = (title[0].toUpperCase()+title.slice(1))
	$: component = components[name]
	$: schema = SCHEMA[name]
	$: href = $page?.url?.href

	let db = []
	const W = browser ? window : {}

	/* values and localStorage */

	let inited = false
	let debounce
	$: index = ($page?.params?.index || 1)-1

	onMount(onLoadAll)

	function onLoadAll() {

		if (!browser) return
		inited = false
		try { 
			db = JSON.parse( W.localStorage.getItem($page.url.href) ) || [{}]
			console.log('[LocalStorage] ✅ loaded:', db?.length, db)
		} catch(err) {
			db = [{}]
		}

		/* set values */

		for (let entry of db) {

			if (!entry.values) entry.values = {}
			if (!entry.cssvars) entry.cssvars = {}

			for (let [key,props] of Object.entries( schema?.properties || {} ) ) {


				entry.values[key] = entry.values?.[key] == null ? props.default : entry.values[key]
			}
		}

		db = [...db]
		W.requestAnimationFrame( e => { inited = true } )
	}

	$: (onLoadAll)($page)

	function onClearAll() {
		console.log('clear!')
		inited = false
		W.localStorage.removeItem(href)
		onLoadAll()
	}

	function onSaveAll() {
		if (debounce) clearTimeout(debounce)
		debounce = setTimeout( e => {
			try { 
				const str = JSON.stringify(db)
				W.localStorage.setItem(href, str) 
				console.log('[LocalStorage] ✅ saved:', db?.length)
			} catch(err) {}
		}, 600)
	}

	$: onSaveAll(db)

	function setParamsIndex(e,idx) {
		if (idx+1+'' != $page.params.index) goto(`/aui/${title}/${idx+1}`)
	}


	$: css = ['<style>', ':root {', ...Object.keys(db?.[index]?.cssvars || {}).map( name => {
		const val = db?.[index]?.cssvars?.[name]
		if (val) return `--${name}: ${val};`
	}), '}', '</style>' ].join('\n')
</script>

<div class="area">

	<!-- WORKSPACE -->
	
	<div class="workspace">
		{#each db as entry, idx}
			<span 
				draggable={false}
				class="artboard art-{idx+1}">
				<svelte:component 
					{...entry.values}
					on:click={e => setParamsIndex(e, idx)}
					bind:value={entry.values.value}
					this={component} />
			</span>
		{/each}
	</div>

	<!-- SPACER -->
	<span class="vertical v-graphic" />


	<!-- PROPERTIES -->
	<aside class="properties">
		<!-- <Props 
			bind:entry={db[index]} 
			name={name}
			schema={schema} /> -->
	</aside>

	<!-- SPACER -->
	<span class="vertical v-graphic" />

	<!-- THEME -->
	<div class="theming grow overflow-auto">
		<Colors />
		{@html css}
		{#each Object.entries(Vars) as [key, def]}
			<div class="flex row-space-between-center w100pc mb1">
				<div class="grow basis30pc">
					{key}
				</div>
				{#if db?.[index]?.cssvars}
					<Textbox 
						bind:value={db[index].cssvars[key]}
						class="basis50pc grow" />
				{/if}
			</div>
		{/each}
	</div>
</div>