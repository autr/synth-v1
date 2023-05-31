<script>

	import { onMount } from 'svelte'
	import { browser } from '$app/environment'


	let w = browser ? window : {}

	let data, context, analyser, stream, source, canvasEl, canvasCtx

	let fftSize = 32
	let smoothingTime = 0.85

	onMount( async e => {


	})


	async function init() {

		context = new ( AudioContext || webkitAudioContext )()
		stream = await openMicrophone()

		source = context.createMediaStreamSource( stream )

		analyser = await context.createAnalyser()

		analyser.smoothingTimeConstant = smoothingTime
		analyser.fftSize = fftSize
		data = new Uint8Array( analyser.frequencyBinCount )

		canvasCtx = canvasEl.getContext('2d')

		await source.connect( analyser )
		// await analyser.connect( context.destination )

		tick()

	}

	async function tick() {

		analyser.getByteFrequencyData( data )

		canvasCtx.fillStyle = 'rgb(0, 0, 0, 0)'
		canvasCtx.fillRect(0, 0, fftSize, 256)
		canvasCtx.clearRect(0, 0, fftSize, 256)

		let barWidth = (fftSize / analyser.frequencyBinCount)
		let barHeight
		let x = 0
		console.log(analyser.frequencyBinCount)
		for(var i = 0; i < analyser.frequencyBinCount; i++) {
			barHeight = data[i]
			canvasCtx.fillStyle = 'rgb(0,255,255)'
			canvasCtx.fillRect(x,256-barHeight/2,barWidth,barHeight)
			x += barWidth + 1
		}

		window.requestAnimationFrame( tick )
	}

	$: (_smoothingTime => {
		if (analyser) analyser.smoothingTimeConstant = smoothingTime
	})( smoothingTime )


	async function openMicrophone(e) {
		return await navigator.mediaDevices.getUserMedia({
			video: false,
			audio: true
		})
	}



</script>


<div class="p0-5 none">

	<canvas 
		style="image-rendering: pixelated;background:none"
		class="h4em w100pc"
		bind:this={canvasEl} 
		width={fftSize} 
		height={256} />
	<div>
		<button on:click={init}>CONNECT</button>
		<input type="number" bind:value={ fftSize } />
		<input type="range" bind:value={ smoothingTime } min={0} max={1} step={0.01} />
	</div>
</div>