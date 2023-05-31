
import { browser } from '$app/environment'
import { writable } from 'svelte/store'
import { get } from 'svelte/store'/* _PREVIEW:  */
export const _PREVIEW = writable( null )

/* _TITLES:  */
export const _TITLES = writable( {} )

/* _SOURCES:  */
export const _SOURCES = writable( [] )

/* _SEQUENCE:  */
export const _SEQUENCE = writable( [] )

/* _UNIFORMS:  */
export const _UNIFORMS = writable( {} )

/* _CURRENT_VIEW:  */
export const _CURRENT_VIEW = writable( "application" )

/* _DIMENSIONS:  */
export const _DIMENSIONS = writable( {"width":720,"height":576} )

/* _ASSIGNMENTS:  */
export const _ASSIGNMENTS = writable( {} )

/* _HIDDEN:  */
export const _HIDDEN = writable( {} )

/* _def_lookup: operator lookup table by id */
export const _def_lookup = writable( {} )

/* _recompile: boolean */
export const _recompile = writable( "compile" )

/* _selected: must be [[0,0],[0,0]] or [{},{},{}] or [Name,Name,Name] */
export const _selected = writable( null )

/* _dragging: bool */
export const _dragging = writable( false )

/* _source_select: ? */
export const _source_select = writable( null )

/* _contextmenu_active: show */
export const _contextmenu_active = writable( false )

/* _contextmenu_learning: pick up mode */
export const _contextmenu_learning = writable( false )

/* _popup_canvas: pointer to window object */
export const _popup_canvas = writable( null )

/* _fullscreen: make canvas fullscreen */
export const _fullscreen = writable( false )



const SAY = (m, e) => console.log(`[Store] ${m}`, e || '')

export function SetStoresFromText( text ) {

	try {
		const stores = JSON.parse( text )
		SAY("💾 loading stores from text", stores?._UNIFORMS)

		
		_PREVIEW.set( stores?._PREVIEW || null )
		_TITLES.set( stores?._TITLES || {} )
		_SOURCES.set( stores?._SOURCES || [] )
		_SEQUENCE.set( stores?._SEQUENCE || [] )
		_UNIFORMS.set( stores?._UNIFORMS || {} )
		_CURRENT_VIEW.set( stores?._CURRENT_VIEW || "application" )
		_DIMENSIONS.set( stores?._DIMENSIONS || {"width":720,"height":576} )
		_ASSIGNMENTS.set( stores?._ASSIGNMENTS || {} )
		_HIDDEN.set( stores?._HIDDEN || {} )

		if (browser) window.requestAnimationFrame( e => {

			SAY("🎨 setting uniforms and recompiling", stores?._UNIFORMS || '❌ NO UNIFORMS')
			_UNIFORMS.set( stores?._UNIFORMS || {} )
			_recompile.set( "compile" )

		})
	} catch(e) {
		SAY("❌ could not load stores", e.message)
	}
}

export function GetStoresAsText( space ) {
	return JSON.stringify({
		
		_PREVIEW: get(_PREVIEW),
		_TITLES: get(_TITLES),
		_SOURCES: get(_SOURCES),
		_SEQUENCE: get(_SEQUENCE),
		_UNIFORMS: get(_UNIFORMS),
		_CURRENT_VIEW: get(_CURRENT_VIEW),
		_DIMENSIONS: get(_DIMENSIONS),
		_ASSIGNMENTS: get(_ASSIGNMENTS),
		_HIDDEN: get(_HIDDEN),
	}, null, space)
}
export const Stores = {
	
	_PREVIEW: _PREVIEW,
	_TITLES: _TITLES,
	_SOURCES: _SOURCES,
	_SEQUENCE: _SEQUENCE,
	_UNIFORMS: _UNIFORMS,
	_CURRENT_VIEW: _CURRENT_VIEW,
	_DIMENSIONS: _DIMENSIONS,
	_ASSIGNMENTS: _ASSIGNMENTS,
	_HIDDEN: _HIDDEN,
}
	