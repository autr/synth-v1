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
	$: classes = `aui-slider aui-element ${class_}`
	// ---
	export let value = 0.5
	export let width = null // default width for this element
	export let height = null // default height for this element
	export let position = -1
	export let min = 0
	export let max = 1
	export let resolution = false
	export let smoothing = 0.2
	export let vertical = false // rotate slider 90 degrees
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
	import Numbox from '$aui/_elements/Numbox.svelte'
	import Svg from '$global/Svg.svelte'
	import Arc from '$global/Arc.svelte'
	import Rect from '$global/Rect.svelte'

	/* replicate with knob / slider -----> */

	let raw = 0.5

	$: X = vertical ? 'y' : 'x'
	$: Y = vertical ? 'x' : 'y'
	$: W = vertical ? 'h' : 'w'
	$: H = vertical ? 'w' : 'h'

	$: outerMin = Math.min(outer[H], outer[W])

	function init() {}

	$: (_value => {
		const swap = { x: 0, y: 1 }
		raw = Geometry.Scale( value, min, max, swap[X], swap[Y] )
	})(value)


	let points = [ Types.XY(0.5, 0.5) ]
	let pointsEl

	function onPointsChange( e ) {
		const mult = (handle[W]/outer[W])/2
		const raws = {
			x: e.detail[0].x,
			y: 1 - e.detail[0].y
		}
		const scale = Geometry.Scale( raws[X], mult, 1-mult, 0, 1 )
		const clamp = Geometry.Clamp( scale, 0 , 1 )
		const range = max - min
		const step = resolution ? 1 / resolution : ( max - min ) / $_globals.resolution
		const bit = (step/(range*2)) || 0
		let neu = Geometry.Scale( clamp + bit, 0, 1, min, max )
		if (step > 0) {
			neu -= neu%step
		}
		value = neu
	}

	function onPointsDblClick( e ) {
		const { x, y } = points[0]
		const bit = 1 / tick_divisions
		const end = pointsEl.getEndpoint(0)?.[X] || raw
		let neu = end + (bit/2)
		neu -= neu%bit
		const mult = (handle[W]/outer[W])/2
		const scale = Geometry.Scale( neu, 0, 1, mult, 1-mult )
		pointsEl.setEndpoint(0,{x:scale,y:0})
	}





	$: track = ( (v,o) => {

		let out = { rounded: 0 }

		out[Y] = 0
		out[H] = inner[H] || 0

		if (position == 0) {
			out[X] = ( raw < 0.5 ? raw * inner[W] : inner[W]/2 ) || 0
			out[W] = ( raw < 0.5 ? (0.5 - raw) * inner[W] : ( raw - 0.5 ) * inner[W] ) || 0
		} else if (position == -1) {
			out[X] = 0
			out[W] = ( raw * inner[W] ) || 0
		} else if (position == 1) {
			out[X] = ( raw * inner[W] ) || 0
			out[W] = ( (1 - raw) * inner[W] ) || 0
		}


		return out

	})(raw, outer, inner)

	$: tickCount = tick_divisions + 1
	$: ticks = [...Array( tickCount ).keys()].map( (idx,i) => {
			const size = {
				w: ( tick_width * outerMin ) || 0,
				h: ( tick_height * outerMin ) || 0
			}
			let offX = (handle.w/2) - (size.w/2)
			let innerW = inner[W] - (offX * 2)
			let innerH = inner[H]
			let x = (( ( ( innerW - size[W] ) / (tickCount - 1) ) * i ) + inner[X]) || 0
			let y = ( ( outer[H]/2) - (size[H]/2) ) + ( tick_offset * size[H] ) || 0
			x += offX
			return {...size, x, y}
	})

	let clip = ''

	import Decimal from 'decimal.js'
	const precision = 3
	$: visual = parseFloat(( new Decimal(parseFloat(value) ) ).toSignificantDigits( precision ))

	const lookup = {
		x: 'offsetLeft',
		y: 'offsetTop',
		w: 'offsetWidth',
		h: 'offsetHeight'
	}

	let inited = false
	let innerEl, handleEl
	let inner = {}
	let handle = {}

	$: ( (innerEl, vert) => {

		if (!innerEl) return
		for ( const [id,name] of Object.entries(lookup) ) inner[id] = innerEl[name]
		inner.min = Math.min(inner.w,inner.h)
		if (inner.min > 0) inited = true

	})(innerEl, vertical)

	$: ( (handleEl, vert, inn) => {

		if (!handleEl) return
		for ( const [id,name] of Object.entries(lookup) ) handle[id] = handleEl[name]
		handle.min = Math.min(handle.w,handle.h)

	})(handleEl, vertical, inner)


	$: handlePos = {
		[X]: ( raw * inner[W] ) - ( handle[W] / 2 ) || 0,
		[Y]: ( 0.5 * inner[H] ) - ( handle[H] / 2 ) || 0
	}

	let inputEl

	function onFocus() {
		focused = true
	}

	let focused

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
			
		<div class="a-outer v-area">
			<Points 
				on:change={ onPointsChange }
				bind:this={pointsEl}
				on:dblclick={onPointsDblClick}
				on:focus={onFocus}
				bind:points={ points } 
				immediate={true}
				preview={false}
				smoothing={smoothing}
				clamp={false}
				center={Types.XY(0.5,0.5)} />

			<Svg class="a-svg" width={outer.w} height={outer.h}>
					
				<clipPath class="a-clip">
					<Rect {...track} bind:d={clip} />
				</clipPath>

			</Svg>
			<span 
				class:--vertical={vertical}
				class:--horizontal={!vertical}
				class="a-inner">
				<span 
					style="clip-path: path('{clip}')"
					bind:this={innerEl}
					class="a-track v-graphic">
				</span>
				<span 
					bind:this={handleEl}
					style="transform: translate( {handlePos.x}px, {handlePos.y}px)"
					class="a-handle v-edge">
				</span>
			</span>
			<input 
				class="a-input"
				type="range" 
				tabindex="-1"
				bind:value={value}
				min={min} 
				max={max} />
		</div>
		<span class="a-numbox v-value">
			<slot />
			<Numbox 
				bind:focused={focused}
				bind:value={value} 
				{min} 
				{max} />
		</span>


<!-- #CLOSE --> 

</span>
<!-- /CLOSE -->

		