<script>
	import { browser } from '$app/environment'
	import { onMount } from 'svelte'
	
	import Keys from '$global/Keys.svelte'
	import WebRenderer from '$mxz/web-renderer/WebRenderer.svelte'
	import Menu from '$mxz/MXF/Menu.svelte'
	import Editor from '$mxz/MXF/Editor.svelte'
	import FFT from '$mxz/assignments/FFT.svelte'
	import * as Ops from '$mxz/ops/index.js'
	import { _CURRENT_VIEW, _popup_canvas } from '$mxz/Store.js'

	const w = (browser) ? window : {}


	const SAY = (m, e) => console.log(`[MXF] ${m}`, e || '')

	let width = 720/2
	function setPreviewWidth() {
		// width = w.innerWidth * 0.3
	}

	onMount( init )

	async function init() {
		if (!browser) return
		setPreviewWidth()
		SAY(`👍 inited`)
	}

	let shortcuts = []

</script>


<svelte:window 
	on:resize={setPreviewWidth} />


<Keys {shortcuts} />

<div class="flex row grow">
	<!-- <div class="fixed b0 l0 pop border p1 flex column maxw16em">
		<FFT />
	</div> -->
	<div id="editor" 
		class="grow flex column overflow-hidden">

		<Editor id="editor" />


	</div>
	<div class="flex column">
		<Menu>

			<WebRenderer 
				width={width} 
				id="main" 
				key="main" 
				class="abs t100pc r0"
				capture={true}>

			</WebRenderer>
		</Menu>
	</div>
</div>