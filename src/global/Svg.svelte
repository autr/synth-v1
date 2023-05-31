<script>

	import { onMount, createEventDispatcher } from "svelte"
	import { browser } from '$app/environment'
	const _window = browser ? window : {}

	let class_ = ""
	export { class_ as class } 
	let style_ = ""
	export { style_ as style }

	const dispatch = createEventDispatcher();


	export let x = 0
	export let y = 0
	export let width = 100
	export let height = 100
	export let preserveAspectRatio = undefined


	$: orientation = ( el => {
		return _window?.getComputedStyle && el?.parentElement ? _window.getComputedStyle( el.parentElement )?.['flex-direction'] : 'row'
	})(element)

	$: center = ({ x: width/2, y: height/2 })

	export let element
</script>

<svg 
	xmlns="http://www.w3.org/2000/svg" 
	xmlns:xlink="http://www.w3.org/1999/xlink"
	on:click
	on:dblclick
	on:mousedown
	on:mouseup
	on:mouseover
	on:mouseout
	on:touchstart
	on:touchmove
	on:touchend
	bind:this={element}
	{preserveAspectRatio}
	width={1}
	height={1}
	viewBox="{x} {y} {width} {height}"
	class={`--${orientation} aui-svg ` + class_}
	style={style_}>
	<slot />
</svg>