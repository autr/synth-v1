<script>


	/*HEADER*/
	import { onMount } from 'svelte'
	import { browser } from '$app/environment'
	import { _UNIFORMS } from '$mxz/store.js'
	
	export let def
	export let key
	export let parentName
	export let name
	export let uuid
	export let rowIdx
	export let colIdx

	const w = browser ? window : {}
	const SAY = (m, e) => console.log(`[ExtSource] ${m}`, e || '')

	$: (_UNIS => {
		if ($_UNIFORMS[key] == null && def.default != null) $_UNIFORMS[key] = JSON.parse( JSON.stringify( def.default ) )
		if (!w.RNDRS) return
		for (const [id, rndr] of Object.entries(w.RNDRS)) {
			
		}
	})($_UNIFORMS)
	
	/*/HEADER*/

	let defaults = []

	function animate() {

		if (w.RNDRS) {
			for (const [id, rndr] of Object.entries(w.RNDRS)) {
				if (rndr && el) {
					rndr.setValue( key, el)
				} else if ($_UNIFORMS[key]?.type == MEDIA_TYPES.FEEDBACK) {
					const canvas = document.getElementById('main')
					rndr.setValue( key, canvas)

				}
			}
		}
		if (browser) w.requestAnimationFrame(animate)
	}
	onMount( async e => {
		defaults = await MEDIA_DEFAULTS()
		animate()
	})


	import { MEDIA_TYPES, MEDIA_DEFAULTS } from '$mxz/defs.js'

	let isCameraRequested = false
	function openCameraStream(e) {
		isCameraRequested = true
		navigator.mediaDevices.getUserMedia({
			video: true,
			audio: false
		}).then( (stream, id) => {
			console.log('✅ ------------ camera opened', stream)
			el.srcObject = stream        
		})
	}

	let el

	$: (EL => {
		if ($_UNIFORMS[key]?.type == MEDIA_TYPES.CAMERA) {
			if (!isCameraRequested) openCameraStream()
		} else {
			isCameraRequested = false
		}
	})(el)

	let selector 

	function onSelectorChange(e) {

		window.requestAnimationFrame( e => {
			if (selector) {
				$_UNIFORMS[key] = selector
			}
		})
	}


	function onDragover(e) {
		e.preventDefault()
	}

	async function onDrop(e) {
		e.preventDefault()

		const item = e?.dataTransfer?.items?.[0]
		if (!item) return
	    const entry = await item.getAsFileSystemHandle()
		const ext = entry.name.split('.').pop().toLowerCase()
		const {name} = entry
		if (entry.kind=='file') {
			const path = URL.createObjectURL(await entry.getFile())
			const vids = ['mp4','mov','avi','mkv']
			const imgs = ['jpg','png','gif','jpeg']

			if (vids.indexOf(ext) != -1) {
				$_UNIFORMS[key] = {
					type: MEDIA_TYPES.VIDEO,
					path,
					name
				}
			} else if (imgs.indexOf(ext) != -1) {
				$_UNIFORMS[key] = {
					type: MEDIA_TYPES.IMAGE,
					path,
					name
				}
			}
		}
	}

	$: name = $_UNIFORMS?.[key]?.name ? $_UNIFORMS[key].name : $_UNIFORMS?.[key]?.path ? $_UNIFORMS[key].path.split('/').pop() : 'N/A'
</script>

<div 
	on:dragover={onDragover}
	on:drop={onDrop}
	class="flex column sticky t0 l0">
	<div class="select bl bt br bb rel maxw100pc overflow-hidden 100pc">
		<div class="plr0-5 flex row-flex-start-center">
			{name}
		</div>
		<select 
			class="invisible abs l0 t0" 
			on:change={onSelectorChange}
			bind:value={selector}>
			{#each defaults as def }
				<option value={def}>
					{def.type} {def.path || ''}
				</option>
			{/each}
		</select>
	</div>
	<div class="w100pc filled minh2em sticky t0 l0">
		{#if $_UNIFORMS[key]?.type == MEDIA_TYPES.IMAGE}
			<img 
				bind:this={el}
				src={$_UNIFORMS[key]?.path} />
		{:else if $_UNIFORMS[key]?.type == MEDIA_TYPES.VIDEO}
			<video 
				bind:this={el}
				autoplay
				volume="0"
				muted
				loop
				controls
				src={$_UNIFORMS[key]?.path} />
		{:else if $_UNIFORMS[key]?.type == MEDIA_TYPES.CAMERA}
			<video 
				bind:this={el}
				autoplay
				loop
				controls />

		{/if}
	</div>
</div>
