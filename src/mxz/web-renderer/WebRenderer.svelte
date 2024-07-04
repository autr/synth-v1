<script>
	import { browser } from '$app/environment'
	import ISFRenderer from './ISFRenderer.js'
	import { onMount, onDestroy } from 'svelte'
	import { _popup_canvas, _recompile, _fullscreen, _SOURCES, _DIMENSIONS, _UNIFORMS, _PREVIEW, _PROJECTION, _AUTOWB } from '$mxz/store.js'


	import Slider from '$aui/_elements/Slider.svelte'
	import { COMPILER_MODES } from '$mxz/defs.js'
	import { compile, ALL } from '$mxz/compiler'
	import { VTX_DEFAULT } from '$mxz/compiler/Vertex.js'
	import { togglePopup } from '$mxz/local/Popup.js'
	import { GetLetterFromIdx, ClearUpUniforms, UuidToInt } from '$mxz/API.js'
	import canvasRecord from 'canvas-record'

	export let width = 320
	export let preview
	export let key
	export let capture = false
	export let fullscreen = false
	export let id



	// ---
	let style_ = ""
	export { style_ as style }
	let class_ = ""
	export { class_ as class }
	$: classes = ""
	// ---

	const w = browser ? window : {}
	let localCanvas, recorder

	const SAY = (m, e) => console.log(`[Renderer] ${m}`, e || '')
	let inited = false

	if (import.meta.hot) import.meta.hot.on('content-update', e => {
		console.log('HOT UPDATE')
	})

	const wait = ms => (new Promise( res => setTimeout(res, ms)))

	let remoteCanvas
	function getCurrentCanvas() {
		if ($_popup_canvas) {
			if (!remoteCanvas) remoteCanvas = $_popup_canvas.document.getElementById('canvas')
			return remoteCanvas
		} else {
			return localCanvas
		}
	}

	onDestroy( async e => {
		if ($_popup_canvas) {
			await $_popup_canvas.close()
			$_popup_canvas = null
		}
	})

	let TIMEOUT

	function recompile(o) {
		if ($_recompile == COMPILER_MODES.COMPILE && browser ) {
			if (TIMEOUT) clearTimeout(TIMEOUT)
			TIMEOUT = setTimeout( e => {
				SAY(`🏞 recompiling`)
				w.requestAnimationFrame( async e => {

					const canvas = getCurrentCanvas()
					if (!recorder) recorder = canvasRecord(canvas, {
						recorderOptions: {
							audioBitsPerSecond: 128000, 
							videoBitsPerSecond: 2500000 * 10
						}
					})
					if (!w.RNDRS) w.RNDRS = {}
					const GL = canvas.getContext('webgl2', {
						preserveDrawingBuffer: true
					})
					console.log('⛩️ context', GL)
					w.RNDRS[key] = new ISFRenderer(GL)
					w.ISF = compile()
					w.VTX = `// hello world?`
					w.RNDRS[key].loadSource(w.ISF, VTX_DEFAULT)

					const el = document.getElementById('ISF')
					if (el) el.innerText = w.RNDRS[key].parser.fragmentShader
					$_UNIFORMS = {...$_UNIFORMS}
					$_recompile = COMPILER_MODES.DONE

					if (!inited) {

						inited = true
					}

				})

			},1)
		}
	}
	_recompile.subscribe(recompile)

	let lastTime
	let fps = 30
	let lastAvrLum = 0
	const animate = e => {

		const t = (new Date())
		if (!lastTime) lastTime = t
		const sm = 0.98
		const neu = t - lastTime

		fps = (fps * sm) + ( neu  * (1-sm) )
		try {

			if (w.RNDRS?.[key]) {
				const c = getCurrentCanvas()
				const gl = c.getContext('webgl2')
				w.RNDRS[key].draw(c)

				// ====== LUMINANCE ======

				let width = gl.drawingBufferWidth;
				let height = gl.drawingBufferHeight;
				let pixels = new Uint8Array(width * height * 4);
				gl.readPixels(0, 0, width, height, gl.RGBA, gl.UNSIGNED_BYTE, pixels);

				let totalLuminance = 0;
					for (let i = 0; i < pixels.length; i += 4) {
					let r = pixels[i];
					let g = pixels[i + 1];
					let b = pixels[i + 2];
					let luminance = 0.299 * r + 0.587 * g + 0.114 * b;
					totalLuminance += luminance;
				}

				const avrLum = totalLuminance / (width * height);
				const ideal = $_AUTOWB.ideal
				$_AUTOWB.exp += ( ideal - avrLum );
				$_AUTOWB.luma = avrLum;
				lastAvrLum = avrLum;

			}
		} catch(err) {
			console.log('❌ renderer error:', err.message)
			throw err
		}
		lastTime = (new Date())
		requestAnimationFrame(animate)
	}

	let numeric
	onMount(async e => {
		storeWindowSize()
		animate()
	})

	const date = () => ((new Date()).toISOString())

	function captureImage() {

		EXPORTING = true

		w.requestAnimationFrame( async e => {


			const temp = document.createElement('a')
			const { offsetHeight, offsetWidth } = localCanvas
			console.log( '💾 saving from canvas:', localCanvas.width, localCanvas.height, 'scaled as:', offsetWidth, offsetHeight, 'with store dimensions:', $_DIMENSIONS )
			temp.setAttribute('download', `synth.v1.${date()}.png`)
			const url = (await localCanvas.toDataURL('image/png',1)).replace(/^data:image\/png/,'data:application/octet-stream')
			temp.setAttribute('href', url)
			temp.click()

			EXPORTING = false
		})
	}

	if (browser) window.captureImage = captureImage

	let EXPORTING = true
	let RECORDING = false

	function toggleVideoRecord() {
		RECORDING = !RECORDING
		if (RECORDING) {
			recorder.start()
		} else {
			recorder.stop()
			recorder.dispose()
		}
		window.recorder = recorder
	}

	$: canvasTransform = $_fullscreen ? `position:fixed;transform:scale(${innerWidth/$_DIMENSIONS.width},${innerHeight/$_DIMENSIONS.height});` : ``


	let innerWidth, innerHeight
	function storeWindowSize() {
		innerWidth = w.innerWidth
		innerHeight = w.innerHeight
	}


