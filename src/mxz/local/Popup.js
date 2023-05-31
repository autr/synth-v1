import { _DIMENSIONS, _popup_canvas, _recompile } from '$mxz/Store.js'
import { COMPILER_MODES } from '$mxz/Defs.js'
import { get } from 'svelte/store'
import { browser } from '$app/environment'
const w = browser ? window : {}

export async function togglePopup() {

	let popup = get(_popup_canvas)
	let dimensions = get(_DIMENSIONS)

	if (popup) {
		popup.close()
		_popup_canvas.set( null )
		_recompile.set( COMPILER_MODES.COMPILE )
		return null
	}
	const config = `toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=yes,width=${dimensions.width},height=${dimensions.height},top=0,left=0`

	popup = await w.open('', 'MXZ', config)
	popup.document.body.style = 'margin:0;padding:0;background:black;'
	const canvas = document.createElement('canvas')
	canvas.id = 'canvas'
	canvas.width = dimensions.width
	canvas.height = dimensions.height
	canvas.style = `position:fixed;top:0;left:0;width:100%;height:100%;`
	popup.document.body.appendChild(canvas)
	popup.document.title = 'MXZ'
	_popup_canvas.set( popup )
	_recompile.set( COMPILER_MODES.COMPILE )
	popup.addEventListener( 'beforeunload', e => {
		_popup_canvas.set(null)
		_recompile.set( COMPILER_MODES.COMPILE )
	})
	return popup
}