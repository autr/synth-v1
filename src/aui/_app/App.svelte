<script>
	import { AUI_TYPES } from '$aui/defs.js'
	import Logo from "$assets/aui/aui-logo.svg"
	import { SetNonScalingStroke } from '$lib/API.js'
	import Spacer from '$global/Spacer.svelte'

	$: (SetNonScalingStroke)(logoEl)
	let logoEl

</script>


<main class="app aui dark autr">
	<div class="wrapper">
		<aside  class="side">

			<a 
				href="/aui"
				bind:this={logoEl}
				class="logo">
				<Logo />
				<span>AUI</span>
			</a>
			<nav class="nav">
				{#each Object.values(AUI_TYPES) as type, idx}
					<a 
						class="link"
						href="/aui/{type.toLowerCase()}">
						{type}
					</a>
				{/each}
			</nav>
		</aside>
		<span class="vertical v-graphic" />
		<slot />
	</div>
</main>