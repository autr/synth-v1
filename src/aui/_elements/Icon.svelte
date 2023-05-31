<script>
/* #HEADER */ 

	import { onMount } from 'svelte'
	import { browser } from '$app/environment'
	import { _globals } from '../Store.js'
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
	$: classes = `aui-icon aui-element ${class_}`
	// ---
	export let value = 0
	export let width = null // default width for this element
	export let height = null // default height for this element
	export let ui_rounded = [1,1,1,1] // roundedness of content box
	export let ui_outline = null
	export let ui_padding = 0.1 // padding as percentage of shortest side
	export let icon_thickness = 1 // thickness of icon shapes
	export let icon_roundness = 1 // roundness of icon shapes
	export let icon_rotate = 0 // rotate static icon position in 350deg
	export let spin_amount = 0 // spin icon on Z axis
	export let spin_finish = 1 // return to original position if spinning
	export let pulse_amount = 0 // pulse icon on Z axis
	export let pulse_speed = 0 // rate of pulsing
	export let pulse_opacity = 0 // change opacity with pulse
	export let color_invert = false // invert the icon
	export let color_blend = 0 // blend with multiply of overlay opacity

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
	import Arc from '$global/Arc.svelte'
	import { Geometry, Types } from '$global'
	import Spacer from '$global/Spacer.svelte'
	import { CalculatePixels, GetComputedVariableAsPx } from '$lib/API.js'
	
	let frame
	let spinner = 0
	function init() {

		frame = _window.requestAnimationFrame( tick )
	}
	function tick() {
		spinner += spin_amount * 10
		frame = _window.requestAnimationFrame( tick )
	}


	export function getIconNames() {
		return icons.map( i => i.name )
	}


	$: icons = (e => {

		let pad = ui_padding * 50

		const px = (GetComputedVariableAsPx(element,'--border') || 0)
		const divide = (Math.min(outer.w,outer.h) / 100)
		const size = ( px / divide ) * icon_thickness
		const half = size / 2

		const x = pad
		const y = pad
		const w = 100 - (pad*2)
		const h = 100 - (pad*2)

		const x2 = pad + w
		const y2 = pad + h

		const r = 100 - pad
		const b = 100 - pad
		const cx = 100/2
		const cy = 100/2

		const tick = {
			x: ((cx * 0.7) - half) + (pad * 0.4),
			y: ((cy * 1.4) - half) - (pad * 0.4)
		}
		const info = 0.8

		const arrows = {
			y: (cy * 1.6) + half,
			w: (w/2) + size,
			h: size,
		}


		return [
			{	
				name: 'crisscross',
				draw: [ 
					{
						component: Rect,
						props: () => ({
							x: x - (w * 0.125),
							y: cy - half,
							w: w * 1.25,
							h: size,
							rounded: 1,
							transform: 'rotate( -45 0 0 )'
						}),
					},
					{
						component: Rect,
						props: () => ({
							x: x - (w * 0.125),
							y: cy - half,
							w: w * 1.25,
							h: size,
							rounded: 1,
							transform: 'rotate( 45 0 0 )'
						}),
					}
				]
			},
			{	
				name: 'chevron',
				draw: (e => {


					const chevrons = {
						y: (y2 - size),
						w: w*0.75,
						h: size
					}


					return [ 
						{
							component: Rect,
							props: () => ({
								x: x - (w * 0.25),
								...chevrons,
								rounded: icon_roundness,
								style: `transform-origin: ${cx}px ${y2}px`,
								transform: `translate(0 ${h*-0.125}) rotate( 45 0 0 ) `
							}),
						},
						{
							component: Rect,
							props: () => ({
								x: cx,
								...chevrons,
								rounded: icon_roundness,
								style: `transform-origin: ${cx}px ${y2}px`,
								transform: `translate(0 ${h*-0.125}) rotate( -45 0 0 ) `
							}),
						},
					]
				})()
			},
			{	
				name: 'arrow',
				draw: (e => {


					const chevrons = {
						y: (y2 - size),
						w: w*0.75,
						h: size
					}

					return [ 
						{
							component: Rect,
							props: () => ({
								x: x - (w * 0.25),
								...chevrons,
								rounded: icon_roundness,
								style: `transform-origin: ${cx}px ${y2}px`,
								transform: `translate(0 0) rotate( 45 0 0 ) `
							}),
						},
						{
							component: Rect,
							props: () => ({
								x: cx,
								...chevrons,
								rounded: icon_roundness,
								style: `transform-origin: ${cx}px ${y2}px`,
								transform: `translate(0 0) rotate( -45 0 0 ) `
							}),
						},
						{
							component: Rect,
							props: () => ({
								x: cx - half,
								y: chevrons.y - (h * 0.85),
								w: size,
								h: h * 0.9,
								rounded: icon_roundness
							}),
						},
					]
				})()
			},

			{	
				name: 'ticked',
				draw: [ 
					{
						component: Rect,
						props: () => ({
							...tick,
							w: (w * 0.6) + half,
							h: size,
							style: `transform-origin: ${half}px ${half}px`,
							rounded: icon_roundness,
							transform: `rotate( -45 0 0 ) `
						}),
					},
					{
						component: Rect,
						props: () => ({
							...tick,
							w: (w * 0.3) + half,
							h: size,
							rounded: icon_roundness,
							style: `transform-origin: ${half}px ${half}px`,
							transform: `rotate( 225 0 0 ) `
						}),
					}
				]
			},
			{	
				name: 'infoalert',
				draw: [ 
					{
						component: Rect,
						props: () => ({
							x: cx - half,
							y: size + pad,
							w: size,
							h: (h * info)-(size*2),
							rounded: icon_roundness
						}),
					},
					{
						component: Rect,
						props: () => ({
							x: cx - (half * 1.5),
							y: (h * info) + pad + size,
							w: size * 1.5,
							h: size * 1.5,
							rounded: icon_roundness
						}),
					},
				]
			},
			{	
				name: 'power',
				draw: [ 
					{
						component: Arc,
						props: () => ({
							cx: cx - 0,
							cy: cy - 0,
							rx: w/2.5,
							ry: h/2.5,
							dx: (w/2.5) - size,
							dy: (h/2.5) - size,
							amount: 300,
							angle: 180,
							rounded: icon_roundness
						}),
					},
					{
						component: Rect,
						props: () => ({
							x: cx - half,
							y: cy,
							w: size,
							h: h/2.5,
							rounded: icon_roundness
						}),
					},
				]
			},
			{	
				name: 'refresh',
				draw: [ 
					{
						component: Arc,
						props: () => ({
							cx: cx - 0,
							cy: cy - 0,
							rx: w/2.5,
							ry: h/2.5,
							dx: (w/2.5) - size,
							dy: (h/2.5) - size,
							amount: 135,
							angle: 180 - 22.5,
							rounded: icon_roundness
						}),
					},
					{
						component: Arc,
						props: () => ({
							cx: cx - 0,
							cy: cy - 0,
							rx: w/2.5,
							ry: h/2.5,
							dx: (w/2.5) - size,
							dy: (h/2.5) - size,
							amount: 135,
							angle: -22.5,
							rounded: icon_roundness
						}),
					},
					// {
					// 	component: Rect,
					// 	x: cx - half,
					// 	y: cy - (w/3),
					// 	w: size,
					// 	h: h * 0.2,
					// 	rounded: icon_roundness
					// },
					// {
					// 	component: Rect,
					// 	x: cx - half,
					// 	y: cy + (w/3) - (h*0.2),
					// 	w: size,
					// 	h: h * 0.2,
					// 	rounded: icon_roundness
					// },
				]
			},
			{	
				name: 'arcspin',
				draw: [ 
					{
						component: Arc,
						props: () => ({
							cx: cx - 0,
							cy: cy - 0,
							rx: w/2,
							ry: h/2,
							dx: (w/2) - size,
							dy: (h/2) - size,
							amount: 180,
							rounded: icon_roundness
						}),
					}
				]
			},
			{	
				name: 'clock',
				draw: [ 
					{
						component: Rect,
						props: () => ({
							x: cx - half,
							y: y,
							w: size,
							h: h/2,
							rounded: icon_roundness,
							style: `transform-origin: 50% 100%`,
							transform: `rotate( 90 0 0 )`
						}),
					},
					{
						component: Rect,
						props: () => ({
							x: cx - half,
							y: y,
							w: size,
							h: h/2,
							rounded: icon_roundness,
							style: `transform-origin: 50% 100%`,
							transform: `rotate( 90 0 0 )`
						}),
					}
				]
			}
		]


	})(value)

	$: group = {
		transform: `rotate( ${icon_rotate + spinner} 0 0 )`
	}

	$: backgroundRect = {
		class: 'ui-background',
		rounded: ui_rounded
	}
	$: backgroundOutline = {
		...backgroundRect,
		class: 'ui-outline',
		outline: ui_outline
	}

	$: focused = false

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


	<!-- <Spacer canvas={true} /> -->
	<Svg
		class="a-{icons?.[value]?.name} a-svg {class_}" 
		bind:element={element}>
		{#if ui_outline} <Rect {...backgroundOutline} /> {/if}
		<g {...group}>
			{#each icons[value]?.draw || []  as o}
				<svelte:component
					this={o.component}
					{...o.props()}
					nonScalingStroke={true}
					class="a-path v-graphic" />
			{/each}
		</g>
	</Svg>


<!-- #CLOSE --> 

</span>
<!-- /CLOSE -->
		