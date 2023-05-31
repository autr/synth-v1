
// import { ProcessJsonSchema } from '$mxz/API.js'
import BLEND_MODES from '$mxz/compiler/_BlendModes.js'

function ProcessJsonSchema( name, schema ) {
	schema.INPUTS = {
		BlendMode: {
			type: 'long',
			label: 'Blend Mode',
			min: 0,
			max: BLEND_MODES().length,
			default: 0,
			labels: BLEND_MODES().map( b => b.name )
		},
		BlendAmt: {
			type: 'float',
			label: 'Blend Amount',
			min: 0,
			max: 1,
			default: 1
		},
		...schema.INPUTS
	}

	for ( let [key,input] of Object.entries(schema.INPUTS) ) {

		if (input.gui == 'OpSelect') {
			schema.INPUTS[key] = {
				...input,
				gui: 'OpSelect',
				type: 'float',
				min: -1,
				max: 999
			}
		}
	}
	return schema
}
import { default as CapacitorGlsl } from './Capacitor.glsl'
import { default as ChannelGlsl } from './Channel.glsl'
import { default as ConvolutionGlsl } from './Convolution.glsl'
import { default as DeformGlsl } from './Deform.glsl'
import { default as LightGlsl } from './Light.glsl'
import { default as MaskGlsl } from './Mask.glsl'
import { default as MixGlsl } from './Mix.glsl'
import { default as ShapeGlsl } from './Shape.glsl'
import { default as SourceGlsl } from './Source.glsl'
import { default as SynthGlsl } from './Synth.glsl'
import { default as WobbulateGlsl } from './Wobbulate.glsl'

import { default as CapacitorSchema } from './Capacitor.json'
import { default as ChannelSchema } from './Channel.json'
import { default as ConvolutionSchema } from './Convolution.json'
import { default as DeformSchema } from './Deform.json'
import { default as LightSchema } from './Light.json'
import { default as MaskSchema } from './Mask.json'
import { default as MixSchema } from './Mix.json'
import { default as ShapeSchema } from './Shape.json'
import { default as SourceSchema } from './Source.json'
import { default as SynthSchema } from './Synth.json'
import { default as WobbulateSchema } from './Wobbulate.json'

import { default as CapacitorComponent } from './Capacitor.svelte'
import { default as ChannelComponent } from './Channel.svelte'
import { default as ConvolutionComponent } from './Convolution.svelte'
import { default as DeformComponent } from './Deform.svelte'
import { default as LightComponent } from './Light.svelte'
import { default as MaskComponent } from './Mask.svelte'
import { default as MixComponent } from './Mix.svelte'
import { default as ShapeComponent } from './Shape.svelte'
import { default as SourceComponent } from './Source.svelte'
import { default as SynthComponent } from './Synth.svelte'
import { default as WobbulateComponent } from './Wobbulate.svelte'


export const Capacitor = { 
	COMPONENT: CapacitorComponent,
	GLSL: CapacitorGlsl,
	SCHEMA: ProcessJsonSchema( 'Capacitor', CapacitorSchema)
}

export const Channel = { 
	COMPONENT: ChannelComponent,
	GLSL: ChannelGlsl,
	SCHEMA: ProcessJsonSchema( 'Channel', ChannelSchema)
}

export const Convolution = { 
	COMPONENT: ConvolutionComponent,
	GLSL: ConvolutionGlsl,
	SCHEMA: ProcessJsonSchema( 'Convolution', ConvolutionSchema)
}

export const Deform = { 
	COMPONENT: DeformComponent,
	GLSL: DeformGlsl,
	SCHEMA: ProcessJsonSchema( 'Deform', DeformSchema)
}

export const Light = { 
	COMPONENT: LightComponent,
	GLSL: LightGlsl,
	SCHEMA: ProcessJsonSchema( 'Light', LightSchema)
}

export const Mask = { 
	COMPONENT: MaskComponent,
	GLSL: MaskGlsl,
	SCHEMA: ProcessJsonSchema( 'Mask', MaskSchema)
}

export const Mix = { 
	COMPONENT: MixComponent,
	GLSL: MixGlsl,
	SCHEMA: ProcessJsonSchema( 'Mix', MixSchema)
}

export const Shape = { 
	COMPONENT: ShapeComponent,
	GLSL: ShapeGlsl,
	SCHEMA: ProcessJsonSchema( 'Shape', ShapeSchema)
}

export const Source = { 
	COMPONENT: SourceComponent,
	GLSL: SourceGlsl,
	SCHEMA: ProcessJsonSchema( 'Source', SourceSchema)
}

export const Synth = { 
	COMPONENT: SynthComponent,
	GLSL: SynthGlsl,
	SCHEMA: ProcessJsonSchema( 'Synth', SynthSchema)
}

export const Wobbulate = { 
	COMPONENT: WobbulateComponent,
	GLSL: WobbulateGlsl,
	SCHEMA: ProcessJsonSchema( 'Wobbulate', WobbulateSchema)
}
