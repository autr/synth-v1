<script>

	import { onMount } from 'svelte'
	import { browser } from '$app/environment'
	import { page } from '$app/stores'
	import * as blends from 'color-blend'
	import { Scale } from '$global/Geometry.js'
	import Numbox from '$aui/_elements/Numbox.svelte'

	const COLOR_NAMES = ['dark', 'orange', 'red', 'pink', 'purple', 'blue', 'teal', 'green', 'yellow', 'light']

	const HSLToRGB = (hsla, as_object) => {
		if (hsla instanceof Object) hsla = Object.values({...hsla})
		let h = hsla[0]
		let s = hsla[1]
		let l = hsla[2]
		let a = hsla[3] || 1
		s /= 100
		l /= 100
		const k = (n => ((n + h / 30) % 12))
		const angle = (s * Math.min(l, 1 - l))
		const f = (n => (l - angle * Math.max(-1, Math.min(k(n) - 3, Math.min(9 - k(n), 1)))))
		const r = 255 * f(0)
		const g = 255 * f(8)
		const b = 255 * f(4)
		if (as_object) return {r,g,b,a}
		return [r,g,b,a]
	}
	const RGBToHSL = (rgba, as_object) => {
		if (rgba instanceof Object) rgba = Object.values({...rgba})
		let r = rgba[0]
		let g = rgba[1]
		let b = rgba[2]
		let a = rgba[3] || 1
		r /= 255
		g /= 255
		b /= 255
		let ll = Math.max(r, g, b)
		let ss = ll - Math.min(r, g, b)
		let hh = (ss
			? ll === r
			? (g - b) / ss
			: ll === g
			? 2 + (b - r) / ss
			: 4 + (r - g) / ss
		: 0)
		const h = (60 * hh < 0 ? 60 * hh + 360 : 60 * hh)
		const s = (100 * (ss ? (ll <= 0.5 ? ss / (2 * ll - ss) : ss / (2 - (2 * ll - ss))) : 0))
		const l = ((100 * (2 * ll - ss)) / 2)
		if (as_object) return {h,s,l,a}
		return [h,s,l,a]
	}


	const W = browser ? window : {}
	const config = {
		count: 10,
		low: {
			hmin: 0.5,
			hmax: 0.5,
			lmin: 0.005,
			lmax: 0.2,
			smin: 0.2,
			smax: 0.1,
		},
		mid: {
			hmin: 0,
			hmax: 1,
			lmin: 0.05,
			lmax: 0.95,
			smin: 0.1,
			smax: 1,
		},
		high: {
			hmin: 0.6,
			hmax: 0.6,
			lmin: 0.4,
			lmax: 0.95,
			smin: 0.1,
			smax: 0.5,
		}
	}

	const blendsmodes = Object.keys( blends )

	function createMatrix() {
		console.log('[Colors] initing')

		let out = []

		const { mid, low, high } = config

		for (let y = 0; y < config.count; y++) {
			out[y] = []
			for (let x = 0; x < config.count ; x++) {

				let o = mid
				if (y == 0) o = low
				if (y == config.count-1) o = high

				let l = ((1/(config.count-1))*(x))
				l *= (o.lmax - o.lmin)
				l += o.lmin
				l *= 100
				if (x == 5) l *= 1.3
				if (x == 4) l *= 0.5

				let h = ((1/(config.count-2))*(y))
				h *= (o.hmax - o.hmin)
				h += o.hmin
				h += (l/100) * 0.1
				h *= 360 

				let s = ((1/(config.count-1))*(x))
				s *= (o.smax - o.smin)
				s += o.smin
				s *= 100
				if (x == 5) s *= 1.55
				if (x == 4) s *= 0.1

				const a = 1

				if (x == 0 || x == 4 || x == 5 || x == 9) {
					out[y][x] = [ h, s, l, a ]
				} else {
					out[y][x] = []
				}
			}
		}
		return out
	}

	let raw = createMatrix()
	let matrix = createMatrix()
	let colors = []


	$: (raws => {
		// console.log('???')

		colors = matrix.map( (row, y) => {
			return row.map( (hsla, x) => {

				let s, e, i_e, i_s

				for (i_e = x; i_e <= 10; i_e++) if ( matrix[y][i_e].length >= 3 ) break
				for (i_s = x; i_s > -1; i_s--) if ( matrix[y][i_s].length >= 3 ) break

				let start = [...matrix[y][i_s]]
				let end = [...matrix[y][i_e]]

				const yes = (start.length >= 3 && end.length >= 3)

				const dist = Scale(x,i_s,i_e,0,1) || 1

				if (yes) {
					start = HSLToRGB(start, true)
					end = HSLToRGB(end, true)
					end.a *= dist
					return RGBToHSL( blends.normal(start,end) )
				}

			})
		})
		const str = JSON.stringify(raw)
		console.log(raw.map(r=>r.map(a => a.map(v=> ( (parseInt(v || '___'))+'').padStart(3,'0') ).join(',')).join(' | ')).join('\n'))
		matrix = JSON.parse(str)
	})(raw)


	function HSLToCSS( arr ) {
		if (!arr) return 'transparent'
		return 'hsla('+arr.map( (v, i) => {
			return (v || 1) + (i>0&&i<3?'%':'')
		}).join(', ')+')'
	}
	function RGBToCSS( arr ) {
		if (!arr) return 'transparent'
		return 'rgba('+arr.map( (v, i) => {
			return v || 1
		}).join(', ')+')'
	}

	$: xy = (p => {
		const params = new URLSearchParams(W?.location?.search);
		return {
			x: params.get('x') || null,
			y: params.get('y') || null
		}
	})($page,raw)


	$: sass = (c => {

		let og = [`.theme`]
		let r = [ ]
		let s = [ ]



		for (let x = 0; x < config.count ; x++) {
			for (let y = 0; y < config.count; y++) {
				const color = colors[x][y]

				const name = `${x}-${y}`
				const key = COLOR_NAMES[x]

				r.push( `\t--${key}${y}: ${HSLToCSS(color)}` )
				if (y == 5) og.push(`\t--${key}: ${HSLToCSS(color)}`)

				s.push(`.theme .${key}${y}`)
				s.push(`\t--local: var(--${key}${y})`)
			}
		}

		const rules = {
			fill: 'fill',
			bg: 'background-color',
			stroke: 'stroke',
			outline: 'outline-color',
			color: 'color',
			border: 'border-color'
		}
		const pseudos = ['active','focus','hover']

		for (const rule of Object.keys(rules)) {
			s.push( `=${rule}` )
			s.push( `\t${rules[rule]}: var(--local)` )
			s.push( `.${rule}` )
			s.push( `\t${'+'}${rule}` )
		}

		// r.push(`\t--local: var(--c5)`)
		// r.push(`\t--local: var(--bg5)`)

		const o = [...og, ...r, ...s].join('\n')
		return o
	})(colors)

	let SASS = 'Copy SASS'

	async function copySass() {
		const res = await navigator.clipboard.writeText(sass)
		SASS = 'Copied!'
		console.log(sass)
		setTimeout(e => {
			SASS = 'Copy SASS'
		},1000)
	}

