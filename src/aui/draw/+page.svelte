<script>
	import Svg from '$global/Svg.svelte'
	import Rect from '$global/Rect.svelte'
	import Arc from '$global/Arc.svelte'

	let d
</script>


<div class="col">
<Svg 
	style="width:800px;height:400px;border:1px solid red"
	width={800} 
	height={400}>

	<Rect 
		style="fill:green"
		rounded={0}
		x={200} 
		y={150}
		w={400}
		h={100}
		bind:d={d} />

</Svg>

<p>
	{d}
</p>
</div>