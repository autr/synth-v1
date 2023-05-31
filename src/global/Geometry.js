import { XY } from './Types.js'

export const AngleXY = (xy, angle, distance) => {
    return {
	    x: Math.cos(angle * Math.PI / 180) * distance + xy.x,
	    y: Math.sin(angle * Math.PI / 180) * distance + xy.y
	}
};

export const AngleVec2 = (xy, angle, distance) => {
    return [
	    Math.cos(angle * Math.PI / 180) * distance + xy[0],
	    Math.sin(angle * Math.PI / 180) * distance + xy[1]
	]
};

export const IntersectXY = (a,b,c,d) => {
    let ua, ub, denom = (d.y - c.y)*(b.x - a.x) - (d.x - c.x)*(b.y - a.y);
    if (denom == 0) {
        return null;
    }
    ua = ((d.x - c.x)*(a.y - c.y) - (d.y - c.y)*(a.x - c.x))/denom;
    ub = ((b.x - a.x)*(a.y - c.y) - (b.y - a.y)*(a.x - c.x))/denom;
    return {
        x: a.x + ua * (b.x - a.x),
        y: a.y + ua * (b.y - a.y),
        seg1: ua >= 0 && ua <= 1,
        seg2: ub >= 0 && ub <= 1
    };
}

export const RadiansToVec2 = ( a, b ) => {
	if (!b) b = XY(0.5,0.5)
	return Math.atan2(b.y - a.y, b.x - a.x);
}

/* returns -180 to 180 */

export const AngleToVec2 = ( a, b ) => {
	if (!b) b = XY(0.5,0.5)
	return RadiansToVec2(a,b) * 180.0 / Math.PI
}

export const Scale = (num, in_min, in_max, out_min, out_max, clamp) => {
	if (clamp == undefined) clamp = false;
	const o = (num - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
	return (clamp) ? Clamp(o, out_min, out_max) : o;
};
export const ScaleXY = (num, in_min, in_max, out_min, out_max) => {
  return {
  	x: (num.x - in_min.x) * (out_max.x - out_min.x) / (in_max.x - in_min.x) + out_min.x,
  	y: (num.y - in_min.y) * (out_max.y - out_min.y) / (in_max.y - in_min.y) + out_min.y
  }
};
export const ScaleVec2 = (num, in_min, in_max, out_min, out_max) => {
  return [
  	(num[0] - in_min[0]) * (out_max[0] - out_min[0]) / (in_max[0] - in_min[0]) + out_min[0],
  	(num[1] - in_min[1]) * (out_max[1] - out_min[1]) / (in_max[1] - in_min[1]) + out_min[1]
  ]
};
export const Clamp = (v, min, max) => {
	if (v < min) v = min;
	if (v > max) v = max;
	return v;
};
export const ClampXY = (v, min, max) => {
	if (v.x < min) v.x = min;
	if (v.x > max) v.x = max;
	if (v.y < min) v.y = min;
	if (v.y > max) v.y = max;
	return v;
};


// trigonometry...

export const Distance = (x1, y1, x2, y2) => {
	return Math.sqrt( Math.pow((x1-x2), 2) + Math.pow((y1-y2), 2) );
};
export const DistanceXY = (a, b) => {
	return Math.sqrt( Math.pow((a.x-b.x), 2) + Math.pow((a.y-b.y), 2) );
};
export const FindClosest = (p, points) => {
	let dist = 999999;
	let out = null;
	for ( let i = 0; i < points.length; i++) {
		const d = Distance(p.x,p.y,points[i].x,points[i].y);
		if (d < dist) {
			dist = d;
			out = i;
		}
	}
	return out;
};

// steps...

export const CompareXY = (a, b, steps) => {
	const aa = (steps !== undefined) ? RoundedXYZ(a,steps) : CopyXY(a);
	const bb = (steps !== undefined) ? RoundedXYZ(b,steps) : CopyXY(b);
	const out = (aa.x === bb.x && aa.y === bb.y);
	return out;
}

export const RoundedXYZ = ( point, steps ) => {
	return {
		x: Math.round(point.x * steps)/steps,
		y: Math.round(point.y * steps)/steps,
		z: Math.round(point.z * steps)/steps
	}
}

// blending...

export const BlendXYZ = ( a, b, smooth ) => {

	return {
		x: (a.x * smooth) + (b.x * (1.0-smooth)),
		y: (a.y * smooth) + (b.y * (1.0-smooth)),
		z: (a.z * smooth) + (b.z * (1.0-smooth))
	}
}

export const RotateXY = (origin, point, angle) => {
  let rad = (Math.PI / 180) * angle,
    cos = Math.cos(rad),
    sin = Math.sin(rad),
    run = point.x - origin.x,
    rise = point.y - origin.y,
    cx = (cos * run) + (sin * rise) + origin.x,
    cy = (cos * rise) - (sin * run) + origin.y
  return {
    x: cx,
    y: cy
  }
}

// dom world to normalised and back again...

export const Div2NormXYZ = ( e, div, rot, center ) => {
	const bounds = div.getBoundingClientRect()
	let { width, height, left, top } = bounds
	let x = left
	let y = top
	let w = left + width
	let h = top + height
	let p = {
		x: Scale(e.clientX, left, left + width, 0, 1),
		y: Scale(e.clientY, top, top + height, 0, 1)
	}
	if (!center) center = XY(0.5,0.5)
	if (rot != 0) p = RotateXY( center, p, rot )
	p.z = AngleToVec2( center, RotateXY(center, p, -90) )
	return p
};
export const Norm2DivXYZ = ( point, div, rot ) => {
	const bounds = div.getBoundingClientRect();
	const p = {
		x: Scale(point.x, 0, 1, bounds.left, bounds.left + bounds.width),
		y: Scale(point.y, 0, 1, bounds.top, bounds.top + bounds.height)
	}
	return p;
};