export let ctrlPoints = [
	[0, 0],
	[0, 0],
	[0, 0],
	[0, 0]
]

const defaultMatrix = [
	[ 0, 0 ],
	[ 0, 1 ],
	[ 1, 0 ],
	[ 1, 1 ]
]

let containerEl
function getMatrix3d(ctrlPoints, dim, el, fs) {
	if (!browser || !$_DIMENSIONS || !el) return {
		from: [],
		to: [],
		matrix: []
	}



	const A = []; // 8x8
	const B = []; // 8x1

	let from = []
	let to = []

	const width = $_fullscreen ? window.innerWidth : el.offsetWidth
	const height = $_fullscreen ? window.innerHeight : el.offsetHeight

	for (let i = 0; i < ctrlPoints.length; i++) {
		to.push([
			(defaultMatrix[i][0] + ctrlPoints[i][0]) * width,
			(defaultMatrix[i][1] + ctrlPoints[i][1]) * height
		])
		from.push([
			(defaultMatrix[i][0]) * width,
			(defaultMatrix[i][1]) * height
		])
	}

	for (let i = 0; i < 4; i++) {
		A.push([
			from[i][0],
			from[i][1],
			1,
			0,
			0,
			0,
			-from[i][0] * to[i][0],
			-from[i][1] * to[i][0]
		]);

		A.push([
			0,
			0,
			0,
			from[i][0],
			from[i][1],
			1,
			-from[i][0] * to[i][1],
			-from[i][1] * to[i][1]
		]);

		B.push(to[i][0]);
		B.push(to[i][1]);
	}

	const h = window.numeric.solve(A, B)

	const H = [
		[h[0], h[1], 0, h[2]],
		[h[3], h[4], 0, h[5]],
		[0, 0, 1, 0],
		[h[6], h[7], 0, 1]
	]
	

	let k, matrix
	matrix = []
	for (let i = k = 0; k < 4; i = ++k) {
		matrix.push((function() {
			var l, matrix1
			matrix1 = []
			for (let j = l = 0; l < 4; j = ++l) {
				matrix1.push(H[j][i].toFixed(20))
			}
			return matrix1
		})());
	}
	const matrix3d = `matrix3d(${matrix.join(',')})`
	return { from, to, matrix, matrix3d };
}

$: deform = getMatrix3d(ctrlPoints, $_DIMENSIONS, containerEl, $_fullscreen);


