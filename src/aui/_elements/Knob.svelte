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
	$: classes = `aui-knob aui-element ${class_}`
	// ---
	export let value = 0.5
	export let width = null // default width for this element
	export let height = null // default height for this element
	export let position = -1
	export let min = 0
	export let max = 1
	export let resolution = false
	export let smoothing = 0.2
	export let ui_range = 270 // set the rotational size of the knob
	export let ui_padding = 0
	export let ui_outline = null
	export let ui_rounded = true
	export let ui_thickness = 0.2 // thickness of the line
	export let track_outline = null
	export let handle_width = 0.5 // width of the handle
	export let handle_height = 0.5 // height of the handle
	export let handle_rounded = [1,1,1,1] // rounded sides of ticks
	export let handle_offset = 0 // height of the handle
	export let handle_outline = null
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
	import Numbox from '$aui/_elements/Numbox.svelte'
	import Spacer from '$global/Spacer.svelte'



	function init() {}


	let raw = 0.5


	$: MIN = ui_range/-2
	$: MAX = ui_range/2

	$: (_value => {

		raw = Geometry.Scale( value, min, max, 0, 1, true )
		let z = Geometry.Scale(raw,0,1,MIN,MAX)
		let { x, y } = Geometry.AngleXY(Types.XY(0.5,0.5),z,30)
		points = [{ x, y, z }]
	})(value)

	let points = [ Types.XYZ(0.5, 0.5, 0.5) ]

	let lastAng
	function onPointsChange( e ) {

		const scale = Geometry.Scale( e.detail[0].z, MIN, MAX, 0, 1 )
		const clamp = scale // Geometry.Clamp( scale, 0 , 1 )
		const step = ( resolution ? 1 / resolution : ( max - min ) / $_globals.resolution ) * (max-min)
		const range = max - min
		const bit = (step/(range*2)) || 0
		let neu = Geometry.Scale( clamp + bit, 0, 1, min, max )
		if (step > 0) neu -= neu%step
		if (neu != value) value = Geometry.Clamp( neu, min, max )
	}

	let pointsEl

	function onPointsDblClick( e ) {
		const ang = pointsEl.getEndpoint(0)?.z || Geometry.Scale(raw,0,1,MIN,MAX)
		const end = Geometry.Scale(ang, MIN, MAX, 0, 1)
		const bit = 1 / tick_divisions
		let neu = end + (bit/2)
		neu -= neu%bit
		const scale = Geometry.Scale( neu, 0, 1, MIN, MAX )
		pointsEl.setEndpoint(0,{x:1,y:1,z:scale})
	}


	$: padding = ui_padding * Math.min(outer.w, outer.h)
	$: minimum = (Math.min(outer.w, outer.h)) - padding
	$: CC = (minimum / 2)

	$: angle = Geometry.Scale(raw,0,1,MIN,MAX)
	$: dxdy = ( CC - (ui_thickness * CC) ) - expand // inside radius of arc
	$: radius = CC - expand
	$: expand = handle.offset < 0 || ticks.offset < 0 ? Math.abs(Math.min( handle.offset, ticks.offset ))  : 0


	$: tickCount = parseInt(tick_divisions) + 1
	$: ticks = [...Array( tickCount ).keys()].map( (idx,i) => {
		const min = Math.min(outer.w, outer.h)
		let a = (( ui_range / (tickCount - 1) ) * i) + MIN
		const w = tick_width * (CC * ui_thickness)
		const h = tick_height * (CC * ui_thickness)
		return {
			x: (CC-(w/2)) + (padding/2) || 0,
			y: (tick_offset * (CC * ui_thickness))|| 0,
			transform: `rotate(${a},0,0)`,
			w: w || 0,
			h: h || 0,
			style: "fill:pink",
			class: 'tick',
			rounded: tick_rounded
		}
	})

	$: backgroundArc = {
		class: 'a-bg-path v-area',
		angle: MIN || 0,
		amount: (MAX*2) || 0,
		cx: (CC + padding/2)|| 0,
		cy: (CC + padding/2) || 0,
		rx: radius || 0,
		ry: radius || 0,
		dx: dxdy || 0,
		dy: dxdy || 0,
		rounded: [ui_rounded,ui_rounded]
	}
	$: outlineArc = {
		...backgroundArc,
		class: 'a-outline-path v-edge',
		outline: ui_outline 
	}

	$: outline = {
		class: 'outline',
		angle: MIN || 0,
		amount: MAX*2,
		rx: radius || 0,
		ry: radius || 0,
		dx: dxdy || 0,
		dy: dxdy || 0,
		outline: 5
	}

	$: track = ( (position, raw) => {

		let ang, amount, start, end
		start = ui_rounded
		end = ui_rounded
		if (position == Types.Location.CENTER) {
			ang = Geometry.Scale(Math.min(0.5,raw),0,1,MIN,MAX)
			amount = (raw >= 0.5) ? Geometry.Scale(raw,0.5,1,0,ui_range/2) : Geometry.Scale(0.5-raw,0,1,0,ui_range)
		} else if (position == Types.Location.RIGHT) {
			ang = Geometry.Scale(raw,0,1,MIN,MAX)
			amount = Geometry.Scale(1-raw,0,1,0,ui_range)
		} else {
			ang = MIN
			amount = Geometry.Scale(raw,0,1,0,ui_range)
		}
		return { 
			angle: ang, 
			amount,
			start, 
			end
		}
	})(position, raw)


	$: trackBackground = {
		class: "track-background",
		angle: track.angle,
		amount: track.amount,
		rounded: [track.start, track.end],
		cx: (CC + padding/2)|| 0,
		cy: (CC + padding/2) || 0,
		rx: radius || 0,
		ry: radius || 0,
		dx: dxdy || 0,
		dy: dxdy || 0

	}




	$: handle = ( e => {
		const w = handle_width * (CC*ui_thickness)
		const h = handle_height * (CC*ui_thickness)
		const x = CC-(w/2)
		const y = handle_offset * CC
		const transform = `rotate(${angle},0,0)`
		return {
			x: (x + padding/2) || 0,
			y: (y + padding/2) || 0,
			w: w || 0,
			h: h || 0,
			transform,
			class: 'handle-background',
			rounded: handle_rounded
		}

	})()

	$: handleOutline = {
		...handle, 
		outline: handle_outline,
		class: 'handle-outline'
	}
	let clipPath = ''
	$: clipStyle = `clip-path:path('${clipPath}')`
	$: pointsStyle = `
		border-radius:${minimum}px;
		width:${minimum}px;
		height:${minimum}px;`

	$: svgRect = {
		width: Math.min(outer.w,outer.h) || 0,
		height: Math.min(outer.w,outer.h) || 0,
		class: 'a-arcs'
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
 
<!-- <span class="inner"> -->
	<Points 
		on:change={ onPointsChange }
		on:dblclick={onPointsDblClick}
		on:focus={e=>spanEl.focus()}
		style={pointsStyle}
		bind:this={pointsEl}
		bind:points={ points }
		{resolution} 
		immediate={true}
		preview={false}
		clamp={false}
		full_rotation={ui_range == 360}
		smoothing={smoothing}
		center={Types.XY(0.5,0.5)}>

	</Points>

	<Svg {...svgRect}>
			<Arc {...backgroundArc} />
			<clipPath>
				<Arc bind:d={clipPath} {...trackBackground} />
			</clipPath>
	</Svg>
	<span 
		style="{clipStyle};{pointsStyle}"
		class="a-wrap">
		<span 
			class="a-track v-graphic">
			<slot />
		</span>
		<Spacer canvas={1} />
	</span>


	<Svg {...svgRect}>
		
		{#if ui_outline}<Arc {...outlineArc} />{/if}

<!-- 
		{#each ticks as tick}
			<Rect {...tick} /> 
		{/each}

		<Rect {...handle} /> 
		{#if handle_outline}
			<Rect {...handleOutline} />
		{/if} -->
	</Svg>
	<span 
		style="width:{minimum/2}px;max-height:{minimum/2}px" 
		class="a-center v-reset">
		<Numbox 
			{...$$props} 
			bind:value={value}  />
	</span>

<!-- #CLOSE --> 

</span>
<!-- /CLOSE -->
		