import { COMPILER_TYPES } from './../Defs.js'

export default e => {

	const createBlendFunc = (name, body) => {
		return {
			prepend: 'vec3',
			type: 'function',
			name,
			body,
			arguments: [
				{ 
					type:'vec3',
					name:'a'
				},{
					type:'vec3',
					name: 'b'
				}
			]
		}
	}
	return [
		createBlendFunc('NORM', `return b;`),
		createBlendFunc('ADD', `return min(a + b, vec3(1.0));`),
		createBlendFunc('DARKEN', `return COLOR_MAP(DARKEN, a, b);`),
		createBlendFunc('SCREEN', `return COLOR_MAP(SCREEN, a, b);`),
		createBlendFunc('OVERLAY', `return COLOR_MAP(OVERLAY, a, b);`),
		createBlendFunc('HARD', `return OVERLAY(b, a);`),
		createBlendFunc('SOFT', `return COLOR_MAP(SOFT, a, b);`),
		createBlendFunc('PIN', `return COLOR_MAP(PIN, a, b);`),
		createBlendFunc('DIFFERENCE', `return abs(a - b);`),
		createBlendFunc('REFLECT', `return COLOR_MAP(REFLECT, a, b);`),
		createBlendFunc('LIGHTEN', `return COLOR_MAP(LIGHTEN, a, b);`),
		createBlendFunc('VIVID', `return COLOR_MAP(VIVID, a, b);`),
		createBlendFunc('SUBTRACT', `return max(a + b - vec3(1.0), vec3(0.0));`),
		createBlendFunc('MULTI', `return a * b;`),
		createBlendFunc('AVERAGE', `return (a + b) / 2.0;`),
		createBlendFunc('COLORBURN', `return COLOR_MAP(COLORBURN, a, b);`),
		createBlendFunc('COLORDODGE', `return COLOR_MAP(COLORDODGE, a, b);`),
		createBlendFunc('EXCLUSION', `return a + b - 2.0 * a * b;`),
		createBlendFunc('GLOW', `return REFLECT(b, a);`),
		createBlendFunc('HARD_MIX', `return COLOR_MAP(HARD_MIX, a, b);`),
		createBlendFunc('BURN', `return max(a + b - vec3(1.0), vec3(0.0));`),
		createBlendFunc('DODGE', `return min(a + b, vec3(1.0));`),
		createBlendFunc('LINEAR', `return COLOR_MAP(LINEAR, a, b);`),
		createBlendFunc('NEGATE', `return vec3(1.0) - abs(vec3(1.0) - a - b);`),
		createBlendFunc('PHOENIX', `return min(a, b) - max(a, b) + vec3(1.0);`)
	]
}