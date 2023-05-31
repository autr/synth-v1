<script>
	import { CMD_KEY, OS_KEYS, LOCAL_CMD_KEY } from './Keys.js'
	import { _keys } from './Store.js'

	export let debug = false

	let copy
	export let shortcuts = []

	function onKeydown( e ) {
		$_keys[e.key] = true
		if ($_keys[LOCAL_CMD_KEY]) copy = {...$_keys}
		for (const shortcut of shortcuts || []) {
			let yes = true
			for (let key of shortcut.command)  {
				if (key == CMD_KEY) key = LOCAL_CMD_KEY
				if (!$_keys[key]) yes = false
			}
			if (yes && shortcut?.action) shortcut.action( e )
		}
	}
	function onKeyup( e ) {
		delete $_keys[e.key]
		if (e.key == LOCAL_CMD_KEY && copy) {
			for (const key of Object.keys(copy)) delete $_keys[key]
			copy = null
		}
		$_keys = {...$_keys}
	}
</script>

<svelte:window 
	on:keydown={onKeydown}
	on:keyup={onKeyup} />


{#if debug}
	<div class="italic">Keys</div>
	{Object.keys( $_keys ).join('+')}
	<div class="italic">Shortcuts</div>
	{#each shortcuts as shortcut}
		<div>{shortcut.command.join('+')}</div>
	{/each}
{/if}