<script>
	import { browser } from '$app/environment'
	import * as KEYS from './Keys.js'
	import { _keys } from './Store.js'
	import { get } from 'svelte/store'

	export let debug = false

	let copy
	export let shortcuts = []

	let bindings = []
	let cmdKeyLookup = {}

	function onKeydown( e ) {

		// if (DEBUG) SAY('keydown:', e.key)

		// for (const method of callbacks?.keydown || []) method( e )

		let keys = get(_keys)

		/* ------ SET TRUE ------ */

		_keys.update( o => {
			o[e.key] = true
			return o
		})

		/* ------ MAKE COPY ------ */

		if (keys[KEYS.LOCAL_CMD_KEY]) copy = {...keys}

		let bindIndex = 0
		for (const bind of bindings || []) {
			let yes = true
			for (let key of bind.command)  {
				if (key == KEYS.CMD_KEY) key = KEYS.LOCAL_CMD_KEY
				if (!keys[key]) yes = false
			}
			if (yes && bind?.action) {

				/* ------ AVOID REPEATS ------ */

				// check if CMD action already taken

				if (!cmdKeyLookup[bindIndex] && bind.command.find( k => k == e.key)) {
					// SAY(`✨ ${bind.command.join('+')}`)
					bind.action( e )
				}
				if (bind.command.find( key => key == KEYS.LOCAL_CMD_KEY)) {
					// cmdKeyLookup[bindIndex] = true
				}
			}
			bindIndex += 1
		}
	}
	function onKeyup( e ) {

		// if (DEBUG) SAY('keyup:', e.key)
		// for (const method of callbacks?.keyup || []) method( e )

		/* ------ SET FALSE ------ */

		_keys.update( o => {
			delete o[e.key]
			return o
		})

		if (e.key == KEYS.LOCAL_CMD_KEY && copy) {
			for (const key of Object.keys(copy)) _keys.update(o => {
				delete o[key]
				return o
			})
			cmdKeyLookup = {}
			copy = null
		}
		_keys.set({...get(_keys)})
	}

	export function addBindings( newBindings ) {

		if (!browser) return

		/* ------ CONVERT OBJECT TO BINDINGS ------ */

		if (!Array.isArray(newBindings) && typeof newBindings == 'object') {
			// SAY(`🪗 converting keys`)
			Object.keys(newBindings).forEach( key => {
				bindings.push({
					command: key.split('+'),
					action: newBindings[key]
				})
			})
		} else {

		/* ------ ADD BINDINGS ------ */

			bindings = [ ...bindings, ...newBindings ]
		}

		/* ------ ALL STRINGS ------ */


		bindings = bindings.map( binding => {
			binding.command = binding.command.map( cmd => cmd + '')
			return binding
		})


		// SAY(`🎹 bindings:`, bindings.map( bind => bind.command.join('+') ).join(', '))
	}

</script>

<svelte:window 
	on:keydown={onKeydown}
	on:keyup={onKeyup} />


{#if debug}
	<div class="italic">Keys</div>
	{Object.keys( $_keys ).join('+')}
	<div class="italic">Shortcuts</div>
	{#each shortcuts as shortcut}
		<div>{shortcut.command.join('+')}</div>
	{/each}
{/if}