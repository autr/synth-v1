<script>

	import { browser } from '$app/environment'
	
	import { IsRowColSelected, GetLetterFromIdx, MakeSequenceAdjustment, IndexFromRowAndCol, GetSequenceAsList, SequenceUpdatedCallback } from '$mxz/API.js'
	import { DRAG_ACTIONS, TYPES, COMPILER_MODES } from '$mxz/Defs.js'
	import { _SEQUENCE, _UNIFORMS, _TITLES, _selected, _dragging, _recompile, _source_select } from '$mxz/Store.js'
	import { onElDragover, onElDrop } from '$mxz/Drags.js'

	import Op from '$mxz/Op.svelte'

	export let id = 'editor'

	const SAY = (m, e) => console.log(`[Editor] ${m}`, e || '')
	const w = browser ? window : {}

	const isSelected = (_rowIdx, _colIdx) => (IsRowColSelected([_rowIdx,_colIdx]))



	function onColTouchdown( rowIdx ) {
		if ($_source_select && $_source_select?.uuid != rowIdx) {
			SAY(`👇 setting OpSelect ${$_source_select.uuid} to ${GetLetterFromIdx(rowIdx)} ${rowIdx}`)
			$_UNIFORMS[$_source_select.key] = rowIdx
			$_source_select = null
		}
	}

	$: (SequenceUpdatedCallback)($_SEQUENCE)

</script>
<div 
	bind:this={w[id]}
	class="flex row-flex-start-stretch ptb6 grow overflow-hidden rel w100pc">
	<div 
		style="overflow-x:auto"
		class="flex row-flex-start-stretch grow minw100pc">
		{#each $_SEQUENCE as sequence, rowIdx}

			<!-- BACKGROUND GUTTER -->



			<span

				id={ [id, rowIdx,'gutter'].join('_') }
				data-drag-type={DRAG_ACTIONS.INSERT}
				data-drag-rowIdx={ rowIdx }
				data-drag-colIdx={ 0 }
				on:drop={onElDrop}
				on:dragover={onElDragover}

				class="w2em minw2em z-index99 minh100pc h100pc t0 l0" />
			<!-- COLUMN -->

			<section 

				id={ [id, rowIdx].join('_') }
				data-drag-type={DRAG_ACTIONS.MOVE}
				data-drag-rowIdx={ rowIdx }
				data-drag-colIdx={ sequence.length - 1 }
				on:drop={onElDrop}
				on:dragover={onElDragover}
				class="channel global">

					{#each sequence as name, colIdx}

						<!-- OP -->

						<Op 
							on:drop={onElDrop}
							on:dragover={onElDragover}
							name={name.split(':')[0]}
							uuid={name.split(':')[1]}
							{rowIdx} 
							{colIdx} 
							type={TYPES.UNIT}
							index={IndexFromRowAndCol(rowIdx, colIdx)} />
					{/each}
			</section>
		{/each}

		<!-- TUNDRA TO THE RIGHT -->

		<span

			id={ [id, 'tundra'].join('_')}
			data-drag-type={DRAG_ACTIONS.APPEND}
			data-drag-rowIdx={ $_SEQUENCE.length }
			data-drag-colIdx={ 0 }
			on:drop={onElDrop}
			on:dragover={onElDragover} 
			style="padding-right:50vw"
			class="flex grow h100pc minw16em"/>
	</div>

	<!-- BIN -->

	<span 
		id="bin"
		data-drag-type={DRAG_ACTIONS.BIN}
		data-drag-rowIdx={ $_selected?.[0]?.[0] }
		data-drag-colIdx={ $_selected?.[0]?.[1] }
		on:drop={onElDrop}
		on:dragover={onElDragover} 
		class="flex row-center-center h4em abs t100pc l100pc	 border w8em fixed bg z-index99">
		BIN
	</span>
</div>