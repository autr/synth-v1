<script>
	import { createEventDispatcher } from 'svelte'
	import { Geometry, Types, Objects } from '$global'

	// properties...

	let class_ = ""
	export { class_ as class }
	let style_ = ""
	export { style_ as style }

	export let points = []
	export let immediate = false
	export let rotate = 0
	export let override = {}
	export let resolution = 3840
	export let smoothing = 0.9
	export let preview = true
	export let clamp = false
	export let center = { x: 0.5, y: 0.5 }
	export let full_rotation = false
	export const getPoints = e => points

	// active fingers...

	let active = {}

	// div reference...

	let area

	// dispatch...

	const dispatch = createEventDispatcher()

	// smoothing...

	let isSmoothing = false
	let endpoints = {}
	let smoothed = {}

	export let debug = { sent: 0, skipped: 0, log: false }


	function overridePoint( idx, p ) {
		if ( override[idx] ) {
			if (override[idx].y) p.y = override[idx].y
			if (override[idx].x) p.x = override[idx].x
			if (override[idx].z) p.z = override[idx].z
		}
		return p
	} 

	function onDown( finger, e ) {


		let p = Geometry.Div2NormXYZ( e, area, rotate, center )
		const idx = Geometry.FindClosest( p, points )
		p = overridePoint( idx, p )


		log('onDown', idx)

		// if its immediate, active point is already there...

		if (immediate) p = Types.CopyXYZ( points[idx] )

		const isActive = area[idx] != undefined
		const sameFinger = (isActive) ? area[idx].finger === finger : false

		if (!isActive || (isActive && !sameFinger)) {
			active[idx] = { 
				...p, 
				finger: finger, 
				origin: Types.CopyXYZ( points[idx] )
			}
		}

		// if its immediate, trigger move and update...

		if (immediate) onMove( finger, e )

		// it is now focussed...
		dispatch('focus')
		// window.requestAnimationFrame( e => {
		// 	console.log('FOCUS?', document.activeElement)
		// })
	}


	function onMove( finger, e  ) {


		const keys = Object.keys(active)
		for (let i = 0; i < keys.length; i++ ) {
			const idx = keys[i]
			const exists = active[idx]
			if ( Types.Int(exists.finger) === Types.Int(finger) ) {
				log('onMove', idx)
				let p
				p = Geometry.Div2NormXYZ( e, area, rotate, center )
				logPoint("a:", idx, p)
				p = overridePoint( idx, p )
				logPoint("b:", idx, p)
				p = Types.XYZ( active[idx].origin.x - (active[idx].x - p.x), active[idx].origin.y - (active[idx].y - p.y), p.z )
				logPoint("c:", idx, p)
				p = (clamp) ? Geometry.ClampXY( p, 0, 1 ) : p
				logPoint("d:", idx, p)
				setEndpoint( idx, p )
			}
		}
	}

	function onUp( finger, e ) {

		const keys = Object.keys(active)
		const hadTouches = keys.length > 0
		for (let i = 0; i < keys.length; i++ ) {
			const idx = keys[i]
			if ( Types.Int(active[idx].finger) === Types.Int(finger) ) {
				log('onUp', idx)
				delete active[idx]
			}
		}
		if (Object.keys(active).length == 0 && hadTouches) dispatch( 'blur' )
	}

	export function getEndpoint( idx ) {
		return endpoints[idx]
	}

	export function setEndpoint( idx, point ) {

		if (full_rotation) {
			const a = point.z
			const b = smoothed[idx]?.z || a
			const abs = Math.abs( Math.abs(a) - Math.abs(b) )
			const nr = Math.abs( a - b )

			if ( nr > 180 || nr < -180 ) {
				const c = a - 360
				const d = a + 360
				const choice = (Math.abs(c) < Math.abs(d) ? c : d);
				console.log({a,b}, { choice } )
				point.z = choice
			}
		}

		point = Geometry.RoundedXYZ( point, res )
		smoothed[idx] = Types.CopyXYZ(points[idx])
		endpoints[idx] = Types.CopyXYZ(point)
		logPoint('setEndpoint', idx, point) 
		if (!isSmoothing) {
			window.requestAnimationFrame(smooth)
			debug.sent = 0
			debug.skipped = 0
		}
	}

	function logPoint(str, idx, p) {
		if (debug.log) console.log(str, idx, p)
		// if (debug.log) console.log(str, Types.Float(p, 2), idx, (points.length == 2) ? `${Types.Float(points[0].x,2)}/${Types.Float(points[1].x,2)}/${Types.Float(points[1].z,2)}` : '' )
	}
	function log(str, idx) {
		if (debug.log) {
			console.log(`${str}`, (idx) ? idx : '', (points.length == 2) ? `${Types.Float(points[0].x,2)}/${Types.Float(points[1].x,2)}/${Types.Float(points[1].z,2)}` : '')
		}
	}

	function setPoint( idx, p ) {

		points[idx] = Types.CopyXYZ(p);
	}


	$: res = resolution || 1024

	function smooth() {

		const keys = Object.keys(endpoints)
		let cont = false
		for (let i = 0; i < keys.length; i++) {
			const idx = keys[i]

			const oldSmooth = Types.CopyXYZ( smoothed[idx] )
			smoothed[idx] = Geometry.BlendXYZ( smoothed[idx], endpoints[idx], smoothing)

			if (smoothed[idx].z > 180) {
				smoothed[idx].z -= 360
				endpoints[idx].z -= 360
			}
			if (smoothed[idx].z < -180) {
				smoothed[idx].z += 360
				endpoints[idx].z += 360
			}

			if (!cont) cont = !Geometry.CompareXY( smoothed[idx], endpoints[idx], res)
			if (!Geometry.CompareXY( smoothed[idx], oldSmooth, res)) {
				setPoint(idx, Geometry.RoundedXYZ(smoothed[idx], res) )
				dispatch('change', smoothed)
				debug.sent += 1
			} else {
				debug.skipped += 1
			}
		}



		if (cont) {
			isSmoothing = true
			window.requestAnimationFrame(smooth)
		} else {
			isSmoothing = false
			endpoints = {}
		}
	}


	let eventHandlers = {
		areaTouchStart: e => {
			log('areaTouchStart')
			for (let [idx, finger] of Object.entries(e.touches)) {
				onDown( parseInt(idx), e.touches[idx] )
			}
			console.log('preventDefault')
			e.preventDefault()
		},

		areaContextMenu: e => {
			log('contextMenu')

		},

		areaMouseDown: e => {
			if (e.which != 1) return
			log('areaMouseDown')
			onDown( 0, e )
		},

		windowMouseMove: e => {
			if (Objects.isEmptyObject(active)) return
			log('windowMouseMove')
			onMove( 0, e )
		},
		windowTouchMove: e => {

			if (Objects.isEmptyObject(active)) return
			log('windowTouchMove');


			const touchKeys = Object.keys(e.touches)
			const activeKeys = Object.keys(active)

			for (let [key, touch] of Object.entries(active)) {
				if ( e.touches[touch.finger] ) {
					onMove( touch.finger, e.touches[touch.finger] )
				}
			}
		},
		windowMouseUp: e => {
			if (Objects.isEmptyObject(active)) return
			log('windowMouseUp')
			onUp(0, e)
		},
		windowTouchUp: e => {

			if (Objects.isEmptyObject(active)) return
			log('windowTouchUp')

			// returns an array of existing touches (which are filtered)...

			const touchKeys = Object.keys(e.touches)
			const activeKeys = Object.keys(active)

			for (let i = 0; i < activeKeys.length; i++) {
				const idx = activeKeys[i]
				const finger = active[idx].finger
				if ( touchKeys.indexOf(finger) == -1) {

					// this touch has disappeared, so trigger default onUp...

					onUp(finger)
				}
			}
			console.log('preventDefault')
			e.preventDefault()
		}
	}

</script>

<svelte:window
	on:mousemove={eventHandlers.windowMouseMove}
	on:mouseup={eventHandlers.windowMouseUp}
	on:touchmove={eventHandlers.windowTouchMove}
	on:touchend={eventHandlers.windowTouchUp}
	/>
<span 
	bind:this={area}
	on:dblclick
	on:mousedown={eventHandlers.areaMouseDown}
	on:touchstart={eventHandlers.areaTouchStart}
	on:contextmenu={eventHandlers.areaContextMenu}
	on:drag={ e => e.preventDefault() }
	style={style_}
	class="aui-points {class_}">
	{#if preview}
		{#each points as p}
			<span 
				class="dot fill" 
				style="transform: translate({p.x*100}%, {p.y*100}%); margin-left:-0.5em;margin-top:-0.5em">
				<span 
					class="block filled w1em h1em radius1em" />
			</span>
			<span 
				class="angle fill flex row-center-center" 
				style="transform: rotateZ({p.z-90}deg)">
				<span 
					class="block filled w100pc ptb0-1 radius1em" />
			</span>
		{/each}
	{/if}
	<slot />
</span>