<script>
	/*HEADER*/
	import { onMount } from 'svelte'
	import { browser } from '$app/environment'
	import { _UNIFORMS } from '$mxz/Store.js'
	
	export let def
	export let key
	export let parentName
	export let name
	export let uuid
	export let rowIdx
	export let colIdx

	const w = browser ? window : {}
	const SAY = (m, e) => console.log(`[Auto] ${m}`, e || '')

	$: (_UNIS => {
		if ($_UNIFORMS[key] == null && def.default != null) $_UNIFORMS[key] = JSON.parse( JSON.stringify( def.default ) )
		if (!w.RNDRS) return
		for (const [id, rndr] of Object.entries(w.RNDRS)) {
			
			if (rndr.getValue() != $_UNIFORMS[key]) {
				if (!def.ignore ) {
					try {
						if (rndr.uniforms[key]) rndr.setValue(key,$_UNIFORMS[key])
					} catch(err) {
						console.log('❌ error setting value in Auto', err)
					}
				}
			}
		}
	})($_UNIFORMS)
	
	/*/HEADER*/

	export let component = null
	import { _contextmenu_learning, _contextmenu_active, _ASSIGNMENTS } from '$mxz/Store.js'

	import Slider from '$aui/_elements/Slider.svelte'
	import Toggle from '$aui/_elements/Toggle.svelte'
	import Knob from '$aui/_elements/Knob.svelte'
	import Svg from '$global/Svg.svelte'
	import Arc from '$global/Arc.svelte'
	
	import { _def_lookup } from '$mxz/Store.js'

	let contextPosition = { offsetX: 0, offsetY: 0 }

	function onContextMenu(e, index) {
		$_contextmenu_active = key
		if (index != undefined) $_contextmenu_active += ':' + index
		SAY(`opening context menu with ${$_contextmenu_active}`)
		const { offsetX, offsetY } = e
		contextPosition = { offsetX, offsetY } 
		e.preventDefault()
	}

	function onContextClick(e) {
		e.stopPropagation()
	}

	function onOutsideClick(e) {
		$_contextmenu_active = null
		$_contextmenu_learning = null
	}

	function onToggleMIDILearn(e) {
		$_contextmenu_learning = $_contextmenu_learning ? null : $_contextmenu_active
	}

	function onRemoveAssignment(e) {
		delete $_ASSIGNMENTS[ $_contextmenu_active ]
		$_ASSIGNMENTS = $_ASSIGNMENTS
		$_contextmenu_active = null
		$_contextmenu_learning = null
	}

	let previousKey

	$: ( _key => {
		if (previousKey != key) {
			// SAY(`binding definition lookup ${key}`)
			$_def_lookup[key] = def
			previousKey = key
		}
	})( key )

</script>
<svelte:window on:click={onOutsideClick} />
<div 
	class="auto-element rel"
	on:click={onContextClick}>

	<div 
		style="transform: translate({contextPosition.offsetX}px, {contextPosition.offsetY}px)"
		class:none={($_contextmenu_active || '').indexOf( key ) == -1}
		class="z-index2 bg abs t0 l0 border bt bl br cplr1 cptb0-5">
		<div 
			on:click={onToggleMIDILearn}
			class="bb clickable">
				{$_contextmenu_learning ? 'Learning...' : 'MIDI Learn' }
		</div>
		<div 
			on:click={onRemoveAssignment}
			class="bb clickable">
			Remove Assignments
		</div>
	</div>


	{#if component}
		<svelte:component 
			on:contextmenu={onContextMenu}
			{name}
			id={key}
			{...def}
			bind:value={$_UNIFORMS[key]}
			this={component} />

	{:else if def.type == 'float' || def.type == 'int'}
		<Slider
			on:contextmenu={onContextMenu}
			{name}
			id={key}
			{...def}
			step={def.type == 'float' ? 0 : 1}
			class="mb0 pop"
			bind:value={ $_UNIFORMS[key] } />
	{:else if def.type == 'long'}

		{#if !def.min || !def.labels}
			<input 
				class="input button"
				bind:value={$_UNIFORMS[key]}
				type="number" />
		{:else}
			<select
				on:contextmenu={onContextMenu}
				id={key}
				class="w100pc text-center italic maxw1000pc overflow-hidden" 
				type="text" 
				bind:value={$_UNIFORMS[key]}>
				{#each def.labels || [] as label, i}
					<option name={label} value={i}>{label}</option>
				{/each}
			</select>
		{/if}
	{:else if def.type == 'string'}

		<input 
			on:contextmenu={onContextMenu}
			id={key}
			class="w100pc radius100pc" 
			type="text" 
			bind:value={$_UNIFORMS[key]} 
			{name} />
	{:else if def.type == 'point2D'}
		{#if $_UNIFORMS[key]}
			<Slider
				on:contextmenu={e => onContextMenu(e, 0)}
				class="mb0-5 pop"
				min={def.min[0]}
				max={def.max[0]}
				bind:value={ $_UNIFORMS[key][0] } />
			<Slider
				on:contextmenu={e => onContextMenu(e, 1)}
				class="mb0 pop"
				min={def.min[1]}
				max={def.max[1]}
				bind:value={ $_UNIFORMS[key][1] } />
		{/if}
	{:else if def.type == 'color'}
		{#if $_UNIFORMS[key]}
			<Slider
				on:contextmenu={e => onContextMenu(e, 0)}
				class="mb0-5 pop"
				min={def.min[0]}
				max={def.max[0]}
				bind:value={ $_UNIFORMS[key][0] } />
			<Slider
				on:contextmenu={e => onContextMenu(e, 1)}
				class="mb0-5 pop"
				min={def.min[1]}
				max={def.max[1]}
				bind:value={ $_UNIFORMS[key][1] } />
			<Slider
				on:contextmenu={e => onContextMenu(e, 2)}
				class="mb0 pop"
				min={def.min[2]}
				max={def.max[2]}
				bind:value={ $_UNIFORMS[key][2] } />
		{/if}
	{:else if def.type == 'bool'}
		<Toggle 
			on:contextmenu={onContextMenu}
			bind:value={$_UNIFORMS[key]}
			/>
		<!-- <button
			on:contextmenu={onContextMenu}
			class="italic"
			class:filled={$_UNIFORMS[key]}
			on:click={e => ($_UNIFORMS[key] = !$_UNIFORMS[key])}>
			{key}
		</button> -->
		<!-- <label id={key} class="checkbox">
			<input 
				type="checkbox" 
				bind:checked={$_UNIFORMS[key]} />
			<span />
		</label> -->
	{:else}
		NONE
	{/if}
</div>