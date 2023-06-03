<script context="module">
	export const prerender = false
	export const ssr = false
</script>

<script>
	import { browser } from '$app/environment'
	import { onMount } from 'svelte'

	import Keys from '$global/Keys.svelte'
	import { LOCAL_CMD_KEY, SHIFT_KEY, ESC_KEY, CTRL_KEY } from '$global/Keys.js'


	import { APP_VIEWS, COMPILER_MODES, DRAG_ACTIONS } from './Defs.js'
	import { _CURRENT_VIEW, _PREVIEW } from '$mxz/Store.js'
	import { _selected, _recompile, _fullscreen } from '$mxz/Store.js'
	import { GetSelectedSequenceList } from '$mxz/API.js'

	import SystemDebugger from '$mxz/debug/SystemDebugger.svelte'
	import ShaderDebugger from '$mxz/debug/ShaderDebugger.svelte'
	import Assignments from '$mxz/assignments/Assignments.svelte'
	import { MakeSequenceAdjustment, ClearUpUniforms } from '$mxz/API.js'


	const SAY = (m, e) => console.log(`[App] ${m}`, e || '')

	export let application

	let selectedList = []
	$: (_sel => {
		selectedList = GetSelectedSequenceList()
		$_PREVIEW = selectedList?.[selectedList.length-1]
	})($_selected)

	let inited = false 
	let keysEl

	onMount( async e => {
		if (browser) {
			// $_CURRENT_VIEW = window.localStorage.getItem( '__CURRENT_VIEW' )
			SAY(`getting current view ${$_CURRENT_VIEW}`)
			inited = true

			keysEl.addBindings([

				{
					command: [ 'Tab' ],
					action: e  => {

						// const keys = Object.values(APP_VIEWS)
						// let idx = keys.indexOf($_CURRENT_VIEW)
						// idx += 1
						// if (idx >= keys.length - 1) idx = 0
						// $_CURRENT_VIEW = keys[idx]
						// e.preventDefault()
					}
				},
				{
					command: [ LOCAL_CMD_KEY, 'f' ],
					action: e  => {

						$_fullscreen = !$_fullscreen
						e.preventDefault()
					}
				},
				{
					command: [ LOCAL_CMD_KEY, 's' ],
					action: e  => {
						console.log('CAPTURING IMAGE')
						window.captureImage()
						e.preventDefault()
						e.stopPropagation()
					}
				},
				{
					command: [ ESC_KEY ],
					action: e  => {

						if ($_fullscreen) $_fullscreen = false
						e.preventDefault()
					}
				},
				...Object.values(APP_VIEWS).map( (view,idx) => {
					return {
						command: [LOCAL_CMD_KEY, (idx + 1)+'' ],
						action: e => {
							$_CURRENT_VIEW = Object.values(APP_VIEWS)[idx]
							e.preventDefault()
						}
					}
				}),
				{
					command: ['Backspace'],
					action: e => {


						if ($_selected) {

							SAY('🚩 deleting', $_selected)

							if ($_selected?.[0]?.[0] != null && $_selected?.[0]?.[1] != null ) {
								MakeSequenceAdjustment( DRAG_ACTIONS.BIN, $_selected?.[0]?.[0], $_selected?.[0]?.[1] )
								ClearUpUniforms()

								window.requestAnimationFrame( e => {
									_recompile.set( COMPILER_MODES.COMPILE )
								})
							}
						}
					}
				}
			])
		}
	})

	$: (_cv => {
		if (browser && inited) {
			SAY(`setting view to ${$_CURRENT_VIEW}`)
			window.localStorage.setItem( '__CURRENT_VIEW', $_CURRENT_VIEW )
		}
	})($_CURRENT_VIEW)


	const views = {
		[APP_VIEWS.APPLICATION]: {
			name: 'Application',
			view: application
		},
		[APP_VIEWS.ASSIGNMENTS]: {
			name: 'Assignments',
			view: Assignments
		},
		[APP_VIEWS.DEBUG_SHADER]: {
			name: 'Shader (Debug)',
			view: ShaderDebugger
		},
		[APP_VIEWS.DEBUG_SYSTEM]: {
			name: 'System (Debug)',
			view: SystemDebugger
		}
	}


</script>

<div 
	id="drag-visualiser" 
	class:none={!selectedList}
	style="bottom:-100%"
	class="pop w80px fixed b0 l0 bl bb br flex column-center-center z-index66">
	{#each selectedList as id}
		<div 
			style="background: var(--blue5-0)"
			class="bt p0-5 bold grow w100pc h40px flex row-flex-start-center">
			{id.split(':')[0]}
		</div>
	{/each}
</div>

<Keys bind:this={keysEl} />


<div id="app" class="app mxz dark flex row-stretch-stretch">
	<nav 
		style="background: var(--blue5-0)"
		class="flex bb fixed t0 l0 w100pc z-index44 none">
		{#each Object.entries( views ) as [id,item]}
			<button 
				on:click={e => _CURRENT_VIEW.set(id)}
				class:filled={$_CURRENT_VIEW == id}
				class="grow">
					{item.name}
			</button>
		{/each}
	</nav>
	<article class="flex column grow overflow-hidden h100vh w100vw">
		{#each Object.entries(views) as [id, item]}
			<section 
				{id}
				class="flex column grow"
				class:none={id != $_CURRENT_VIEW}>
				<svelte:component this={item.view} />
			</section>
		{/each}
	</article>
</div>


