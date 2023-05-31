export const ALL_EVENTS = [ 
	'focus',
	'blur',
	'click',
	'touchstart',
	'touchend',
	'touchmove',
	'touchcancel',
	'dblclick',
	'mousedown',
	'mouseup',
	'mousemove',
	'mouseout',
	'contextmenu' 
]

const FLEX_RULES = ['flex-start', 'flex-end', 'stretch', 'center', 'space-between'] 

const TYPE_ARR = 'array'
const TYPE_BOOL = 'boolean'
const TYPE_NUM = 'number'
const TYPE_STR = 'string'
const TYPE_BUFFER = 'buffer'
const TYPE_VEC2 = 'vec2'
const TYPE_VEC3 = 'vec3'
const TYPE_VEC4 = 'vec4'
const TYPE_OBJ = 'object'

export const VAR_TYPES = {
	TYPE_ARR,
	TYPE_BOOL,
	TYPE_NUM,
	TYPE_STR,
	TYPE_BUFFER,
	TYPE_VEC2,
	TYPE_VEC3,
	TYPE_VEC4,
	TYPE_OBJ
}

const AUI_COLOR = 'Color'
const AUI_SLIDER = 'Slider'
const AUI_KNOB = 'Knob'
const AUI_WAVE = 'Waveform'
const AUI_SELECTOR = 'Selector'
const AUI_JOYSTICK = 'Joystick'
const AUI_NUMBOX = 'Numbox'
const AUI_BUTTON = 'Button'
const AUI_ICON = 'Icon'
const AUI_TOGGLE = 'Toggle'
const AUI_TEXTBOX = 'Textbox'

export const AUI_TYPES = {
	AUI_COLOR,
	AUI_SLIDER,
	AUI_KNOB,
	AUI_WAVE,
	AUI_SELECTOR,
	AUI_JOYSTICK,
	AUI_NUMBOX,
	AUI_ICON,
	AUI_TOGGLE,
	AUI_TEXTBOX
}

export const AUI_NOSPAN = []

export const AUI_COLUMN = 'Column'
export const AUI_ROW = 'Row'
export const AUI_RANGE = 'Range'
export const AUI_AXIS = 'Axis'

const createSchemaProp = ( type, props ) => ({ type, ...props })

const createWidthHeightDefaults = (width,height) => ({
	width: createSchemaProp( TYPE_VEC2, { 
		default: null,
		editor: width,
		description: 'default width for this element'
	}),
	height: createSchemaProp( TYPE_VEC2, { 
		default: null,
		editor: height,
		description: 'default height for this element'
	})
})

const createSchemaDefaults = name => ({ 
	name: createSchemaProp( TYPE_STR, { 
		default: name,
		description: 'descriptive name for the ui element, ie. "opacity"'
	}),
	id: createSchemaProp( TYPE_STR, { 
		default: name.toLowerCase(),
		description: 'unique id must be set automatically via sync, or user defined'
	}),
	url: createSchemaProp( TYPE_STR, {
		default: name.toLowerCase(),
		description: 'recursive url format id for automatic sync'
	}),
	tabindex: createSchemaProp( TYPE_NUM, {
		default: 0,
		description: 'important for accesibility'
	}),
	style: createSchemaProp(TYPE_STR, { default: '' } ),
	class: createSchemaProp(TYPE_STR, { default: '' } ),
})

export const createSchemaObject = (type, props ) => {
	return createSchemaProp( TYPE_OBJ, {
		properties: {
			...createSchemaDefaults(type),
			...props
		}
	})
}
export const createSchemaList = options => {
	return createSchemaProp( TYPE_STR, { 
		default: options[0],
		oneOf: options 
	} )
}

export const RULE_VISUAL_POS = {
	position: createSchemaProp(TYPE_STR, { 
		default: -1, 
		oneOf: [-1, 0, 1]
	})
}

export const RULE_SMOOTHING = {
	smoothing: createSchemaProp(TYPE_NUM, {
		default: 0.2,
		min: 0,
		max: 1
	})
}

export const RULE_HANDLE_RECT = {
	handle_width: {
		type: 'number',
		default: 0.5,
		min: 0,
		max: 2,
		description: 'width of the handle'
	},
	handle_height: {
		type: 'number',
		default: 0.5,
		min: 0,
		max: 2,
		description: 'height of the handle'
	},
	handle_rounded: {
		description: 'rounded sides of ticks',
		type: ['array', 'number'],
		items: {
			type: 'number'
		},
		default: [1,1,1,1],
		maxItems: 4
	}
}

export const RULE_TICKS = {

	tick_divisions: {
		type: 'number',
		default: 3,
		step: 1,
		min: -1,
		max: 30,
		description: 'number of visual ticks'
	},
	tick_width: {
		type: 'number',
		default: 0.2,
		min: 0,
		max: 1,
		description: 'width of the ticks'
	},
	tick_height: {
		type: 'number',
		default: 0.2,
		min: 0,
		max: 1,
		description: 'height of the ticks'
	},
	tick_offset: {
		type: 'number',
		default: 0,
		min: -10,
		max: 10,
		step: 0.2,
		description: 'height of the ticks'
	},
	tick_rounded: {
		description: 'rounded sides of ticks',
		type: ['array', 'number'],
		items: {
			type: 'number'
		},
		default: [1,1,1,1],
		maxItems: 4
	}
}

