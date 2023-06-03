<script>
	import { onMount } from 'svelte'
	import { _ASSIGNMENTS } from '$mxz/store.js'
	import { InitMIDI } from './MIDI.js'


	onMount( async e => {
		await InitMIDI()
	})

	function onRemove( key ) {
		delete $_ASSIGNMENTS[key]
		$_ASSIGNMENTS = $_ASSIGNMENTS
	}
</script>

<div id="assignments" class="flex column-stretch-flex-start p1">
	{#each Object.entries( $_ASSIGNMENTS ) as [key, list]}
		<div class="flex row-space-between-center">
			<div class="bold">{ key }</div>
			<div class="">
				{list}
			</div>
			<button 
				class="cross h2em"
				on:click={ e => onRemove(key)}>
			</button>
		</div>

	{/each}
</div>