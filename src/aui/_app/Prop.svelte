<script>

	import Knob from '$aui/_elements/Knob.svelte'
	import Slider from '$aui/_elements/Slider.svelte'
	import Color from '$aui/_elements/Color.svelte'
	import Waveform from '$aui/_elements/Waveform.svelte'
	import Selector from '$aui/_elements/Selector.svelte'
	import Joystick from '$aui/_elements/Joystick.svelte'
	import Icon from '$aui/_elements/Icon.svelte'
	import Numbox from '$aui/_elements/Numbox.svelte'
	import Toggle from '$aui/_elements/Toggle.svelte'
	import Textbox from '$aui/_elements/Textbox.svelte'

	// ---
	let style_ = ""
	export { style_ as style }
	let class_ = ""
	export { class_ as class }
	$: classes = ""
	// ---

	export let key
	export let props
	export let value

	let styles = {
		selector: 'grow'
	}

	$: isArray = ( _props => {
		let a = Array.isArray(props.type) ? props.type : [props.type]
		let b = false
		for (const t of a) if (t.indexOf('vec') != -1 || t == 'array' ) b = true
		return b
	})(props)

</script>


<div 
	class="prop">
	<div class="{classes} key">
		{key}
	</div>
	<div class="value">
		{#if props.oneOf}
			<div class="select">
				<select
					bind:value={value}>
					{#each props.oneOf as opt}
						<option 
							value={opt} 
							name={opt}>
							{opt}
						</option>
					{/each}
				</select>
			</div>

		{:else if props.type == 'number'}
			<Numbox 
				type="number" 
				min={props.min}
				max={props.max}
				step={props.step}
				bind:value={value} />
		{:else if props.type == 'string'}
			<Textbox bind:value={value} />
		{:else if isArray }
			<span class="array">
				{#each (new Array(props.maxItems)) as val, idx}
					{#if value?.[idx] != null}
						<span class="item">
							{#if props?.items?.type == 'number'}
								<Numbox 
									bind:value={value[idx]} 
									step={0.1}
									min={0}
									max={1} />
							{:else}
								<Textbox bind:value={value[idx]} />
							{/if}
						</span>
					{/if}
					
				{/each}
			</span>
		{:else if props.type == 'boolean'}
			<button class:filled={value} class="border" on:click={e => { value = !value }} >
				X
			</button>
			<!-- <Toggle bind:value={value} /> -->

		{/if}

	</div>
</div>