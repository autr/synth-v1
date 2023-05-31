# AUI

```
{
	"name": {
		"type": "string",
		"default": "",
		"description": "descriptive name for the ui element, ie. \"opacity\""
	},
	"id": {
		"type": "string",
		"default": "",
		"description": "unique id must be set automatically via sync, or user defined"
	},
	"url": {
		"type": "string",
		"default": "",
		"description": "recursive url format id for automatic sync"
	},
	"tabindex": {
		"type": "number",
		"default": 0,
		"description": "important for accesibility"
	},
	"style": {
		"type": "string",
		"default": ""
	},
	"class": {
		"type": "string",
		"default": ""
	}
}
```

## buffer `buffer`

```
{
	"value": {
		"type": "buffer",
		"default": []
	},
	"items": {
		"type": [
			"number",
			"array"
		]
	},
	"format": {
		"type": "string",
		"default": "Waveform",
		"oneOf": [
			"Waveform"
		]
	}
}
```

## Waveform `buffer`

```
{
	"value": {
		"type": "buffer",
		"default": []
	},
	"items": {
		"type": [
			"number",
			"array"
		]
	}
}
```

## boolean `boolean`

```
{
	"value": {
		"type": "boolean",
		"default": false
	},
	"format": {
		"type": "string",
		"default": "Button",
		"oneOf": [
			"Button",
			"Toggle"
		]
	}
}
```

## Button `boolean`

```
{
	"value": {
		"type": "boolean",
		"default": false
	},
	"width": {
		"type": "vec2",
		"default": null,
		"editor": "200px",
		"description": "default width for this element"
	},
	"height": {
		"type": "vec2",
		"default": null,
		"editor": "2em",
		"description": "default height for this element"
	},
	"icon": {
		"type": "number",
		"step": 1,
		"default": null
	},
	"position": {
		"type": "number",
		"default": 0,
		"min": 0,
		"max": 3
	}
}
```

## Toggle `boolean`

```
{
	"value": {
		"type": "boolean",
		"default": false
	},
	"width": {
		"type": "vec2",
		"default": null,
		"editor": "50px",
		"description": "default width for this element"
	},
	"height": {
		"type": "vec2",
		"default": null,
		"editor": "2em",
		"description": "default height for this element"
	},
	"safety_drag": {
		"type": "boolean",
		"default": false,
		"description": "simulate a smartphone unlock slider"
	},
	"ui_rounded": {
		"type": "number",
		"default": 1,
		"description": "roundedness of toggle"
	},
	"ui_outline": {
		"type": "string",
		"default": null
	},
	"handle_padding": {
		"type": "number",
		"default": 0.1,
		"min": 0,
		"max": 1
	},
	"handle_outline": {
		"type": "number",
		"default": 0.1,
		"min": 0,
		"max": 1,
		"description": "outline of toggle"
	}
}
```

## vec4 `array`

```
{
	"value": {
		"type": "array",
		"default": [
			0,
			0,
			0,
			0
		],
		"items": {
			"type": "number"
		},
		"minItems": 4,
		"maxItems": 4
	},
	"format": {
		"type": "string",
		"default": "Color",
		"oneOf": [
			"Color"
		]
	}
}
```

## Color `array`

```
{
	"value": {
		"type": "array",
		"default": [
			0,
			0,
			0,
			0
		],
		"items": {
			"type": "number"
		},
		"minItems": 4,
		"maxItems": 4
	},
	"colorspace": {
		"type": "string",
		"oneOf": [
			"RGB",
			"RGBA",
			"CMYK",
			"HSL",
			"HSLA",
			"HSV",
			"HSVA"
		]
	}
}
```

## number `number`

```
{
	"value": {
		"type": "number",
		"default": 0.5
	},
	"format": {
		"type": "string",
		"default": "Icon",
		"oneOf": [
			"Icon",
			"Slider",
			"Knob",
			"Numbox",
			"Selector"
		]
	}
}
```

## Icon `number`