const ref = {
	translate: {
		unit: '%',
		min: -15,
		max: 15
	},
	rotate: {
		unit: 'deg',
		min: -15,
		max: 15
	},
	scale: {
		unit: ' ',
		min: 0.5,
		max: 1
	},
	skew: {
		unit: 'deg',
		min: -15,
		max: 15
	}
}

function getTransformations( store ) {

	let transform = ''
	for (const [name,arr] of Object.entries($_PROJECTION)) {
		let idx = 0
		const ch = ['X','Y','Z']
		transform += `${arr.map(num=>{
			let char = ref?.[name]?.unit ? ch[idx] : ''
			idx += 1
			return `${name}${char}( ${num||0}${ref?.[name]?.unit || ''} )`
		}).join(' ')} `
	}
	return transform
}

</script>

<svelte:window on:resize={ storeWindowSize } />

<div 
	class="renderer bb {class_}"
	style="height: auto;min-width:{width}px;max-width:{width}px;">

	<div 
		bind:this={containerEl}
		class:fixed={$_fullscreen}
		style="top:0px;left:0px;background:black;z-index: 999999999"
		class="rel t0pc l0pc w100pc h100pc overflow-hidden bt">
		<canvas
			class="w100pc h100pc"
			width={$_DIMENSIONS.width} 
			height={$_DIMENSIONS.height}  />

		<canvas 
			{id}
			class="w100pc h100pc fill"
			style="transform:{getTransformations($_PROJECTION)}"
			bind:this={localCanvas} 
			width={$_DIMENSIONS.width} 
			height={$_DIMENSIONS.height} />
	</div>
	<div 
		style="background: var(--blue5-0)"
		class="actions rel z-index99 bt pop">
		<button 
			class="pop pointer f0 br"
			on:click={togglePopup}>
			Popup
		</button>
		<button 
			class="pop pointer f0 br"
			on:click={captureImage}>
			Grab
		</button>
		<button 
			class="pop pointer f0 br"
			on:click={e => $_fullscreen = !$_fullscreen}>
			Fullscreen 
		</button>
		<button 
			class="pop pointer f0 br"
			class:active={RECORDING}
			on:click={toggleVideoRecord}>
			{ RECORDING ? 'Recording...' : 'Record' }
		</button>
		<span class="fps f0" style="width:32px">{(1000/fps).toFixed(0)}</span>
	</div>
	<div 
		class="flex column-stretch-flex-start bt pop" 
		style="background: var(--blue5-0);z-index:99999">

		<div class="pop bg4 p0-8">
			<div class="flex wrap grow w100pc none">
				{#each ctrlPoints as value,key }
					<div class="maxw50pc grow">
						<!-- <label>{key}</label> -->
						<Slider
							bind:value={ctrlPoints[key][0]}
							min={-1}
							max={1}
							step={0.001} />
						<Slider
							bind:value={ctrlPoints[key][1]}
							min={-1}
							max={1}
							step={0.001} />
					</div>
				{/each}
			</div>
			<div>
				<div class="mb1">
					<span class="bb">AutoWB Tool</span>
				</div>
				<!-- <div>exp: {$_AUTOWB.exp}</div>
				<div>luma: {$_AUTOWB.luma}</div> -->
				<div class="row">
					<div class="pb0-2">Speed</div>
					<Slider
						bind:value={$_AUTOWB.speed}
						min={0}
						max={1}
						step={0.01} />
				</div>
				<div class="row">
					<div class="pb0-2">Destination</div>
					<Slider
						bind:value={$_AUTOWB.ideal}
						min={0}
						max={255}
						step={1} />
				</div>
			</div>

		</div>

		<div class="pop bg4 p0-8 bt">
			<div class="mb1">
				<span class="bb">Output Mapping</span>
			</div>
			<div class="flex wrap grow w100pc">
				{#each Object.entries($_PROJECTION) as [key, arr]}

					<div class="maxw50pc grow">
						<div class="mb0-5">{key}</div>
						{#each arr || [] as val, i}
							<Slider
								bind:value={$_PROJECTION[key][i]}
								min={ref?.[key]?.min}
								max={ref?.[key]?.max}
								step={0.001} />

						{/each}
					</div>
				{/each}

			</div>
		</div>
	</div>
	<slot />
</div>
