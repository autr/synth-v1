<script>
	import { WSAPI, LOG } from '../../../wsapi/index.js'
	import { onMount } from 'svelte'


	onMount( e => {


		const run = async e => {


			const wsapi = new WSAPI({ 
				log: LOG.VERBOSE,
				timeout: 0
			})
			window.wsapi = wsapi

				await wsapi.open('ws://localhost:9092').catch(err => {
					console.error('ERROR OPENING', err.message, err.code)
				})
				wsapi.get('immediate get', {})
				wsapi.set('immediate set', {})
				wsapi.update('immediate update', {})
				wsapi.add('immediate add', {})
				wsapi.remove('immediate remove', {})

		}

		run()
	})

</script>
