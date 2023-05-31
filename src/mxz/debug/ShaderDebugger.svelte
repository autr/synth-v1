<script>

	import { browser } from '$app/environment'
	import * as Compiler from '$mxz/compiler'
	import * as API from '$mxz/API.js'
	import { GetFunctionArgumentNames } from '$mxz/API.js'


	const w = (browser) ? window : {}
	const SAY = (m, e) => console.log(`[Debugger] ${m}`, e || '')

	let view = 'JSON_CONFIG'
	let text = ''
	const AREAS = Object.keys(Compiler.ALL)

	$:(_view => {

		if (_view == 'API') {

			text = Object.keys(API).map( A => {
				const F = API[A]
				console.log(GetFunctionArgumentNames(F))
				return `${A}( ${GetFunctionArgumentNames(F).join(', ')} )`
			}).join('\n')
		} else if (_view == 'FRAGMENT') {
			text = w?.renderer?.parser?.fragmentShader || window?.shaderSrc || '// None'
		} else if (_view == 'VERTEX') {
			text = w?.renderer?.parser?.vertexShader || '// None'
		} else if (_view == 'ISF') {
			text = Compiler.compile({hide:true})
		} else if (AREAS.indexOf(_view) != -1) {
			text = Compiler.compile({keys: [_view],hide: true})
		}
	})(view)


</script>
<div class="row flex">
	<nav class="flex column br">
		{#each ['VERTEX', 'FRAGMENT', 'ISF', ...AREAS, 'API'] as name}
			<button 
				class:filled={view == name}
				on:mousedown={ e => (view = name)}>
				{name}
			</button>
		{/each}

	</nav>
	<div class="overflow-auto h100pc">
		<pre class="monospace whitespace-prewrap p1 pl3 grow filled overflow-auto f2 rel">{text.trim()}
			<pre class="abs l0 t0 mt1 plr0-5 fade" style="user-select:none!important">{#each new Array(text.split('\n').length) as idx,i}{i}<br />{/each}
			</pre>
		</pre>
	</div>
</div>