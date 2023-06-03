<script>
	import { _PREVIEW, _selected, _UNIFORMS, _HIDDEN, GetStoresAsText, _CURRENT_VIEW } from '$mxz/store.js'

	let project = ''
	$: (_cv => {
		project = GetStoresAsText( '\t' )
	})( $_CURRENT_VIEW )

</script>

<div class="flex row">
	<div class="flex column p1">
		<div class="bold">PREVIEW</div>
		<div class="">{$_PREVIEW}</div>
		<div class="bold">selected</div>
		<div class="">{$_selected}</div>
		<div class="bold">uniforms</div>
		{#each Object.entries($_UNIFORMS) as [name,value]}
			<div class="flex row-space-between-flex-start minw16em">
				<label class="checkbox">
					<input 
						type="checkbox" 
						bind:checked={$_HIDDEN[name]} />
					<span />
					{name}
				</label>
				<span>
					{#if Array.isArray(value)}
						{#each value as v, i}
							{v ? v.toFixed(2) : 'null'} 
						{/each}
					{:else if typeof value == 'number'}
						{value.toFixed(2)}
					{:else}
						{value}
					{/if}
				</span>
			</div>
		{/each}
	</div>
	<pre class="monospace p1 pl3 grow filled overflow-auto f2 rel">{project.trim()}</pre>
</div>