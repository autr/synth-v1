<script>
/* #HEADER */ 

	import { onMount } from 'svelte'
	import { browser } from '$app/environment'
	import { _globals } from '../store.js'
	export let element = null

	const _window = browser ? window : {}
	export function getEl() { return element }
		// ---
	export let name = "number" // descriptive name for the ui element, ie. "opacity"
	export let id = "number" // unique id must be set automatically via sync, or user defined
	export let url = "number" // recursive url format id for automatic sync
	export let tabindex = 0 // important for accesibility
	// ---
	let style_ = ""
	export { style_ as style }
	let class_ = ""
	export { class_ as class }
	$: classes = `aui-selector aui-element ${class_}`
	// ---
	export let value = 0
	export let width = null // default width for this element
	export let height = null // default height for this element
	export let options = ["A B C D E","B C D E F","C D E F G"]

	$: size = (width?'width:'+width+';':'')+(height?'height:'+height+';':'')
	let outer = { x: 0, y: 0, w: 0, h: 0 }
	function onResize(e) {
		outer.w = e.contentRect.width
		outer.h = e.contentRect.height
	}
	onMount(() => {
		init()
		const resizeObserver = new ResizeObserver( entries => onResize(entries[0]))
		resizeObserver.observe(element)
		return () => resizeObserver.unobserve(element)
	})

/* /HEADER */
	import Svg from '$global/Svg.svelte'
	import Arc from '$global/Arc.svelte'
	import Rect from '$global/Rect.svelte'

</script>
<!-- #OPEN --> 
<span 
		{id}
		bind:this={element}
		on:focus
		on:blur
		on:click
		on:touchstart
		on:touchend
		on:touchmove
		on:touchcancel
		on:dblclick
		on:mousedown
		on:mouseup
		on:mousemove
		on:mouseout
		on:contextmenu
		class={classes}
		class:--focus={focused}
		style={size + style_}>

<!-- /OPEN -->


<div class="flex row-grow-grow  border">
	<div class="border rel h100pc grow w2em">
		<Svg class="h100pc">

			<path d="M 20 20 H 80 50 M 20 80" />
		</Svg>
	</div>
	<select bind:value={value} class="grow no-basis">
		{#each options as option, i}
			<option value={i} name={option}>
				{option}
			</option>
		{/each}
	</select>
</div>
<!-- #CLOSE --> 

</span>
<!-- /CLOSE -->
		