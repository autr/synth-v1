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
	$: classes = `aui-numbox aui-element ${class_}`
	// ---
	export let value = 0.5
	export let width = null // default width for this element
	export let height = null // default height for this element
	export let min = null
	export let max = null
	export let step = null // step of numbox
	export let sensitivity = 0.5 // sensitivity to dragging motion
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

	import { Geometry, Types } from '$global'
	import Icon from '$aui/_elements/Icon.svelte'
	import Spacer from '$global/Spacer.svelte'
	import Svg from '$global/Svg.svelte'
	import Rect from '$global/Rect.svelte'
	import Decimal from 'decimal.js'


	const DEBUG = true
	const SAY = (a,b,c) => (DEBUG ? console.log(`[Numbox.svelte] ${a}`,b||'',c||'') : null)

	let raw = value
	let o = {
		origin: null,
		drag: null,
		dist: null,
		direction: null,
		focused: null,
		ref: null,
		change: null
	}

	$: hasRange = min != undefined && max != undefined && max > min

	function clear() {
		window.cancelAnimationFrame( o.ref )
		for (const [key,v] of Object.entries(o || {})) o[key] = null
		o = {...o}
		raw = getSignificantDigits( value )
		SAY('cleared object', o)
	}

	const defaults = {
		minDistance: 3, // min scroll distance in px
		step: 0.1, // default increment
		sensitivity: 0.8, // scale sensitivity
		maxDistance: 100, // dragging
		maxExp: 1, // dragging
		totalSteps: 100, // if no min or max	
		pace: 60, // speed of press increment
		gap: 600, // gap before increment
		precision: 4 // default precision decimals
	}


	const setPrecisionFromMinMax = ( e => {
		if (min != undefined || max != undefined) {

			let precision = defaults.precision
			let pmin = Math.abs(min||0)
			let pmax = Math.abs(max||0)
			 pmin = (new Decimal( pmin ) ).precision()
			 pmax = (new Decimal( pmax ) ).precision()
			PRECISION = Math.max( pmin, pmax )
			Decimal.set({precision: PRECISION})
			// SAY(`set precision from min max to ${PRECISION}`)
		}
	})

	function getSignificantDigits( v, offset ) {
		const precision = Math.max( ( new Decimal( STEP ) ).precision( ), PRECISION )
		return parseFloat(( new Decimal(parseFloat(v) ) ).toSignificantDigits( precision + (offset || 0) ))
	}

	function setPrecisionFromValueDecimals() {
		const num = Number( String(value || 0).split('').map( l => l == '0' ? '1' : l).join('') )
		PRECISION = (new Decimal( num ) ).precision()
		Decimal.set({precision: PRECISION})
	}

	function setPrecisionFromValues() {

		let _raw = Math.abs( raw || 0 )
		let _value = Math.abs( value || 0 )

		// plus 1 to avoid sub 1 precision errors

		if (_raw < 1) _raw += 1
		if (_value < 1) _value += 1

		const rawPrec = (new Decimal( _raw ) ).precision()
		const valPrec = (new Decimal( _value ) ).precision()

		PRECISION = Math.max( rawPrec, valPrec )
		Decimal.set({precision: PRECISION})
		// SAY(`set precision from values to ${PRECISION}`)
	}

	const setStepAndPrecision = (e => {
		let precision = PRECISION
		if (step) {
			STEP = step
			// SAY(`set step to ${STEP} to property step`)
		} else if (max != undefined && min != undefined) {
			STEP = ((max - min)/defaults.totalSteps)
			// SAY(`set step to ${STEP} from min max`)
		} else if (value == undefined) {
			STEP = defaults.step
			// SAY(`set step to ${STEP} default`)
		} else {

			let num = String(value).replace('-','').split('')

			let incr = []
			precision -= 1
			for (let i = 0; i < Math.max( num.length, PRECISION ); i++) {

				if (num[i] == '.') {
					incr.push('.')
					precision += 1
				} else if ( i == precision  ) {
					incr.push('1')
				} else {
					incr.push('0')
				}
			}

			let out = Number(incr.join(''))
			STEP = out
			// SAY(`set step to ${STEP} from precision`)
			// console.log(out, incr, precision)
		}
	})

	let PRECISION = defaults.precision
	let STEP = defaults.step

	function init() {

		setPrecisionFromValues()
		setPrecisionFromMinMax()
		setStepAndPrecision()
		
	}


	function adjustValue( amount ) {
		let neu = getSignificantDigits( value + amount, 1 )
		raw = neu
		value = neu
		setPrecisionFromValues()
		raw = getSignificantDigits( raw )
		value = getSignificantDigits( value )
	}

	let clock, timestamp
	function tick() {

		if (o.origin != null && o.dist != null && !inputFocus) {

			SAY('⏰ tick:', {o, raw, value})

			const range = hasRange ? max - min : 1
			const { minDistance, maxDistance, maxExp } = defaults
			const distpx = Math.max(Math.abs(o.dist.y), minDistance)
			const exp = (distpx/(maxDistance*2)) * sensitivity//, maxExp )
			const distexp = Math.pow( distpx, 1 + exp )
			let dist = Geometry.Scale( distexp, minDistance, maxDistance, 0, STEP )

			o.direction = o.dist.y != 0 ? ( o.dist.y > 0 ? -1 : 1 ) : false

			if (o.dist.y < 0) dist *= -1

			raw += dist * sensitivity * defaults.sensitivity
			value = getSignificantDigits( raw - ((raw%STEP) || 0 ), 1 )
			setPrecisionFromValueDecimals()

			let beep
			if (value < min && min != null ) beep = raw = value = min
			if (value > max && max != null ) beep = raw = value = max

			if (beep) SAY('✅ tick -> beep:', {o, raw, value})

		}

		const up = roll?.up?.matches ? roll.down.matches(':active') : null
		const down = roll?.up?.matches ? roll.up.matches(':active') : null

		const { pace, gap } = defaults
		const clck = Math.round( ((new Date())%pace)/pace )
		const elapsed = (new Date()) - timestamp

		if (clck != clock && (up || down) && elapsed > gap) {
			clock = clck
			if (up) adjustValue( STEP )
			if (down) adjustValue( -STEP )
			SAY('🕰 tick -> adjust value:', {o, raw, value})
		}

		if (o.ref) window.cancelAnimationFrame(o.ref)
		o.ref = window.requestAnimationFrame( tick )
	}


	let inputEl, outerEl

	$: visual = isNaN(value) ? null : getSignificantDigits( value, 0, PRECISION )
	$: minimum = Math.min(outer.w,outer.h)


	let roll = {}


	function onKeyAction(key, e) {
		if (key == 'ArrowUp' || key == 'ArrowDown') {
			if (key == 'ArrowUp') adjustValue( STEP )
			if (key == 'ArrowDown') adjustValue( -STEP )
			e.preventDefault()
			e.stopPropagation()
			SAY(`🎹 ArrowUp / ArrowDown`)
		} else if (key == 'Enter' || key == 'Escape') {
			document.activeElement.blur()

			e.preventDefault()
			e.stopPropagation()
			SAY(`🎹 Enter / Escape`)
		}
	}
	const events = {
		touchdown: e => {


			outerEl.focus()

			let { pageX, pageY } = e
			if (e.touches) {
				o.identifier = e.touches?.[0]?.identifier
				pageX = e.touches[0].pageX
				pageY = e.touches[0].pageY
			}
			o.origin = { x: pageX, y: pageY }
			o.direction = false

			o.ref = window.requestAnimationFrame( tick )

			const { activeElement } = document
			SAY('touchdown:', {o, activeElement})
			if (!inputFocus && activeElement != roll.up && activeElement != roll.down ) {
				SAY('✅ touchdown:', {o, activeElement})
				element.focus()
				timestamp = new Date()
				e.preventDefault()
			}
			if (e.which != 1 && !e.touches) {
				SAY('right click clear')
				clear()
			}
		},
		touchend: e => {
			if (o?.origin) {
				SAY('✅ touchend:', {o, raw, value})
				clear()
			}

		},
		touchmove: e => {
			if (!o?.origin) return
			let { pageX, pageY } = e
			for ( const touch of e.touches || [] ) {
				if (touch.identifier == o.identifier) {
					pageX = touch.pageX
					pageY = touch.pageY
				}
			}

			if (o.drag) o.change = { x: o.drag.x - pageX, y: o.drag.y - pageY } // used to detect up & down
			o.drag = { x: pageX, y: pageY }
			const distX = o.origin.x - o.drag.x
			const distY = o.origin.y - o.drag.y
			o.dist = { x: distX, y: distY }
			o = {...o}
			SAY('🐍 touchmove:', {o, raw, value})

		},
		keydown: e => {
			const { key } = e
			if (focused) {
				SAY('✅ window keydown:', {o, raw, value})
				onKeyAction(key, e)
			}
		},
		inputkeydown: e => {
			const { key } = e
			if (isNaN(parseInt(key)) && key != '.') {
				onKeyAction( key, e )
				SAY('✅ input keydown:', {o, raw, value})
			}
			setPrecisionFromValues()
			setStepAndPrecision()
		},
		inputkeyup: e => {
			counter.push( e.key )
			window.requestAnimationFrame( e => {
				if (raw == null&&counter.length<=1&&counter?.[0]!='.') {
					document.activeElement.blur() 
					SAY('🚨 input keyup / counter:', {o, raw, value})
				}
			})
		},
		dblclick: e => {
			raw = getSignificantDigits( value )
			value = raw
			inputFocus = true
			focused = true
			_window.requestAnimationFrame( e => {
				inputEl.focus()
				_window.requestAnimationFrame( e => {
					inputEl.select()
					SAY('✅ dblclick -> focus -> select:', {o, raw, value})
				})
			})
		},
		focus: e => {
			inputFocus = true
			focused = true
			SAY('🔸 input focus:', {o, raw, value})
		},
		blur: e => {
			inputFocus = false
			if (!outerFocus && !inputFocus) focused = false
			value = raw
			o = {}
			SAY('🔸 input blur:', {o, raw, value})

		},
		rollup: e => {
			adjustValue(STEP)
			timestamp = new Date()
			o.direction = -1
			SAY('🔸 rollup:', {o, raw, value})
		},
		rolldown: e => {
			adjustValue(-STEP)
			timestamp = new Date()
			o.direction = 1
			SAY('🔸 rolldown:', {o, raw, value})
		},
		outerfocus: e => {
			SAY('🔺 outerfocus')
			outerFocus = true
			focused = true
		},
		outerblur: e => {
			SAY('🔺 outerblur')
			outerFocus = false
			if (!outerFocus && !inputFocus) focused = false
		}
	}

	export let focused = false

	let counter = []

	let inputFocus
	let outerFocus



