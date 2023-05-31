<script>
	import { _dragging, _selected, _DIMENSIONS, _SOURCES } from '$mxz/Store.js'
	import { DRAG_ACTIONS } from '$mxz/Defs.js'
	import * as Ops from '$mxz/ops'
	import FileSave from '$mxz/FileSave.svelte'
	import { GenerateUuidWithName } from '$mxz/API.js'


	function onTouchdown( name ) {
		$_selected = [ GenerateUuidWithName(name) ]
		$_dragging = true
	}

	function onTouchup( name ) {

		$_selected = [-1,-1,-1,-1]
		$_dragging = false
	}

	const total = {
		ops: Ops
	}

	const icons = {
		Capacitor: 'flash_on', // track_changes
		Channel: 'view_week', // view_column
		Convolution: 'grain', // blur_on
		Deform: 'grid_on', // grid_3_x_3
		Light: 'light_mode', // flare
		Mask: 'star_half', // extension
		Blend: 'join_full',
		Shape: 'interests', // hexagon
		Source: 'camera_alt', // videocam
		Synth: 'waves',
		Wobbulator: 'cast'
	}


</script>

<aside 
	style="background: var(--blue5-0)"
	class="flex column">
	<div 

		style="background: var(--blue5-0)"
		class="flex row-center-stretch fixed t0 l0 w100pc bb z-index99">
		<FileSave />
		<input 
			type="number" 
			class="br ptb0-5 plr1 minw0px"
			bind:value={$_DIMENSIONS.width} />
		<input 
			type="number" 
			class="br ptb0-5 plr1 minw0px"
			bind:value={$_DIMENSIONS.height} />
		<!-- <input 
			type="number" 
			class="br ptb0-5 plr1 minw0px"
			bind:value={$_DIMENSIONS.fps} /> -->
		<slot />
	</div>
	<div 
		style="background: var(--blue5-0)"
		class="flex row fixed l0 b0 w100pc z-index98">
		{#each Object.entries(total) as [title, objects]}
			<!-- <div class="bb p0-5 flex row-center-center bold">{title}</div> -->
			{#each Object.keys(objects) as name}
				<div 
					id={ 'menu_' + name.toLowerCase()}
					data-drag-type={DRAG_ACTIONS.MOVE}
					data-drag-unit={name}

					on:mousedown={ e => onTouchdown(name)}
					on:mouseup={ e => onTouchup(name)}

					draggable={true}
					class="plr0-5 grabbable br bt f3 flex row-center-center pop ptb0-5 grow">
					<!-- {name} -->
					<span class="f0"> {name}</span>
					<!-- <span class="material-icons">{icons[name]}</span> -->
				</div>
			{/each}
		{/each}
		<a 
			href="https://liberatedinterfaces.tv"
			class="bt"
			style="padding:0;line-height:0em;">
			<img 
				style="background:none;height:2.2em;"
				class="pt0-4 pb0-3 plr0-5 h2em"
				src="/liberatedinterfaces.png" />
		</a>
	</div>
</aside>
