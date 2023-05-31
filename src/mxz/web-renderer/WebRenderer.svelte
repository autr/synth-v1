<script>
	import { browser } from '$app/environment'
	import ISFRenderer from './ISFRenderer.js'
	import { onMount, onDestroy } from 'svelte'
	import { _popup_canvas, _recompile, _fullscreen, _SOURCES, _DIMENSIONS, _UNIFORMS, _PREVIEW } from '$mxz/Store.js'
	import { COMPILER_MODES } from '$mxz/Defs.js'
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
	const animate = e => {

		const t = (new Date())
		if (!lastTime) lastTime = t
		const sm = 0.98
		const neu = t - lastTime

		fps = (fps * sm) + ( neu  * (1-sm) )
		try {

			if (w.RNDRS?.[key]) w.RNDRS[key].draw(getCurrentCanvas())
		} catch(err) {
			console.log('❌ renderer error:', err.message)
			throw err
		}
		lastTime = (new Date())
		requestAnimationFrame(animate)
	}

	onMount(e => {
		storeWindowSize()
		animate()

	})

	function captureImage() {

		EXPORTING = true

		w.requestAnimationFrame( async e => {


			const temp = document.createElement('a')
			temp.setAttribute('download', '_MXZ.png')
			const url = (await localCanvas.toDataURL('image/png',1)).replace(/^data:image\/png/,'data:application/octet-stream')
			temp.setAttribute('href', url)
			temp.click()

			EXPORTING = false
		})
	}
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
		console.log(recorder)
		window.recorder = recorder
	}

	$: canvasTransform = $_fullscreen ? `position:fixed;transform:scale(${innerWidth/$_DIMENSIONS.width},${innerHeight/$_DIMENSIONS.height});` : ``


	let innerWidth, innerHeight
	function storeWindowSize() {
		innerWidth = w.innerWidth
		innerHeight = w.innerHeight
	}
</script>

<svelte:window on:resize={ storeWindowSize } />

<div 
	class="renderer {class_}"
	style="height: auto;min-width:{width}px;max-width:{width}px">
	<div class="actions">
		<button 
			on:click={togglePopup}>
			Popup
		</button>
		<button 
			on:click={captureImage}>
			Grab
		</button>
		<button 
			on:click={e => $_fullscreen = !$_fullscreen}>
			{$_fullscreen ? '●' : '○'} Fullscreen 
		</button>
		<button 
			class:active={RECORDING}
			on:click={toggleVideoRecord}>
			{ RECORDING ? 'Recording...' : 'Record' }
		</button>
		<span class="fps">{(1000/fps).toFixed(0)}</span>
	</div>
	<div 
		style="padding-top:{(($_DIMENSIONS.height/$_DIMENSIONS.width))*100}%"
		class:none={$_popup_canvas}
		class="canvas-wrapper">
		<canvas 
			{id}
			style={canvasTransform}
			bind:this={localCanvas} 
			width={$_DIMENSIONS.width} 
			height={$_DIMENSIONS.height} />
	</div>
	<slot />
</div>
