// types...

export const Location = {
	LEFT: -1,
	CENTER: 0,
	RIGHT: 1
}

export const Int = (v) => {
	return parseInt( v )
}
export const Float = (v, d) => {
	if (d) return parseFloat(v).toPrecision(d)
	return parseFloat( v )
}
export const XY = (x, y) => {
	return {x: x, y: y}
}
export const XYZ = (x, y, z) => {
	return {x: x, y: y, z: z}
}
export const RGBA = (r, g, b, a) => {
	return {r: r, g: g, b: b, a: a}
}
export const HSLA = (h, s, l, a) => {
	return {h: h, s: s, l: l, a: a}
}
export const OPT = (value, name, meta) => {
	return { value, name, meta: {...meta} }
}

export const LRTB = (l,r,t,b) => {
	l = l || 10
	if (r == undefined && t == undefined && b == undefined) {
		r = l
		t = r
		b = r
	} else if (r != undefined && t == undefined && b == undefined) {
		t = r
		b = r
		r = l
	} else if (r != undefined && t != undefined && b == undefined) {
		b = t
	}
	return {
		left: l,
		right: r,
		top: t,
		bottom: b
	}
}

export const CopyXY = (p) => {
	return {x: p.x, y: p.y}
}
export const CopyXYZ = (p) => {
	return {x: p.x, y: p.y, z: p.z}
}
export const CopyRGBA = (c) => {
	return {r: c.r, g: c.g, b: c.b, a: c.a}
}
export const CopyHSLA = (c) => {
	return {h: c.h, s: c.s, l: c.l, a: c.a}
}

export const HSLA2CSS = (c) => {
	return `hsla(${parseInt(c.h*360)}, ${c.s*100}%, ${c.l*100}%, ${c.a})`
}
