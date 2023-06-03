<script>
	import { browser } from '$app/environment'
	import { onMount } from 'svelte'
	
	import { _dragging, _selected, _DIMENSIONS, _SOURCES } from '$mxz/store.js'
	import { DRAG_ACTIONS } from '$mxz/defs.js'
	import * as Ops from '$mxz/ops'
	import FileSave from '$mxz/FileSave.svelte'
	import { GenerateUuidWithName } from '$mxz/API.js'


	function onTouchdown( name ) {
		$_selected = [ GenerateUuidWithName(name) ]
		$_dragging = true
	}

	function onTouchup( name ) {

		$_selected = [-1,-1,-1,-1]
		$_dragging = false
	}

	const total = {
		ops: Ops
	}

	import Keys from '$global/Keys.svelte'
	import WebRenderer from '$mxz/web-renderer/WebRenderer.svelte'
	import Menu from '$mxz/MXF/Menu.svelte'
	import Editor from '$mxz/MXF/Editor.svelte'
	import FFT from '$mxz/assignments/FFT.svelte'
	import { _CURRENT_VIEW, _popup_canvas } from '$mxz/store.js'

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

<div class="flex column-stretch-stretch grow h100vh">
	<div 

		style="background: var(--blue5-0)"
		class="flex row-center-stretch rel t0 l0 w100pc bb z-index99">
		<FileSave />
		<input 
			type="number" 
			class="br ptb0-5 plr1 minw0px"
			bind:value={$_DIMENSIONS.width} />
		<input 
			type="number" 
			class="br ptb0-5 plr1 minw0px"
			bind:value={$_DIMENSIONS.height} />
		<!-- <input 
			type="number" 
			class="br ptb0-5 plr1 minw0px"
			bind:value={$_DIMENSIONS.fps} /> -->

		<WebRenderer 
			width={width} 
			id="main" 
			key="main" 
			style="background: var(--blue5-0)"
			class="abs t100pc r0 z-index88"
			capture={true}>
		</WebRenderer>
	</div>
	<div class="grow flex column-stretch-stretch overflow-auto">

		<Editor id="editor" />
		<div class="w100pc minh4em" />

	</div>

	<div 
		style="background: var(--blue5-0)"
		class="flex row w100pc z-index98">
		{#each Object.entries(total) as [title, objects]}
			{#each Object.keys(objects) as name}
				<div 
					id={ 'menu_' + name.toLowerCase()}
					data-drag-type={DRAG_ACTIONS.MOVE}
					data-drag-unit={name}

					on:mousedown={ e => onTouchdown(name)}
					on:mouseup={ e => onTouchup(name)}

					draggable={true}
					class="plr0-5 grabbable br bt f3 flex row-center-center pop ptb0-5 grow">
					<span class="f0"> {name}</span>
				</div>
			{/each}
		{/each}
		<a 
			href="https://liberatedinterfaces.tv"
			class="bt"
			style="padding:0;line-height:0em;">
			<img 
				style="background:none;height:2.4em;"
				class="pt0-4 pb0-3 plr0-5"
				src="/liberatedinterfaces.png" />
		</a>
	</div>
</div>