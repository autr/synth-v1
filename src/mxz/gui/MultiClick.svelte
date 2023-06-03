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
	const SAY = (m, e) => console.log(`[MultiClick] ${m}`, e || '')

	$: (_UNIS => {
		if ($_UNIFORMS[key] == null && def.default != null) $_UNIFORMS[key] = JSON.parse( JSON.stringify( def.default ) )
		if (!w.RNDRS) return
		for (const [id, rndr] of Object.entries(w.RNDRS)) {
			
			if (rndr.getValue() != $_UNIFORMS[key]) {
				if (!def.ignore ) {
					try {
						if (rndr.uniforms[key]) rndr.setValue(key,$_UNIFORMS[key])
					} catch(err) {
						console.log('❌ error setting value in MultiClick', err)
					}
				}
			}
		}
	})($_UNIFORMS)
	
	/*/HEADER*/

	function  onMousedown(e) {
		$_UNIFORMS[key] += 1
		if ($_UNIFORMS[key] >= def.labels.length) {
			$_UNIFORMS[key] = 0
		}
	}
	
</script>
<button
	on:mousedown={onMousedown}
	class="italic">
	{def.labels[$_UNIFORMS[key]]}
</button>