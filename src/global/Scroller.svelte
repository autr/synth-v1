<script>
	import { onMount } from 'svelte'

	let class_ = ""
	export { class_ as class }
	let style_ = ""
	export { style_ as style }

	export let target
	export let header // component which syncs to .th height

	let inited
	let dragging, active
	let scrollerEl, handleEl, thEl
	let handleTop = 0
	let handleHeight = 0
	let handleInit = 0
	let headerStyle = null

	onMount( async e => {
		update()
	})

	function update() {
		const { scrollTop, offsetHeight, scrollHeight } = target || {}
		const height = scrollerEl?.offsetHeight || 0
		handleTop = (height/(scrollHeight)) * scrollTop
		handleHeight = (height / scrollHeight) * offsetHeight
		if (!thEl && target) thEl = target.querySelector('.thead .td')
		if (thEl) headerStyle = `height:${thEl.offsetHeight}px`
		if (!inited && target) {
			// target.addEventListener('scroll', setActive )
			inited = true
		}
		window.requestAnimationFrame( update )
	}

	let activeTimeout 
	function setActive() {
		active = true
		target.classList.add('hide-scrollbar')
		if (activeTimeout) clearTimeout(activeTimeout)
		activeTimeout = setTimeout( e => {
			window.requestAnimationFrame( ev => {
				if (!dragging) {
					active = false
					target.classList.remove('hide-scrollbar')
				}
			})
		}, 100)
	}

	function set(e) {

		if (dragging) {

			const { offsetY } = e
			const { left, top } = scrollerEl.getBoundingClientRect()

			const x = Math.max( e.pageX - left, 0)
			const y = Math.max( e.pageY - top, 0) - handleInit

			const { scrollHeight } = target || {}
			const { offsetHeight } = scrollerEl || {}

			target.scrollTop = ( scrollHeight / offsetHeight ) * y
		}
	}

	function onDown(e) {
		dragging = true
		window.requestAnimationFrame( ev => {
			handleInit = handleEl.offsetHeight/2
			set(e)
			setActive()
		})
	}

	function onMove(e) {
		if (dragging) {
			set(e)
			e.preventDefault()
			setActive()
		}
	}

	function onUp(e) {
		if (dragging) setActive()
		dragging = false

	}
	function onMousewheel(e) {
		target.scrollTop += e.deltaY
		setActive()
	}

	function onHandleDown(e) {
		active = true
		const { offsetX, offsetY } = e
		setActive()
	}

</script>

<svelte:window 
	on:mousemove={onMove}
	on:mouseup={onUp} />

{#if header}
	<svelte:component this={header} style={headerStyle} />
{/if}
<div 	
	on:mousewheel={onMousewheel}
	on:mousedown={onDown}
	style={style_}
	bind:this={scrollerEl}
	class:active={active}
	class="scroller {class_}">
	<span 
		bind:this={handleEl}
		on:mousedown={onHandleDown}
		style="height:{handleHeight}px;transform:translate(0,{handleTop}px)"
		class="handle" />
	<slot />
</div>