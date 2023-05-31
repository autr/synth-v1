<script>

	import { Geometry, Types } from '$global'
	import { CalculatePixels, GetComputedVariableAsPx } from '$lib/API.js'

	let class_ = ""
	export { class_ as class } 
	let style_ = ""
	export { style_ as style }

	export let id = 'arc'
	export let cx = 50
	export let cy = 50
	export let rx = 50
	export let ry = 50
	export let dx = 40
	export let dy = 40
	export let angle = 0 // -360 to 360
	export let amount = 0 // -360 to 360
	export let rounded = 0.5
	export let outline = 0
	export let preserveAspectRatio = undefined
	export let d = ''
	
	/* OVERRIDES angle / amount */

	export let from = undefined
	export let to = undefined

	let points = {}

	function make(cx, cy, rx, ry, dx, dy, angle, amount, from, to, off) {

		if (from != undefined && to != undefined) {
			angle = from
			amount = to
			console.log('ARC TODO - finish this for range slider')
		}

		// if (angle < 0) angle += 360

		if (amount%360 == 0) amount = 359.99999
		
		// 0 degrees, no path

		if (!amount) {
			console.warn('[Arc] 🚨 no cx / cy', {cx, cy, rx, ry, dx, dy, angle, amount, from, to, off})
			return `M${cx} ${cy}`
		}
		
		// mod angles to 360 degrees
		angle %= 360
		amount %= 360
		
		// Make angle positive to simplify large arc flag
		if (amount < 0) {
			amount += 360
		}
		
		// Convert degrees to radians
		let a1 = angle * Math.PI / 180
		let a2 = (angle + amount) * Math.PI / 180
		
		// Calculate angle and amount coords for arc. Starts at 12 o'clock

		const tx = ((rx-dx)*0.5)
		const ty = ((ry-dy)*0.5)

		points = {
			ol: [
				cx + rx * Math.sin(a1), // outer left x
				cy - ry * Math.cos(a1), // outer left y
			],
			or: [
				cx + rx * Math.sin(a2), // outer right x  
				cy - ry * Math.cos(a2), // outer right y
			],
			il: [
				cx + dx * Math.sin(a1), // inner left x
				cy - dy * Math.cos(a1), // inner left y
			],
			ir: [
				cx + dx * Math.sin(a2), // inner right x
				cy - dy * Math.cos(a2), // inner right y
			],
			ml: [
				cx + (dx+((rx-dx)/2)) * Math.sin(a1), // mid left x
				cy - (dy+((ry-dy)/2)) * Math.sin(a1), // med left y
			],
			mr: [
				cx + (dx+tx) * Math.sin(a1), // mid left x
				cy - (dy+ty) * Math.sin(a1), // med left y
			]
		}

		const { ol, or, il, ir, ml, mr } = points
 
		const start = rounded?.[0] || rounded > 0 ? `A ${tx} ${ty} 0 1 1` : 'L'
		const end = rounded?.[1] || rounded > 0 ? `A ${tx} ${ty} 0 1 1` : 'L'

		let largeArc = amount > 180 ? 1 : 0
		return `
			M ${ol[0]} ${ol[1]}
			A ${rx} ${ry } 0 ${largeArc} 1 ${or[0]} ${or[1]}
			${start} ${ir[0]} ${ir[1]}
			A ${dx} ${dy} 0 ${largeArc} 0 ${il.join(' ')}
			${end} ${ol.join(' ')}`
			// L ${x1} ${y1}z` 


			// L ${cx} ${cy}z
	}


	$: ((cx, cy, rx, ry, dx, dy, angle, amount, from, to, o, rounded) => {

		if (!el) return
		let out = make(cx, cy, rx, ry, dx, dy, angle, amount, from, to, o, rounded)
		if (outline) {
			const px = (GetComputedVariableAsPx(el,'--borders') || 0)
			rx -= px
			ry -= px
			dx += px
			dy += px
			if (!rounded?.[0] && !rounded?.[1]) {
				angle += px
				amount -= px * 2
			}
			out += make(cx, cy, rx, ry, dx, dy, angle, amount, from, to, rounded)
		}
		if (amount == 0) return d = ''
		d = (out + ' z').replaceAll('\n', ' ').replaceAll('\t', '')
	})(cx, cy, rx, ry, dx, dy, angle, amount, from, to, outline, rounded)

	let el
		/*
		NOTE: To orient the angleing point to 3 o'clock instead of 12 o'clock,
		add 90 degrees to the angle angle, or change the code above to this...

		let x1 = cx + rx * Math.cos(a1)   
		let y1 = cy + ry * Math.sin(a1)

		let x2 = cx + rx * Math.cos(a2) 
		let y2 = cy + ry * Math.sin(a2)
		*/

		
		// Related demo using arc path
		// https://codepen.io/osublake/pen/VbWKMj/
		// if (isClosed) {
			
		// 	return `
		// 		M ${x1} ${y1}
		// 		A ${rx} ${ry} 0 1 1 ${x2} ${y2}
		// 		A ${rx} ${ry} 0 1 1 ${x1} ${y1}z`
		// }  

</script>

{#if amount != 0}
	<path 
		{d} 
		{preserveAspectRatio} 
		bind:this={el}
		fill-rule="evenodd"
		class={class_} 
		style={style_} />
{/if}

<!-- {#each Object.entries(points) as [key,p]}
	<circle id={key} cx={p[0]} cy={p[1]} r={1} />
{/each} -->