```
{
	"value": {
		"type": "number",
		"default": 0,
		"min": 0,
		"step": 1
	},
	"width": {
		"type": "vec2",
		"default": null,
		"editor": "80px",
		"description": "default width for this element"
	},
	"height": {
		"type": "vec2",
		"default": null,
		"editor": "80px",
		"description": "default height for this element"
	},
	"ui_rounded": {
		"type": [
			"array",
			"number"
		],
		"items": {
			"type": "number"
		},
		"default": [
			1,
			1,
			1,
			1
		],
		"maxItems": 4,
		"description": "roundedness of content box"
	},
	"ui_outline": {
		"type": "string",
		"default": null
	},
	"ui_padding": {
		"type": "number",
		"default": 0.1,
		"min": 0,
		"max": 1,
		"description": "padding as percentage of shortest side"
	},
	"icon_thickness": {
		"type": "number",
		"default": 1,
		"min": 0,
		"max": 1,
		"description": "thickness of icon shapes"
	},
	"icon_roundness": {
		"type": "number",
		"default": 1,
		"min": 0,
		"max": 1,
		"description": "roundness of icon shapes"
	},
	"icon_rotate": {
		"type": "number",
		"default": 0,
		"min": 0,
		"max": 360,
		"step": 1,
		"description": "rotate static icon position in 350deg"
	},
	"spin_amount": {
		"type": "number",
		"default": 0,
		"min": -1,
		"max": 1,
		"step": 0.1,
		"description": "spin icon on Z axis"
	},
	"spin_finish": {
		"type": "boolean",
		"default": 1,
		"description": "return to original position if spinning"
	},
	"pulse_amount": {
		"type": "number",
		"default": 0,
		"min": -1,
		"max": 1,
		"step": 0.1,
		"description": "pulse icon on Z axis"
	},
	"pulse_speed": {
		"type": "number",
		"default": 0,
		"min": 0,
		"max": 1,
		"step": 0.1,
		"description": "rate of pulsing"
	},
	"pulse_opacity": {
		"type": "number",
		"default": 0,
		"min": 0,
		"max": 1,
		"step": 0.1,
		"description": "change opacity with pulse"
	},
	"color_invert": {
		"type": "boolean",
		"default": false,
		"description": "invert the icon"
	},
	"color_blend": {
		"type": "number",
		"default": 0,
		"min": 0,
		"max": 2,
		"step": 1,
		"description": "blend with multiply of overlay opacity"
	}
}
```

## Slider `number`

```
{
	"value": {
		"type": "number",
		"default": 0.5
	},
	"width": {
		"type": "vec2",
		"default": null,
		"editor": "200px",
		"description": "default width for this element"
	},
	"height": {
		"type": "vec2",
		"default": null,
		"editor": "2em",
		"description": "default height for this element"
	},
	"position": {
		"type": "string",
		"default": -1,
		"oneOf": [
			-1,
			0,
			1
		]
	},
	"min": {
		"type": "number",
		"default": 0
	},
	"max": {
		"type": "number",
		"default": 1
	},
	"resolution": {
		"type": "number",
		"default": false
	},
	"smoothing": {
		"type": "number",
		"default": 0.2,
		"min": 0,
		"max": 1
	},
	"vertical": {
		"type": "boolean",
		"default": false,
		"description": "rotate slider 90 degrees"
	},
	"tick_divisions": {
		"type": "number",
		"default": 3,
		"step": 1,
		"min": -1,
		"max": 30,
		"description": "number of visual ticks"
	},
	"tick_width": {
		"type": "number",
		"default": 0.2,
		"min": 0,
		"max": 1,
		"description": "width of the ticks"
	},
	"tick_height": {
		"type": "number",
		"default": 0.2,
		"min": 0,
		"max": 1,
		"description": "height of the ticks"
	},
	"tick_offset": {
		"type": "number",
		"default": 0,
		"min": -10,
		"max": 10,
		"step": 0.2,
		"description": "height of the ticks"
	},
	"tick_rounded": {
		"description": "rounded sides of ticks",
		"type": [
			"array",
			"number"
		],
		"items": {
			"type": "number"
		},
		"default": [
			1,
			1,
			1,
			1
		],
		"maxItems": 4
	}
}
```

## Knob `number`

