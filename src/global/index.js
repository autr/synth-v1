
export * as Colors from './Colors.js'
export * as Geometry from './Geometry.js'
export * as Types from './Types.js'


export const Objects = {
    isEmptyObject: (obj) => {
        return Object.keys(obj).length === 0 && obj.constructor === Object
    },
    cloneObject: (obj) => {
        return JSON.parse(JSON.stringify(obj))
    },
    isSameObject: (a_, b_) => {
        const a = JSON.stringify(a_)
        const b = JSON.stringify(b_)
        return (a == b)
    }
}