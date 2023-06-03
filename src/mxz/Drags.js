import { get } from 'svelte/store'
import { browser } from '$app/environment'
import { _SEQUENCE, _UNIFORMS, _selected, _dragging, _recompile} from './store.js'
import { DRAG_ACTIONS, COMPILER_MODES } from './defs.js'
import { MakeSequenceAdjustment, ClearUpUniforms } from '$mxz/API.js'

const w = (browser) ? window : {}
export function onElDragover(e) {
	if (!get(_dragging)) return
	e = e.detail ? e.detail : e

	const composedPath = e.composedPath()

	let el = composedPath.find( el => {
		return el.getAttribute('data-drag-type')
	})
	for (const elel of document.querySelectorAll('.draggedover')) elel.classList.remove('draggedover')
	if (el) el.classList.add('draggedover')
	e.preventDefault()
}

export function onElDrop(e) {
	if (!get(_dragging)) return
	e = e.detail ? e.detail : e

	const composedPath = e.composedPath()
	let el = composedPath.find( el => {
		return el.getAttribute('data-drag-type')
	})
	let type = el.getAttribute('data-drag-type')
	let colIdx = parseInt(el.getAttribute('data-drag-colIdx'))
	let rowIdx = parseInt(el.getAttribute('data-drag-rowIdx'))

	for (const elel of document.querySelectorAll('.draggedover')) elel.classList.remove('draggedover')

	const selected = get(_selected)
	const overrideCandidates = (typeof selected?.[0] == 'string') ? selected : []

	_recompile.set( COMPILER_MODES.PAUSE )
	MakeSequenceAdjustment( type, rowIdx, colIdx, overrideCandidates )
	_dragging.set( false )
	_selected.set( null )
	ClearUpUniforms()

	w.requestAnimationFrame( e => {
		_recompile.set( COMPILER_MODES.COMPILE )
	})

}