```
{
	"value": {
		"type": "number",
		"default": 0.5
	},
	"width": {
		"type": "vec2",
		"default": null,
		"editor": "200px",
		"description": "default width for this element"
	},
	"height": {
		"type": "vec2",
		"default": null,
		"editor": "200px",
		"description": "default height for this element"
	},
	"position": {
		"type": "string",
		"default": -1,
		"oneOf": [
			-1,
			0,
			1
		]
	},
	"min": {
		"type": "number",
		"default": 0
	},
	"max": {
		"type": "number",
		"default": 1
	},
	"resolution": {
		"type": "number",
		"default": false
	},
	"smoothing": {
		"type": "number",
		"default": 0.2,
		"min": 0,
		"max": 1
	},
	"ui_range": {
		"type": "number",
		"default": 270,
		"description": "set the rotational size of the knob",
		"min": 30,
		"max": 360
	},
	"ui_padding": {
		"type": "number",
		"default": 0,
		"items": {
			"type": "number"
		},
		"min": 0,
		"max": 1
	},
	"ui_outline": {
		"type": "string",
		"default": null
	},
	"ui_rounded": {
		"type": "boolean",
		"default": true
	},
	"ui_thickness": {
		"type": "number",
		"default": 0.2,
		"min": 0,
		"max": 1,
		"description": "thickness of the line"
	},
	"track_outline": {
		"type": "string",
		"default": null
	},
	"handle_width": {
		"type": "number",
		"default": 0.5,
		"min": 0,
		"max": 2,
		"description": "width of the handle"
	},
	"handle_height": {
		"type": "number",
		"default": 0.5,
		"min": 0,
		"max": 2,
		"description": "height of the handle"
	},
	"handle_rounded": {
		"description": "rounded sides of ticks",
		"type": [
			"array",
			"number"
		],
		"items": {
			"type": "number"
		},
		"default": [
			1,
			1,
			1,
			1
		],
		"maxItems": 4
	},
	"handle_offset": {
		"type": "number",
		"default": 0,
		"min": -1,
		"max": 1,
		"description": "height of the handle"
	},
	"handle_outline": {
		"type": "string",
		"default": null
	},
	"tick_divisions": {
		"type": "number",
		"default": 3,
		"step": 1,
		"min": -1,
		"max": 30,
		"description": "number of visual ticks"
	},
	"tick_width": {
		"type": "number",
		"default": 0.2,
		"min": 0,
		"max": 1,
		"description": "width of the ticks"
	},
	"tick_height": {
		"type": "number",
		"default": 0.2,
		"min": 0,
		"max": 1,
		"description": "height of the ticks"
	},
	"tick_offset": {
		"type": "number",
		"default": 0,
		"min": -10,
		"max": 10,
		"step": 0.2,
		"description": "height of the ticks"
	},
	"tick_rounded": {
		"description": "rounded sides of ticks",
		"type": [
			"array",
			"number"
		],
		"items": {
			"type": "number"
		},
		"default": [
			1,
			1,
			1,
			1
		],
		"maxItems": 4
	}
}
```

## Numbox `number`

```
{
	"value": {
		"type": "number",
		"default": 0.5
	},
	"width": {
		"type": "vec2",
		"default": null,
		"editor": "200px",
		"description": "default width for this element"
	},
	"height": {
		"type": "vec2",
		"default": null,
		"editor": "2em",
		"description": "default height for this element"
	},
	"min": {
		"type": "number",
		"default": null
	},
	"max": {
		"type": "number",
		"default": null
	},
	"step": {
		"type": "number",
		"default": null,
		"min": 0,
		"max": null,
		"description": "step of numbox"
	},
	"sensitivity": {
		"type": "number",
		"default": 0.5,
		"description": "sensitivity to dragging motion",
		"min": 0,
		"max": 1
	},
	"instant": {
		"type": "boolean",
		"default": false,
		"description": "update value instantly on input"
	}
}
```

## Selector `number`

```
{
	"value": {
		"type": "number",
		"default": 0,
		"min": 0,
		"step": 1
	},
	"width": {
		"type": "vec2",
		"default": null,
		"editor": "200px",
		"description": "default width for this element"
	},
	"height": {
		"type": "vec2",
		"default": null,
		"editor": "2em",
		"description": "default height for this element"
	},
	"options": {
		"type": "array",
		"default": [
			"A B C D E",
			"B C D E F",
			"C D E F G"
		],
		"items": {
			"type": [
				"string",
				"object",
				"number"
			]
		}
	}
}
```

## vec2 `array`

```
{
	"rotate": {
		"type": "number",
		"default": 0
	},
	"value": {
		"type": "array",
		"default": [
			0,
			0
		],
		"items": {
			"type": "number"
		},
		"minItems": 2,
		"maxItems": 2
	},
	"format": {
		"type": "string",
		"default": "Range",
		"oneOf": [
			"Range",
			"Axis",
			"Joystick"
		]
	}
}
```

## Range `array`

