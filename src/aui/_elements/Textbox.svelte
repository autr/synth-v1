<script>
/* #HEADER */ 

	import { onMount } from 'svelte'
	import { browser } from '$app/environment'
	import { _globals } from '../Store.js'
	export let element = null

	const _window = browser ? window : {}
	export function getEl() { return element }
		// ---
	export let name = "string" // descriptive name for the ui element, ie. "opacity"
	export let id = "string" // unique id must be set automatically via sync, or user defined
	export let url = "string" // recursive url format id for automatic sync
	export let tabindex = 0 // important for accesibility
	// ---
	let style_ = ""
	export { style_ as style }
	let class_ = ""
	export { class_ as class }
	$: classes = `aui-textbox aui-element ${class_}`
	// ---
	export let value = ""
	export let width = null // default width for this element
	export let height = null // default height for this element
	export let rows = 1 // auto-switches to textarea if > 1
	export let instant = false // update value instantly on input

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
	import Rect from '$global/Rect.svelte'

	const DEBUG = true
	const SAY = (a,b,c) => (DEBUG ? console.log(`[Textbox.svelte] ${a}`,b||'',c||'') : null)

	function init() {}

	$: svg = {
		width: outer.w,
		height: outer.h
	}

	let inputEl, innerEl, inputFocus

	$: els = { inputEl, innerEl }
	const events = {
		innerEl: {
			mousedown: e => {
				SAY('➜➜ mousedown', {e,inputFocus})
				if (!inputFocus) {
					window.requestAnimationFrame( e => {

						SAY('➜➜ select all', {e,inputFocus})
						inputEl.focus()
						inputEl.setSelectionRange(0,value.length)
					})
					e.preventDefault()
				}

			},
			dblclick: e => {
				SAY('➜ dblclick', {e,inputFocus})

			},
		},
		inputEl: {
			focus: e => {
				SAY('➜ focus', {e,inputFocus})
				inputFocus = true
				counter = 0

			},
			blur: e => {
				SAY('➜ blur', {e,inputFocus})
				inputFocus = false

			},
			click: e => {
				SAY('➜ click', {e,inputFocus})
				e.preventDefault()

			},
			keydown: e => {
				SAY('➜ keydown', {e,inputFocus})
				counter += 1
				const { key } = e 
				if (rows == 1 && key == 'Enter') {
					inputEl.blur()
					SAY(`✅ keydown / blurred`)
				}
				if (key == 'Escape') inputEl.blur()
				window.requestAnimationFrame( e => {
					if ((value == '' || value == null)&&counter<=1) inputEl.blur() 
				})

			}
		}
	}

	let counter = 0

	$: (els => {
		const lookup = {
			mousedown: 'touchstart',
			mousemove: 'touchmove',
			mouseup: 'touchend'
		}

		for (const [elName,list] of Object.entries(events)) {
			const el = els[elName]
			if (el) {

				// SAY('binding input element inputEvents', el)
				for (const [name,cb] of Object.entries(events[elName])) {
					el.removeEventListener(name,cb)
					el.addEventListener(name,cb)
					if (lookup[name]) {
						el.removeEventListener(lookup[name],cb)
						el.addEventListener(lookup[name],cb)
					}
				}
			}
		}
	})(els)

	$: focused = inputFocus

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
		class="a-outer v-area">
		<span class="a-slot">
			<slot />
		</span>
		<span class="a-inner v-graphic">
			{#if rows > 1}
				<textarea 
					placeholder="---"
					spellcheck={false} 
					class="v-value"
					bind:value={value}
					bind:this={inputEl}
					{rows} />
			{:else}
				<input 
					placeholder="---"
					spellcheck={false}
					class="v-value"
					bind:value={value}
					bind:this={inputEl}
					type="text" />
			{/if}
		</span>
	</span>
<!-- #CLOSE --> 

</span>
<!-- /CLOSE -->
		