<script>
	import { browser } from '$app/environment'
	const _window = browser ? window : {}
	
	let el
	export let canvas = 1

	$: orientation = ( el => {
		return _window?.getComputedStyle && el?.parentElement ? _window.getComputedStyle( el.parentElement )?.['flex-direction'] : 'row'
	})(el)


</script>

{#if canvas}
	<canvas class="aui-spacer a-square --{orientation}" width={1} height={1*(1/(+canvas))} bind:this={el} />
{:else}
	<span class="aui-spacer a-rule v-graphic --{orientation}" bind:this={el} />
{/if}