```
{
	"rotate": {
		"type": "number",
		"default": 0
	},
	"value": {
		"type": "array",
		"default": [
			0,
			0
		],
		"items": {
			"type": "number"
		},
		"minItems": 2,
		"maxItems": 2
	},
	"min": {
		"type": "string",
		"default": [
			0,
			0
		],
		"items": {
			"type": "number"
		},
		"minItems": 2,
		"maxItems": 2
	},
	"max": {
		"type": "string",
		"default": [
			1,
			1
		],
		"items": {
			"type": "number"
		},
		"minItems": 2,
		"maxItems": 2
	},
	"resolution": {
		"type": "number",
		"default": false
	},
	"smoothing": {
		"type": "number",
		"default": 0.2,
		"min": 0,
		"max": 1
	}
}
```

## Axis `array`

```
{
	"rotate": {
		"type": "number",
		"default": 0
	},
	"value": {
		"type": "array",
		"default": [
			0,
			0
		],
		"items": {
			"type": "number"
		},
		"minItems": 2,
		"maxItems": 2
	},
	"min": {
		"type": "string",
		"default": [
			0,
			0
		],
		"items": {
			"type": "number"
		},
		"minItems": 2,
		"maxItems": 2
	},
	"max": {
		"type": "string",
		"default": [
			1,
			1
		],
		"items": {
			"type": "number"
		},
		"minItems": 2,
		"maxItems": 2
	},
	"resolution": {
		"type": "number",
		"default": false
	},
	"smoothing": {
		"type": "number",
		"default": 0.2,
		"min": 0,
		"max": 1
	}
}
```

## Joystick `array`

```
{
	"rotate": {
		"type": "number",
		"default": 0
	},
	"value": {
		"type": "array",
		"default": [
			0,
			0
		],
		"items": {
			"type": "number"
		},
		"minItems": 2,
		"maxItems": 2
	},
	"width": {
		"type": "vec2",
		"default": null,
		"editor": "200px",
		"description": "default width for this element"
	},
	"height": {
		"type": "vec2",
		"default": null,
		"editor": "200px",
		"description": "default height for this element"
	},
	"min": {
		"type": "string",
		"default": [
			0,
			0
		],
		"items": {
			"type": "number"
		},
		"minItems": 2,
		"maxItems": 2
	},
	"max": {
		"type": "string",
		"default": [
			1,
			1
		],
		"items": {
			"type": "number"
		},
		"minItems": 2,
		"maxItems": 2
	},
	"smoothing": {
		"type": "number",
		"default": 0.2,
		"min": 0,
		"max": 1
	},
	"spring": {
		"type": "boolean",
		"default": false,
		"description": "return to middle position on release"
	},
	"ui_outline": {
		"type": "string",
		"default": null
	},
	"handle_size": {
		"type": "number",
		"default": 0.2,
		"min": 0,
		"max": 1,
		"description": "size of the handle"
	},
	"handle_rounded": {
		"type": "number",
		"default": 1,
		"description": "radius of handle"
	},
	"tick_divisions": {
		"type": "number",
		"default": 3,
		"step": 1,
		"min": -1,
		"max": 30,
		"description": "number of visual ticks"
	},
	"tick_width": {
		"type": "number",
		"default": 0.2,
		"min": 0,
		"max": 1,
		"description": "width of the ticks"
	},
	"tick_height": {
		"type": "number",
		"default": 0.2,
		"min": 0,
		"max": 1,
		"description": "height of the ticks"
	},
	"tick_offset": {
		"type": "number",
		"default": 0,
		"min": -10,
		"max": 10,
		"step": 0.2,
		"description": "height of the ticks"
	},
	"tick_rounded": {
		"description": "rounded sides of ticks",
		"type": [
			"array",
			"number"
		],
		"items": {
			"type": "number"
		},
		"default": [
			1,
			1,
			1,
			1
		],
		"maxItems": 4
	}
}
```

## string `string`

```
{
	"value": {
		"type": "string",
		"default": ""
	},
	"format": {
		"type": "string",
		"default": "Textbox",
		"oneOf": [
			"Textbox"
		]
	}
}
```

## Textbox `string`

```
{
	"value": {
		"type": "string",
		"default": ""
	},
	"width": {
		"type": "vec2",
		"default": null,
		"editor": "200px",
		"description": "default width for this element"
	},
	"height": {
		"type": "vec2",
		"default": null,
		"editor": "200px",
		"description": "default height for this element"
	},
	"rows": {
		"type": "number",
		"default": 1,
		"min": 1,
		"max": null,
		"step": 1,
		"description": "auto-switches to textarea if > 1"
	},
	"instant": {
		"type": "boolean",
		"default": false,
		"description": "update value instantly on input"
	}
}
```

