<script>
/* #HEADER */ 

	import { onMount } from 'svelte'
	import { browser } from '$app/environment'
	import { _globals } from '../store.js'
	export let element = null

	const _window = browser ? window : {}
	export function getEl() { return element }
		// ---
	export let name = "vec2" // descriptive name for the ui element, ie. "opacity"
	export let id = "vec2" // unique id must be set automatically via sync, or user defined
	export let url = "vec2" // recursive url format id for automatic sync
	export let tabindex = 0 // important for accesibility
	// ---
	let style_ = ""
	export { style_ as style }
	let class_ = ""
	export { class_ as class }
	$: classes = `aui-joystick aui-element ${class_}`
	// ---
	export let rotate = 0
	export let value = [0,0]
	export let width = null // default width for this element
	export let height = null // default height for this element
	export let min = [0,0]
	export let max = [1,1]
	export let smoothing = 0.2
	export let spring = false // return to middle position on release
	export let ui_outline = null
	export let handle_size = 0.2 // size of the handle
	export let handle_rounded = 1 // radius of handle
	export let tick_divisions = 3 // number of visual ticks
	export let tick_width = 0.2 // width of the ticks
	export let tick_height = 0.2 // height of the ticks
	export let tick_offset = 0 // height of the ticks
	export let tick_rounded = [1,1,1,1] // rounded sides of ticks

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

	import { Geometry, Types } from '$global'
	import Points from '$global/Points.svelte'
	import Svg from '$global/Svg.svelte'
	import Arc from '$global/Arc.svelte'
	import Rect from '$global/Rect.svelte'


	function change( e ) {
		let { x, y, z } = { ...e.detail[0] }
		x *= 1 - ( handle_size / 100 )
		y *= 1 - ( handle_size / 100 )
		const angle = Geometry.AngleToVec2(Types.XY(0.5,0.5),{x,y})
		const distance = Math.min( Geometry.DistanceXY(Types.XY(0.5,0.5),{x,y}) * 2, 1)
		value = [
			angle,
			distance
		]
		// view = np
	}

	let view =  Types.XY(0.5,0.5)

	function blur(e) {
		if (spring) {
			pointsEl.setEndpoint(0, Types.XY(0.5,0.5))
		}
	}

	$: (v => {
		let np = Geometry.AngleXY({x:0,y:0},value[0],value[1]/2)
		np.x = 0.5 + np.x
		np.y = 0.5 + np.y
		points  = [ np ]
	})(value)


	let points = [ Types.XY(0.5,0.5) ]

	$: radius = 50

	$: handlePx = handle_size * 50
	$: handleHalf = handlePx / 2
	$: handleMult = 1 - ( handle_size * 0.5 )

	$: handle = {
		x: Geometry.Clamp( ( points[0].x * 100 ) - handleHalf, 0, 100 - handlePx ),
		y: Geometry.Clamp( ( points[0].y * 100 ) - handleHalf, 0, 100 - handlePx ),
		w: handlePx,
		h: handlePx,
		rounded: handle_rounded
	}

	$: minimum = Math.min(outer.w, outer.h)

	$: backgroundRect = {
		x: (handle.w / 2) + (expand / 2),
		y: (handle.h / 2) + (expand / 2),
		w: 100 - handle.w - expand,
		h: 100 - handle.h - expand,
		rounded: 1
	}

	$: backgroundOutline = {
		...backgroundRect,
		outline: ui_outline * minimum
	}

	$: expand = ticks.offset < 0 ? Math.abs(ticks.offset)  : 0

	$: ticks = {
		width: tick_width * 50,
		height: tick_height * 50,
		offset: tick_offset * 50,
		angles: [...Array( parseInt(tick_divisions) ).keys()].map( (idx,i) => {
			let a = ( 360 / (tick_divisions - 1) ) * i
			return a
		})
	}

	function init() {}

	let pointsEl

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

<!-- <div class="filled abs b100pc cp0-5 flex column">
	<span>{ handle.x }</span>
	<span>{ handle.y }</span>
	<span>{ points[0].x }</span>
	<span>{ points[0].y }</span>
</div> -->
<div class="inner">
	<Points 
		on:change={ change }
		on:blur={ blur }
		on:focus={e=>spanEl.focus()}
		bind:this={pointsEl}
		points={ points } 
		immediate={true}
		preview={false}
		smoothing={smoothing}
		clamp={false}
		center={Types.XY(0.5,0.5)}
		{rotate} />
	<Svg>
		<Rect 
			class="ui-background"
			{...backgroundRect} />
		{#if ui_outline}
			<Rect 
				class="ui-outline"
				{...backgroundOutline} />
		{/if}

		{#each ticks.angles as ta}

			<Rect 
				x={50-(ticks.width/2)}
				y={tick_offset < 0 ? tick_offset : ticks.offset}
				w={ticks.width}
				h={ticks.height}
				transform="rotate({ta},0,0)"
				rounded={tick_rounded}
				style="fill:pink"
				class="handle" /> 
		{/each}
		<Rect 
			class="handle"
			{...handle} />

	</Svg>

	<canvas 
		class={'spacer ' + classes} 
		width={1} 
		height={1} />
</div>

<!-- #CLOSE --> 

</span>
<!-- /CLOSE -->
		