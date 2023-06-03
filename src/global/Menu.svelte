<script>

	import { onMount } from 'svelte'
	import { _context_menu, _keys } from '$lib/global/store.js'
	import MenuList from './MenuList.svelte'
	import { MENU_TYPES } from './MenuDef.js'
	import { SHIFT_KEY, LOCAL_CMD_KEY } from './Keys.js'

	let position = { pageX: 0, pageY: 0 }
	let boxes = []
	let reverses = []
	
	function storePosition(e) {
		let { pageX, pageY } = e
		position = { pageX, pageY }
	}

	function onCoverClick(e) {

		window.requestAnimationFrame( ev => {
			storePosition(e)
			$_context_menu = null
		})
	}

	$: (_boxes => {
		let reverse = false
		let { pageX, pageY } = position
		for( let i = 0; i < boxes.length; i++ ) {
			const { offsetWidth, offsetHeight } = boxes[i]
			const { innerWidth } = window
			if ( pageX + offsetWidth > innerWidth && !reverse ) {
				reverse = true
			}
			if ( pageX < 0 && reverse ) {
				reverse = false
			}
			if (reverse) {
				pageX -= offsetWidth
			} else {
				pageX += offsetWidth
			}
			reverses[i] = reverse
		}
	})(boxes)

	onMount( async e => {
		document.body.addEventListener( 'contextmenu', e => {
			storePosition(e)
			if (!$_keys[LOCAL_CMD_KEY]) {
				e.preventDefault()
			} else {
				$_context_menu = null
			}
			$_keys = {}
		})
	})

</script>
<!-- 
<svelte:window 
	on:click={onCoverClick} />
 -->
<span 
	on:click={onCoverClick}
	class:none={!$_context_menu}
	class="menu-cover" />
<menu 
	style="transform:translate({$_context_menu?0:-99999}px, 0px);left:{position?.pageX}px;top:{position?.pageY}px"
	class="menu">
	<MenuList 
		list={$_context_menu} 
		idx={0} 
		reverses={reverses}
		bind:boxes={boxes} />
</menu>