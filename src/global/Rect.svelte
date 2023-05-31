<script>

	import { Geometry, Types } from '$global'
	import { CalculatePixels, GetComputedVariableAsPx } from '$lib/API.js'

	let class_ = ""
	export { class_ as class } 
	let style_ = ""
	export { style_ as style }

	export let id = 'rect'
	export let x = 0
	export let y = 0
	export let w = 100
	export let h = 100
	export let rounded = true
	export let d = ''
	
	/* OVERRIDES angle / amount */
	export let from = undefined
	export let to = undefined
	export let transform = undefined
	export let mask = undefined
	export let outline = null
	export let preserveAspectRatio = undefined
	export let nonScalingStroke = false

	const anti = 0
	const adjust = 0

	$: minimum = Math.min( alias.w, alias.h )

	$: alias = {
		x: x + anti,
		y: y + anti,
		w: w - (anti*2),
		h: h - (anti*2)
	}

	function make(xx,yy,ww,hh,offset) {

		// w -= 2

		xx = alias.x + offset
		yy = alias.y + offset

		ww = alias.w - offset
		hh = alias.h - offset


		let w2 = ww / 2
		let h2 = hh / 2

		let shrink = null
		if (offset) {
			const minA = Math.min(alias.w,alias.h)
			const minB = Math.min(ww,hh)
			shrink = ((minB)/minA)
		}


		let { tl, tr, br, bl } = getRadius({width:ww,height:hh}, shrink )
		const adj = num => Math.round(num)

		// xx = adj(xx)
		// yy = adj(yy)
		// ww = adj(ww)
		// hh = adj(hh)
		// w2 = adj(w2)
		// h2 = adj(h2)
		// tl = adj(tl)
		// tr = adj(tr)
		// bl = adj(bl)
		// br = adj(br)

		const zero = 'zero'
		const one = 'one'
		return  [
			'M', xx + w2, yy ,
			'H', xx + ww - tr - xx + xx,
			'a', tr, tr, zero, zero, one, tr, tr,
			'V', yy + hh - br - yy + yy,
			'a', br, br, zero, zero, one, -br, br,
			'H', xx + bl,
			'a', bl, bl, zero, zero, one, -bl, -bl,
			'V', yy + tl,
			'a', tl, tl, zero, zero, one, tl, -tl,
			'Z'

		].map( v => {
			if (v==zero) return 0
			if (v==one) return 1
			return typeof v == 'number' ? Math.round(v) + adjust : v
		}).join(' ').replaceAll('\n', ' ').replaceAll('\t', '')
	}

	function getRadius ( override, shrink ) {

		let radius = GetComputedVariableAsPx( el, '--radius', override ) || 0

		const mult = typeof rounded == 'object' ? 0 : +rounded
		const parts = ['tl','tr','br','bl']
		const min = Math.min(override.width,override.height)/2
		let idx = 0
		let out = {}
		// console.log(mult, rounded, el)
		for (const key of parts) {
			out[key] = radius * parseFloat(rounded?.[idx] || mult)
			if (out[key] > min) out[key] = min
			out[key] *= shrink || 1
			idx += 1
		}
		return out
	}



	$: (() => {
		if (x == undefined || y == undefined || (!w || !h) || !el) return

		const px = (GetComputedVariableAsPx(el,'--border') || 0)/2
		// if (outline && !px) return

		let out = make(x,y,w,h,0)

		// console.log(out, {x,y,w,h})
		if (outline && px) {
			// console.log(outline)
			out += make(x,y,w,h,px)
		}
		d = out + ' z'
	})(x, y, w, h, rounded, outline, el)


	let el 
</script>

<path 
	{d} 
	{id}
	{preserveAspectRatio} 
	vector-effect={nonScalingStroke ? 'non-scaling-stroke' : 'none'}
	fill-rule="evenodd"
	{mask} 
	transform={transform||''}
	class={class_} 
	bind:this={el}
	style={style_} />