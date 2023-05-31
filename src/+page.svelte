<script context="module">
	export let prerender = true
</script>
<script>
	export const prerender = false
	import App from '$mxz/App.svelte'
	import MXF from '$mxz/MXF/MXF.svelte'

</script>

<App 
	application={MXF} />