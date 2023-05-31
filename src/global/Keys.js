import OSKey from 'os-key'
import { browser } from '$app/environment'

const nav = browser ? window.navigator : {}
export const OS_KEYS = browser ? OSKey(nav.userAgent) : {}
export const CMD_KEY = 'UniversalCommand'
export const SHIFT_KEY = 'Shift'
export const ESC_KEY = 'Escape'
export const CTRL_KEY = 'Control'
export const LOCAL_CMD_KEY = (OS_KEYS.primaryMeta) ? 'Meta' : 'Control'