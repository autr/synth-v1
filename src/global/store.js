import { writable } from 'svelte/store'

export const _context_menu = writable(null) // structure (array)
export const _keys = writable({}) // boolean flags (object)