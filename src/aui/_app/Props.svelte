<script>

	import { Defaults } from '$aui/Defs.js'
	import Prop from '$aui/_app/Prop.svelte'

	export let name
	export let schema
	export let entry = { values: {} }

	const defaultProps = Object.keys( Defaults )

	$: properties = (schema => {

		let out = {
			default: {},
			parameter: {}
		}
		for (const [key,prop] of Object.entries(schema.properties)) {
			const split = key.split('_')
			if (split?.[1]) {
				const k = split?.[0]
				if (!out[k]) out[k] = {}
				out[k][key] = prop
			} else if (defaultProps.indexOf(key) != -1) {
				out.default[key] = prop
			} else {
				out.parameter[key] = prop
			}
		}
		return out
	})(schema)

	const actions = [
		{
			id: 'duplicate',
			idx: 0,
			icon: {
				icon_thickness: 0.25,
				value: 2,
				height: '2em'
			},
			run: () => {

			}
		},
		{
			id: 'delete',
			idx: 0,
			icon: {
				icon_thickness: 0.25,
				value: 0,
				height: '2em'
			},
			run: () => {

			}
		}
	]

</script>


<header class="header">
	<div class="group">
		<a 
			href="/aui"
			class="title">
			<span>
				{name}
			</span>
		</a>
		<div class="actions">
			{#each actions as action}
				<button
					class={action.id}
					on:click={action.run}>
					<!-- <Icon {...action.icon} /> -->
				</button>
			{/each}
		</div>
	</div>
</header>
<section class="groups">

	{#each Object.entries(properties) as [name, group], idx }
		<span class="horizontal v-graphic" />
		<div class="group">
			<header class="subheader">
				<span 
					class="title">
					{name}
				</span>
			</header>
			{#each Object.entries(group) as [key, props] }
				<Prop 
					class={name} 
					bind:value={entry.values[key]} 
					{key}
					{props} />
			{/each}
		</div>
	{/each}
</section>