</script>


<div class="colors flex column-stretch-stretch">

	<div class="colormatrix flex row grow">
		<div class="matrixwrap flex column grow rel">
			<canvas width={1} height={1} class="w100pc" />
			<div class="matrix fill flex column">
				{#each colors as row,y}
					<div class="matrixrow flex row grow rel w100pc">
						<span class="pr0-1 w1em text-center">
							{y}
						</span>
						{#each row as color,x}
							<a 
								href="{W?.location?.pathname}?x={x}&y={y}"
								class="flex block rel grow p0-1">
								<span
									class="radius4em rel flex grow">
									<span 
										style="background:{HSLToCSS(colors[9-y][x])}"
										class="radius2em fill">

									</span>
									<canvas width={1} height={1} class="w100pc" />
								</span>
								{#if y == 0}
									<span class="abs text-center t100pc radius2em">
										{x}
									</span>
								{/if}
							</a>
						{/each}
					</div>
				{/each}
			</div>
		</div>
		<aside class="p1">
			<header>
				<h3 class="italic">--c{xy?.x}-{xy?.y}</h3>
				<span class="horizontal" />
				{#if matrix?.[xy?.y]?.[xy?.x] instanceof Array}
					<Numbox
						width="8em"
						bind:value={raw[9-xy.y][xy.x][0]}
						step={1}
						min={0}
						max={360} />
					<Numbox
						width="8em"
						bind:value={raw[9-xy.y][xy.x][1]}
						step={1}
						min={0}
						max={100} />
					<Numbox
						width="8em"
						bind:value={raw[9-xy.y][xy.x][2]}
						step={1}
						min={0}
						max={100} />
					<Numbox
						width="8em"
						bind:value={raw[9-xy.y][xy.x][3]}
						step={0.1}
						min={0}
						max={1} />
					<button on:click={e=>(raw[9-xy.y][xy.x] = [])}>
						CLEAR
				</button>
				{/if}
			</header>

		</aside>

	</div>

	<div 
		style="white-space: pre"
		class="grow maxh50vh pre maxw16em white-space-pre p8">
		<button on:click={copySass}>{SASS}</button>
		<!-- {@html sass} -->
	</div>
</div>