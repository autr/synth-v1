<script>
	import * as Guis from '$mxz/gui/index.js'
	import Auto from '$mxz/gui/Auto.svelte'
	import { _UNIFORMS, _HIDDEN } from '$mxz/store.js'
	export let schema
	export let uuid
	export let name
	export let shader
	export let rowIdx
	export let colIdx
</script>

{#each Object.entries(schema.INPUTS) as [paramName, def], index}
	<div 
		class:none={$_HIDDEN[uuid+paramName]}
		class="flex row-stretch-center wrap bt">
		<div class="grow monospace f1 italic mb0-4">{def.label || paramName}</div>
		<svelte:component
			this={Guis[def.gui] || Auto} 
			{def}
			{uuid}
			{rowIdx}
			{colIdx}
			parentName={name}
			name={paramName}
			key={uuid+paramName} /> 
	</div>
{/each}