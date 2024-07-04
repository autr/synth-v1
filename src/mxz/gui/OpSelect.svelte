<script>
	/*HEADER*/
	import { onMount } from 'svelte'
	import { browser } from '$app/environment'
	import { _UNIFORMS } from '$mxz/store.js'
	
	export let def
	export let key
	export let parentName
	export let name
	export let uuid
	export let rowIdx
	export let colIdx

	const w = browser ? window : {}
	const SAY = (m, e) => console.log(`[OpSelect] ${m}`, e || '')

	$: (_UNIS => {
		if ($_UNIFORMS[key] == null && def.default != null) $_UNIFORMS[key] = JSON.parse( JSON.stringify( def.default ) )
		if (!w.RNDRS) return
		for (const [id, rndr] of Object.entries(w.RNDRS)) {
			
			if (rndr.getValue() != $_UNIFORMS[key]) {
				if (!def.ignore ) {
					try {
						if (rndr.uniforms[key]) rndr.setValue(key,$_UNIFORMS[key])
					} catch(err) {
						console.log('❌ error setting value in OpSelect', err)
					}
				}
			}
		}
	})($_UNIFORMS)
	
	/*/HEADER*/

	import { GetSequenceAsList, IntToUuid, GetLetterFromIdx } from '$mxz/API.js'
	import { _source_select, _SEQUENCE, _recompile } from '$mxz/store.js'
	import { COMPILER_MODES } from '$mxz/defs.js'

	let title = null
	let lastValue
	$: ( v => {
		if (lastValue == $_UNIFORMS[key]) return
		lastValue = $_UNIFORMS[key]
		if ($_UNIFORMS[key] >= 0 && $_UNIFORMS[key] < 99) {
			title = `${GetLetterFromIdx($_UNIFORMS[key])} (${$_UNIFORMS[key]})`
		} else {

			const text = IntToUuid($_UNIFORMS[key])
			const op = GetSequenceAsList().find( op => {
				return op.uuid == text
			})
			title = `${op?.name || 'None'} ${op?.uuid || ''}`
		}
		_recompile.set( COMPILER_MODES.COMPILE )

	})($_UNIFORMS[key])

	let isSelecting = false

	function onEnableDisable(e) {
		if ($_source_select?.key == key) {
			SAY('INITI')
			$_source_select = null
			return 
		}
		SAY(`initiating selection for ${key}`)
		$_source_select = { key, uuid } 
		isSelecting = true
		e.stopPropagation()
	}

	function onClear() {
		$_UNIFORMS[key] = -1
	}

	function onWindowMousedown(e) {
		w.requestAnimationFrame( e => {
			if ($_source_select) {
				SAY('no source was selected')
				$_source_select = null
			}
			isSelecting = false
		})
	}


</script>

<svelte:window on:mousedown={onWindowMousedown} />
<div class="flex">
<button 
	on:mousedown={onEnableDisable}
	class:fade={$_UNIFORMS[key]==-1}
	class:error={$_UNIFORMS[key]!=-1}
	class:alert={$_source_select}
	class:selecting={isSelecting}
	class="italic selector">
	{isSelecting ? 'Selecting...' : title}
</button>
<button
	on:click={onClear}
	class="italic" />
</div>

<style >
	.selector.selecting {
		color: var(--red)
	}
</style>
