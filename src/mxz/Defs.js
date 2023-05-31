import BlendModes from './compiler/_BlendModes.js'

export const BLEND_MODES = BlendModes().map( bm => bm.name )

export const APP_VIEWS = {
	APPLICATION: 'application',
	ASSIGNMENTS: 'assignments',
	DEBUG_SHADER: 'debug_shader',
	DEBUG_SYSTEM: 'debug_system',
	MIXER: 'mixer',
}


export const TYPE_UNI_MAP = {
  float: 'float',
  image: 'sampler2D',
  bool: 'bool',
  event: 'bool',
  long: 'int',
  color: 'vec4',
  point2D: 'vec2',
}
export const GUI_UNI_MAP = {
	'OpSelect': 'vec4'
}

export const COMPILER_TAGS = {
	START: `\n/*--BEGIN_PROJECT--`,
	END: `--END_PROJECT--*/\n`
}

export const KEYS = {
	BACKSPACE: 'Backspace',
	ESCAPE: 'Escape'
}

export const COMMON_ARGS = {
	BL_MODE: 'BlendMode',
	BL_AMT: 'BlendAmt'
}

export const DIMENSIONS = {
	NTSE: {
		width: 720,
		height: 480
	},
	NTSEx2: {
		width: 1440,
		height: 960
	},
	PAL: {
		width: 720,
		height: 576
	},
	PALx2: {
		width: 1440,
		height: 1152
	},
	HDMAC: {
		width: 1440,
		height: 1152
	},
	HD720: {
		width: 1280,
		height: 720
	},
	FHD1080: {
		width: 1920,
		height: 1080
	}
}

export const COMPILER_TYPES = {
	DEF: 'define',
	VAR: 'variable',
	FUNC: 'function',
	COMMENT: 'comment'
}

export const COMPILER_MODES = {
	PAUSE: 'pause',
	COMPILE: 'compile',
	DONE: 'done'
}

export const MEDIA_TYPES = {
	IMAGE: 'image',
	VIDEO: 'video',
	CAMERA: 'camera',
	FEEDBACK: 'feedback'
}


export let MEDIA_DEFAULTS = e => {
	return new Promise( (resolve,reject) => {

		let defaults = [
			{
				type: MEDIA_TYPES.IMAGE,
				path: 'mxz/testcards/transparent.png'
			},
			{
				type: MEDIA_TYPES.IMAGE,
				path: 'mxz/testcards/bw.jpg'
			},
			{
				type: MEDIA_TYPES.IMAGE,
				path: 'mxz/testcards/testcard.png'
			},
			{
				type: MEDIA_TYPES.IMAGE,
				path: 'mxz/testcards/grid.png'
			},
			{
				type: MEDIA_TYPES.FEEDBACK
			}
		]

		import('$app/environment').then( env => {
			const { browser } = env
			if (browser) {

				navigator.mediaDevices.enumerateDevices().then(function(devices) {
				  devices.forEach( device => {
				  	if (device.kind == 'videoinput') {
				  		defaults.push({
				  			type: MEDIA_TYPES.CAMERA,
				  			path: device.label
				  		})
				  	}
				  })

					resolve(defaults)
				})
			} else {
				resolve(defaults)
			}
		}).catch( err => {
			resolve(defaults)
		})



	})
}

export const TYPES = {
	SOURCE: 'source',
	UNIT: 'unit'
}

export const DRAG_ACTIONS = {
	APPEND: 'append',
	INSERT: 'insert',
	MOVE: 'move',
	BIN: 'bin'
}

