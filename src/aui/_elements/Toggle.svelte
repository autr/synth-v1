<script>
/* #HEADER */ 

	import { onMount } from 'svelte'
	import { browser } from '$app/environment'
	import { _globals } from '../store.js'
	export let element = null

	const _window = browser ? window : {}
	export function getEl() { return element }
		// ---
	export let name = "boolean" // descriptive name for the ui element, ie. "opacity"
	export let id = "boolean" // unique id must be set automatically via sync, or user defined
	export let url = "boolean" // recursive url format id for automatic sync
	export let tabindex = 0 // important for accesibility
	// ---
	let style_ = ""
	export { style_ as style }
	let class_ = ""
	export { class_ as class }
	$: classes = `aui-toggle aui-element ${class_}`
	// ---
	export let value = false
	export let width = null // default width for this element
	export let height = null // default height for this element
	export let safety_drag = false // simulate a smartphone unlock slider
	export let ui_rounded = 1 // roundedness of toggle
	export let ui_outline = null
	export let handle_padding = 0.1
	export let handle_outline = 0.1 // outline of toggle

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

	import Spacer from '$global/Spacer.svelte'

	function init() {
		
	}

	$: focused = inputFocus

	let innerEl, inputEl, inputFocus

	function onInputKeydown(e) {
		if (!inputFocus) return
		const { key } = e
		if (key == 'Enter') value = !value
		if ( key == 'Escape' ) inputEl.blur()
	}

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


	
	<span 
		bind:this={innerEl}
		class:--checked={value}
		class="a-outer v-area">
		<span class="a-inner v-graphic">
			<span class="a-track">
				<span class="a-handle v-edge v-handle">
					<Spacer />
				</span>
			</span>
		</span>
				<!-- <slot /> -->
		<input 
			on:focus={e => (inputFocus = true)}
			on:blur={e => (inputFocus = false)}
			on:keydown={onInputKeydown}
			bind:this={inputEl}
			on:click={e => console.log}
			type="checkbox"
			bind:checked={value} />
	</span>

<!-- #CLOSE --> 

</span>
<!-- /CLOSE -->