export const RULE_MINMAX = {
	min: createSchemaProp(TYPE_NUM, { default: 0 }),
	max: createSchemaProp(TYPE_NUM, { default: 1 }),
}

export const RULE_STEP = {
	resolution: createSchemaProp(TYPE_NUM, { default: false }),
}

export const RULE_XY_MINMAX = {
	min: createSchemaProp(TYPE_STR, { 
		default: [0,0],
		items: {
			type: 'number'
		},
		minItems: 2,
		maxItems: 2
	}) ,
	max: createSchemaProp(TYPE_STR, { 
		default: [1,1],
		items: {
			type: 'number'
		},
		minItems: 2,
		maxItems: 2
	})
}

export const Defaults = createSchemaDefaults('')





export const PROTOTYPE = { 
	[TYPE_BUFFER]: createSchemaObject( TYPE_BUFFER, {
		value: createSchemaProp( TYPE_BUFFER, { 
			default: [] 
		}),
		items: {
			type: ['number', 'array']
		},
		formats: {
			[AUI_WAVE]: {
			}
		}
	}),
	[TYPE_BOOL]: createSchemaObject(TYPE_BOOL, { 
		value: createSchemaProp( TYPE_BOOL, { default: false } ),
		formats: {
			[AUI_BUTTON]: {
				...createWidthHeightDefaults('200px', '2em'),
				icon: {
					type: 'number',
					step: 1,
					default: null
				},
				position: {
					type: 'number',
					default: 0,
					min: 0,
					max: 3
				}
			},
			[AUI_TOGGLE]: {
				...createWidthHeightDefaults('50px', '2em'),
				safety_drag: {
					type: 'boolean',
					default: false,
					description: 'simulate a smartphone unlock slider'
				},
				ui_rounded: {
					type: 'number',
					default: 1,
					description: 'roundedness of toggle'

				},
				ui_outline: {
					type: 'string',
					default: null
				},
				handle_padding: {
					type: 'number',
					default: 0.1,
					min: 0,
					max: 1
				},
				handle_outline: {
					type: 'number',
					default: 0.1,
					min: 0,
					max: 1,
					description: 'outline of toggle'
				}
			}
		}
	}),
	[TYPE_VEC4]: createSchemaObject(TYPE_VEC4, { 
		value: createSchemaProp( TYPE_ARR, { 
			default: [0,0,0,0],
			items: {
				type: 'number'
			},
			minItems: 4,
			maxItems: 4
		}),
		formats: {
			[AUI_COLOR]: { 
				colorspace: createSchemaProp( TYPE_STR, {
					oneOf: ['RGB','RGBA','CMYK','HSL','HSLA','HSV','HSVA']
				})
			},
		}
	}),

	[TYPE_NUM]: createSchemaObject( TYPE_NUM, {  
		value: createSchemaProp(TYPE_NUM, { default: 0.5 }),
		formats: {
			[AUI_ICON]: {
				value: createSchemaProp(TYPE_NUM, { default: 0, min: 0, step: 1 }),
				...createWidthHeightDefaults('80px', '80px'),
				ui_rounded: {
					type: ['array', 'number'],
					items: {
						type: 'number'
					},
					default: [1,1,1,1],
					maxItems: 4,
					description: 'roundedness of content box'

				},
				ui_outline: {
					type: 'string',
					default: null
				},
				ui_padding: {
					type: 'number',
					default: 0.1,
					min: 0,
					max: 1,
					description: 'padding as percentage of shortest side'
				},
				icon_thickness: {
					type: 'number',
					default: 1,
					min: 0,
					max: 1,
					description: 'thickness of icon shapes'
				},
				icon_roundness: {
					type: 'number',
					default: 1,
					min: 0,
					max: 1,
					description: 'roundness of icon shapes'
				},
				icon_rotate: {
					type: 'number',
					default: 0,
					min: 0,
					max: 360,
					step: 1,
					description: 'rotate static icon position in 350deg'
				},
				spin_amount: {
					type: 'number',
					default: 0,
					min: -1,
					max: 1,
					step: 0.1,
					description: 'spin icon on Z axis'
				},
				spin_finish: {
					type: 'boolean',
					default: 1,
					description: 'return to original position if spinning'
				},
				pulse_amount: {
					type: 'number',
					default: 0,
					min: -1,
					max: 1,
					step: 0.1,
					description: 'pulse icon on Z axis'
				},
				pulse_speed: {
					type: 'number',
					default: 0,
					min: 0,
					max: 1,
					step: 0.1,
					description: 'rate of pulsing'
				},
				pulse_opacity: {
					type: 'number',
					default: 0,
					min: 0,
					max: 1,
					step: 0.1,
					description: 'change opacity with pulse'
				},
				color_invert: {
					type: 'boolean',
					default: false,
					description: 'invert the icon'
				},
				color_blend: {
					type: 'number',
					default: 0,
					min: 0,
					max: 2,
					step: 1,
					description: 'blend with multiply of overlay opacity'
				}
			},
			[AUI_SLIDER]: { 
				...createWidthHeightDefaults('200px', '2em'),
				...RULE_VISUAL_POS, 
				...RULE_MINMAX,
				...RULE_STEP,
				...RULE_SMOOTHING,
				vertical: {
					type: 'boolean',
					default: false,
					description: 'rotate slider 90 degrees'
				},
				...RULE_TICKS
			},
			[AUI_KNOB]: { 
				...createWidthHeightDefaults('200px', '200px'),
				...RULE_VISUAL_POS,
				...RULE_MINMAX,
				...RULE_STEP,
				...RULE_SMOOTHING,
				ui_range: {
					type: 'number',
					default: 270,
					description: 'set the rotational size of the knob',
					min: 30,
					max: 360
				},
				ui_padding: {
					type: 'number',
					default: 0,
					items: {
						type: 'number'
					},
					min: 0,
					max: 1
				},
				ui_outline: {
					type: 'string',
					default: null
				},
				ui_rounded: {
					type: 'boolean',
					default: true
				},
				ui_thickness: {
					type: 'number',
					default: 0.2,
					min: 0,
					max: 1,
					description: 'thickness of the line'
				},
				track_outline: {
					type: 'string',
					default: null
				},
				...RULE_HANDLE_RECT,
				handle_offset: {
					type: 'number',
					default: 0,
					min: -1,
					max: 1,
					description: 'height of the handle'
				},
				handle_outline: {
					type: 'string',
					default: null
				},
				...RULE_TICKS
			},
			[AUI_NUMBOX]: { 
				...createWidthHeightDefaults('200px', '2em'),
				min: {
					type: 'number',
					default: null
				},
				max: {
					type: 'number',
					default: null
				},
				step: {
					type: 'number',
					default: null,
					min: 0,
					max: null,
					description: 'step of numbox'
				},
				sensitivity: {
					type: 'number',
					default: 0.5,
					description: 'sensitivity to dragging motion',
					min: 0,
					max: 1
				},
				instant: {
					type: 'boolean',
					default: false,
					description: 'update value instantly on input'
				}
			},
			[AUI_SELECTOR]: { 
				value: createSchemaProp(TYPE_NUM, { default: 0, min: 0, step: 1 }),
				...createWidthHeightDefaults('200px', '2em'),
				options: createSchemaProp('array', { 
					default: ['A B C D E','B C D E F','C D E F G'],
					items: {
						type: [ TYPE_STR, TYPE_OBJ, TYPE_NUM ]
					}
				})
			}
		},
	}),
	[TYPE_VEC2]: createSchemaObject(TYPE_VEC2, { 
		rotate: createSchemaProp(TYPE_NUM, { default: 0 }) ,
		value: createSchemaProp('array', { 
			default: [0,0],
			items: {
				type: 'number'
			},
			minItems: 2,
			maxItems: 2
		}),
		formats: {
			[AUI_RANGE]: {
				...RULE_XY_MINMAX,
				...RULE_STEP,
				...RULE_SMOOTHING
			},
			[AUI_AXIS]: {
				...RULE_XY_MINMAX,
				...RULE_STEP,
				...RULE_SMOOTHING
			},
			[AUI_JOYSTICK]: {
				...createWidthHeightDefaults('200px', '200px'),
				...RULE_XY_MINMAX,
				...RULE_SMOOTHING,
				spring: {
					type: 'boolean',
					default: false,
					description: 'return to middle position on release'
				},
				ui_outline: {
					type: 'string',
					default: null
				},
				handle_size: {
					type: 'number',
					default: 0.2,
					min: 0,
					max: 1,
					description: 'size of the handle'
				},
				handle_rounded: {
					type: 'number',
					default: 1,
					description: 'radius of handle'
				},
				...RULE_TICKS
			}
		}
	}),
	[TYPE_STR]: createSchemaObject(TYPE_STR, { 
		value: createSchemaProp(TYPE_STR, { default: '' }),
		formats: {
			[AUI_TEXTBOX]: {
				...createWidthHeightDefaults('200px', '200px'),
				rows: {
					type: 'number',
					default: 1,
					min: 1,
					max: null,
					step: 1,
					description: 'auto-switches to textarea if > 1'
				},
				instant: {
					type: 'boolean',
					default: false,
					description: 'update value instantly on input'
				}
			}
		}
	})
}

export const SCHEMA = (e => {
	let schema = {}
	for (const [name,o] of Object.entries(PROTOTYPE)) {
		let object = { 
			type: o.type, 
			properties: {}
		}
		for (const [key,prop] of Object.entries(o.properties)) {
			if (key != 'formats' && key != 'format') object.properties[key] = prop
		}
		schema[name] = { 
			type: object.type, 
			properties: { 
				...object.properties, 
				format: createSchemaList( Object.keys(o.properties.formats) )
			} 
		}
		for (const [key,props] of Object.entries(o.properties.formats)) {
			schema[key] = { 
				type: object.type, 
				properties: { ...object.properties, ...props } 
			}
		}

	}

	return schema
})()