</script>

<svelte:window
	on:keydown={events.keydown}

	on:mousemove={events.touchmove}
	on:mouseup={events.touchend}

	on:touchend={events.touchend}
	on:touchmove={events.touchmove} />

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
	<span class="abs t100pc none">
		OF: {outerFocus}
		<br />
		IF: {inputFocus}
		<br />
		V: {value}
		<br />
		R: {raw}
		<br />
		min: {min}
		<br />
		max: {max}
		<br />
		P: {PRECISION}
		<br />
		s: {STEP}
		<br />
		fff: {focused}
	</span>
	<span 

		on:mousedown={events.touchdown}
		on:touchstart={events.touchdown}
		on:focus={events.outerfocus}
		on:blur={events.outerblur}
		bind:this={outerEl}
		tabindex="0"
		class:--input-focus={inputFocus}
		class="a-outer v-area">

		<span class="a-slot">
			<slot />
		</span>

		<span class="a-inner v-graphic">

			<!-- Untabbable visual representation -->

			<input 
				tabindex="-1"
				placeholder="---"
				class="a-viz v-value"
				value={visual}
				type="number"/>

			<!-- Interactable representation -->

			<input 
				bind:value={raw}
				bind:this={inputEl}

				type="number"
				{min} 
				{max} 

				on:focus={events.focus}
				on:blur={events.blur}
				on:keyup={events.inputkeyup}
				on:keydown={events.inputkeydown}
				on:dblclick={events.dblclick}

				class="a-touch" />
		</span>
		<span 
			class="a-roller v-value">

			<Spacer canvas={0.5} />

			<span class="a-roll">
				<span 
					class:--active={o.direction == -1}
					class="a-up v-handle">
					<Icon 
						icon_rotate={180} 
						value={1}
						bind:element={roll.up}

						on:mousedown={events.rollup}
						on:touchstart={events.rollup}

						class="a-up v-value"/>
				</span>
				<span class="a-break v-edge" />
				<span 
					class:--active={o.direction == 1}
					class="a-down v-handle">
					<Icon 
						bind:element={roll.down}
						value={1}

						on:mousedown={events.rolldown}
						on:touchstart={events.rolldown}

						class="a-down v-value" />
				</span>
			</span>
		</span>
	</span>


<!-- #CLOSE --> 

</span>
<!-- /CLOSE -->
		