

export const CreateEnum = values => {
	const enumObject = {}
	for (const val of values) {
		enumObject[val] = val
	}
	return Object.freeze(enumObject)
}



export function Slugify (str) {
    str = str.replace(/^\s+|\s+$/g, ''); // trim
    str = str.toLowerCase()
  
    // remove accents, swap ñ for n, etc
    var from = "àáäâèéëêìíïîòóöôùúüûñç·/_,:;"
    var to   = "aaaaeeeeiiiioooouuuunc------"
    for (var i=0, l=from.length ; i<l ; i++) {
        str = str.replace(new RegExp(from.charAt(i), 'g'), to.charAt(i))
    }

    str = str.replace(/[^a-z0-9 -]/g, '') // remove invalid chars
        .replace(/\s+/g, '-') // collapse whitespace and replace by -
        .replace(/-+/g, '-'); // collapse dashes

    return str;
}


export function GetComputedVariableAsPx( el, key, override ) {
    const variable = el ? window.getComputedStyle( el ).getPropertyValue( key ) : '0px'
    const ref = override || el
    let px = CalculatePixels( variable, ref, override )
    px = parseFloat(px) || 0
    return parseFloat(px)
}


export function CalculatePixels( str, el, override ) {
    try {


        const reg = /\(([^)]+)\)/
        let value = parseFloat( str )
        if (!value) {
            str = getComputedStyle(document.documentElement).getPropertyValue( reg.exec(str)?.[1] )
            value = parseFloat( str )
        }
        const bounds = override ? override : (el?.parentElement ? el.parentElement.getBoundingClientRect() : {})
        const unit = str.replace(value, '').toLowerCase().trim()
        const { innerWidth, innerHeight } = window
        const run = {
            ['%']: () => ((Math.min(bounds?.width||0,bounds?.height||0) * (value/100))),
            px: () => value,
            vw: () => (innerWidth * (value/100)),
            vh: () => (innerHeight * (value/100)),
            vmax: () => (Math.max(innerWidth,innerHeight) * (value/100)),
            vmin: () => (Math.min(innerWidth,innerHeight) * (value/100)),
            em: () => (parseFloat(getComputedStyle(el?.parentElement || document.body).fontSize) * value),
            rem: () => (parseFloat(getComputedStyle(document.body).fontSize) * value),
            ['']: () => value
        }

        const out = run[unit]()
        // console.log(bounds.width, bounds.height, value)
        // console.log(`[CalculatePixels] ✅ parsed ${str}:`, out, {el})
        return out
    } catch(err) {
        console.error(`[CalculatePixels] could not parse ${str}:`, err.message)
        return 0
    }
} 

export function SetNonScalingStroke( outerEl ) {

    if (outerEl) {
        for (const el of outerEl.querySelectorAll('svg *') || []) {
            el.setAttribute('vector-effect','non-scaling-stroke')
        }
    }
}