<script>

	import MenuList from './MenuList.svelte'
	import Menu from './Menu.svelte'
	import { MENU_TYPES } from './MenuDef.js'
	import { _context_menu } from '$lib/store.js'

	export let list
	export let idx
	export let boxes
	export let reverses = []

	let element 
	let inited = false

	$: (_boxes => {
		if (!element) return
		const { offsetWidth, offsetHeight } = element
		boxes[idx] = { ...boxes[idx], offsetWidth, offsetHeight }
	})(boxes)

	function onClick( action ) {
		try {
			action()
		} catch(err) {
			console.error(err)
		}
	}

</script>


<ul 
	class="list"
	style="z-index:{idx+99}"
	class:reverse={reverses?.[idx]}
	bind:this={element}>
	{#each list || [] as { type, render, action, items }}
		<li 
			on:click={e => onClick( action )}
			class="{type.toLowerCase()}">

			<span>
			{@html (typeof render === 'function' ? render() : render) || '' }
			</span>
			{#if type == MENU_TYPES.ITEM}

			{:else if type == MENU_TYPES.EXPAND}
				<em class="chevron" />
				<MenuList 
					list={items} 
					idx={idx+1} 
					{reverses}
					bind:boxes={boxes} />
			{:else if type == MENU_TYPES.ITEM}

			{:else if type == MENU_TYPES.SPACER}

			{:else}

			{/if}
		</li>
	{/each}
</ul>