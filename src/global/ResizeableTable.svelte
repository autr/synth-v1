<script>

	/*

	[ResizeableTable]			data must be set:

	export let thead_data 		// [array:string]		keys
	export let tbody_data		// [array:anything]		data
	export let th_component		// [SvelteComponent]	<th>
	export let td_component		// [SvelteComponent]	<td>
	export let minimum_width	// [integer]			minimum width when resized
	export let data 			// [anything]			anything (passed to SvelteComponents)

	[YourCells] 				th_component & td_component must have:

	export let type 			// [string] 			receives 'thead' or 'tbody'
	export let rowIdx 			// [integer] 			index of row
	export let colIdx 			// [integer]			index of column
	export let key 				// [string]				aka thead_data[colIdx]
	export let entry 			// [object]				aka tbody_data[rowIdx]
	export let value			// [anything]			the value for the cell
	export let data 			// [anything]			misc data passed to ResizeableTable
	 
	*/

	import { onMount } from 'svelte'
	import { page } from '$app/stores'
	import { _data, _model } from '$lib/store.js'
	import { sort } from 'fast-sort'

	export let thead_data = [ 'id', 'name', 'value' ] 
	export let tbody_data = [ { id: 'A', name: 'First', value: 'foobar'} ]
	export let th_component = null
	export let td_component = null
	export let minimum_width = 80
	export let initial_widths = []
	export let data = {}

	let widthsStore
	let tableEl = null
	let inited = false
	const say = (a,b) => console.log(`[ResizeableTable] ${a}`, b || '')

	let dragData = { origin: 0, width: 0 }
	let widthsTimeout, dragTimeout

	$: href = $page.routeId
	$: storeKey = href + '_table_widths'


	onMount( loadSettings, $page)

	function loadSettings() {
		widthsStore = JSON.parse( window.localStorage.getItem( storeKey ) || '{}' )
		say('loaded from local storage', widthsStore)
		window.removeTableStorage = e => {
			window.localStorage.removeItem( storeKey )
		}
	}

	$: (_thead_data => {

		let gridCols = ''
		let i = 0
		for (const key of thead_data) {

			let width = widthsStore?.[key] || initial_widths[i]
			width = Math.abs( Math.max( minimum_width, parseInt(width,10)) )
			gridCols += width ? width+'px ' : `minmax(${minimum_width}px, 1fr) `
			i += 1
		}
		if (tableEl) {
			tableEl.style.gridTemplateColumns = gridCols
			inited = true
		}
	})( thead_data )

	function storeSettings() {

		if (widthsTimeout) clearTimeout(widthsTimeout)
		widthsTimeout = setTimeout( e => {
			say('saving to local storage', widthsStore)
			window.localStorage.setItem( storeKey , JSON.stringify(widthsStore) )
		}, 500)
	}

	function DragStart( index, screenX, offsetWidth ) {

		dragData.origin = screenX
		dragData.width = offsetWidth

	}
	function DragMove( index, screenX ) {

		if (screenX == 0) return

		if (dragTimeout) window.cancelAnimationFrame( dragTimeout )
		dragTimeout = window.requestAnimationFrame( ev => {

			const x = dragData.origin - screenX
			const w = dragData.width - x
			if (!widthsStore) widthsStore = {}
			widthsStore[ thead_data[index] ] = w
			storeSettings()
		})

	}

	const onDragStart = (e,idx) =>  DragStart( idx, e.screenX, e?.srcElement?.parentElement?.offsetWidth )
	const onDrag = (e,idx) => DragMove( idx, e.screenX )
	const onTouchStart = (e,idx) =>  DragStart( idx, e.touches?.[0]?.screenX, e?.srcElement?.parentElement?.offsetWidth )
	const onTouchMove = (e,idx) => DragMove( idx, e.touches?.[0]?.screenX )


	$: parsed_data = {
		thead: [ thead_data || [] ],
		tbody: ( tbody_data || [] ).map( entry => {
			let line = []
			for (const key of thead_data ) {
				line.push( entry[key] )
			}
			return line
		})
	}

	$: parsed_components = {
		thead: th_component,
		tbody: td_component
	}

	let triggeringEvent = false
	function passThroughEvent(name, e) {
		if (triggeringEvent) return
		triggeringEvent = true
		for (const inner of e.target?.parentElement?.children || []) {
			inner.dispatchEvent(new CustomEvent(name))
		}
		window.requestAnimationFrame( e => {
			triggeringEvent = false
		})
	}

</script>

<article bind:this={tableEl} class="table">
	{#if inited}
		{#each Object.entries( parsed_data ) as [id, lines]}
			<span class="{id}">
				{#each lines as line, rowIdx}
					<span class="tr" tabindex={rowIdx}>
						{#each line as value, colIdx}
							<span class="td">
								{#if parsed_components[id]}
									<svelte:component 
										this={ parsed_components[ id ] }
										{rowIdx}
										{colIdx}
										type={ id }
										key={thead_data[colIdx]}
										bind:value={value}
										bind:entry={ tbody_data[rowIdx] }
										bind:data={ data } />
								{:else}
									{value}
								{/if}
								{#if colIdx != line.length -1 }
									<span 
										draggable="true"
										on:click={e => passThroughEvent('click', e)}
										on:contextmenu={e => passThroughEvent('contextmenu', e)}
										on:dragstart={e => onDragStart(e,colIdx)}
										on:drag={e => onDrag(e,colIdx)}
										on:touchstart={e => onTouchStart(e,colIdx)}
										on:touchmove={e => onTouchMove(e,colIdx)}
										class="drag" />
								{/if}
							</span>
						{/each}
					</span>
				{/each}
			</span>
		{/each}
	{/if}
</article>