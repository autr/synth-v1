<script>

	import { onMount, onDestroy, createEventDispatcher } from 'svelte'
	import { browser } from '$app/environment'
	import { DRAG_ACTIONS, BLEND_MODES } from './defs.js'
	import { IsRowColSelected, GetLetterFromIdx } from '$mxz/API.js'
	import { _UNIFORMS, _SEQUENCE, _selected, _dragging, _SOURCES, _source_select } from '$mxz/store.js'
	import { GetSelectedSequenceList, GetSequenceAsList } from './API.js'
	import Slider from '$aui/_elements/Slider.svelte'
	import { _keys } from '$global/store.js'
	import { SHIFT_KEY } from '$global/Keys.js'

	import * as Ops from './ops'

	const SAY = (m, e) => console.log(`[Unit] ${m}`, e || '')
	const w = browser ? window : {}
	let DEBUG = true

	export let name
	export let rowIdx
	export let colIdx 
	export let index
	export let clone = false
	export let uuid



	const dispatch = createEventDispatcher()

	$: isSelected = IsRowColSelected([rowIdx,colIdx])
	function onTouchdown(e) {
		if ($_source_select && $_source_select?.uuid != uuid) {
			const idx = parseInt(uuid.substring(1))
			SAY(`👇 setting OpSelect ${$_source_select.uuid} to ${uuid} ${idx}`)
			$_UNIFORMS[$_source_select.key] = idx
			$_source_select = null
		}
	}
	function onTouchup(e) {
		$_dragging = false
		if (!$_selected) $_selected = [[-1,-1],[-1,-1]]
		let cp = $_selected
		if ($_keys[SHIFT_KEY]) {
			cp[1][0] = rowIdx
			cp[1][1] = colIdx
		} else {
			try {
				cp[0][0] = cp[1][0] = rowIdx
				cp[0][1] = cp[1][1] = colIdx
			} catch(err) {

			}
		}
		cp = cp.sort( (a,b) => ((a[0] == b[0]) ? a[1] - b[1] : a[0] - b[0]))
		console.log(`[Unit] on touchup, setting selected tp ${$_selected}`)
		$_selected = cp
	}

	const onDragstart = e => {

		if (!isSelected) {
			if (!$_selected) $_selected = [[-1,-1],[-1,-1]]
			console.log(`[Unit] resetting selected ${$_selected} to [${rowIdx},${colIdx}]`)
			$_selected = [[rowIdx, colIdx], [rowIdx, colIdx]]
		}

		const viz = document.getElementById('drag-visualiser')
		e.dataTransfer.setDragImage( viz, 80, GetSelectedSequenceList().length * 40)
	}


</script>

<div 
	data-drag-type={DRAG_ACTIONS.MOVE}
	data-drag-rowIdx={ rowIdx }
	data-drag-colIdx={ colIdx - 1 }
	on:drop={ e => dispatch(DRAG_ACTIONS.DROP, e)}
	on:dragover={ e => dispatch(DRAG_ACTIONS.DRAGOVER, e) }
	on:dragenter={ e => dispatch(DRAG_ACTIONS.DRAGENTER, e) }
	on:dragleave={ e => dispatch(DRAG_ACTIONS.DRAGLEAVE, e) }
	on:mouseup={ onTouchup }
	on:mousedown={ onTouchdown }
	class="op op-{name.toLowerCase()} global" 
	class:pop={isSelected}
	class:invisible={clone && !isSelected}>

	<header 
		draggable={$_dragging}
		on:dragstart={onDragstart}
		class="flex column w100pc">
		<div class="flex row-space-between-center w100pc ">
			<div 
				on:mousedown={ e => ($_dragging = true)}
				class="grabbable flex grow row-space-between-center rel p0-5 bg5">
				<div class="f2">
					<span class="bold f1">{GetLetterFromIdx(rowIdx)}{colIdx+1}</span>
					<span class="italic">{name}</span>
				</div>
				<div class="f0">{uuid || ''}</div>
			</div>
		</div>
	</header>
	<div
		class="inner" >
		{#if Ops[name]}
			<svelte:component this={Ops[name].COMPONENT} {uuid} {name} {rowIdx} {colIdx} />
		{:else}
			NO SUCH OPERATOR
		{/if}
	</div>
</div>