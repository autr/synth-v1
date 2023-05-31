import { writable } from 'svelte/store'

/* AUI Globals */

export const _globals = writable({
	resolution: 1024
})

export const _ids = writable({})