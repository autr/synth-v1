const int hardMax = 99999;
float cap = 0.;
float battery = 0.;
bool discharging = false;
vec3 outpix = vec3(0.);
vec2 pos = gl_FragCoord.xy;

float xx = direction == 1 ? pos.x :  center.x * RENDERSIZE.x;
float yy = direction == 0 ? pos.y :  center.y * RENDERSIZE.y;

vec2 centerPix = vec2(xx,yy);
int dist = int( distance(centerPix, pos) );
float angle = ANGLE(centerPix, pos) + 180.;
float res = resistance;
if (type ==0) res *= 2.;

for (int i = 0; i < hardMax; i++) {

	
	/* CAPACITOR */

	vec2 lookup = vec2(xx,yy);
	vec3 rgb = IMG_PIXEL( TEXTURE, lookup ).rgb;
	float pix = length(rgb)/3.;
	pix = (rgb.r + rgb.g + rgb.b)/3.;
	pix = pow(pix, power);
	
	if (type == 0) { // DIGITAL
	
		cap += pix;
		if (cap > res) cap -= res;

		
	} else if (type == 1) { // ANALOG
	
		if (battery < res && !discharging) battery += pix;
		if (battery > res) discharging = true;
		if (battery < 0.) discharging = false;
		
		if (discharging) {
			cap = battery;
			battery -= ((discharge.x * 20.)+0.05) + (discharge.y / 5.);// - (pix * bleedThrough);
		} else {
			cap = 0.;
		}
	} else if (type == 2) { // ADDITIVE
		cap += pix;
		cap -= discharge.x;
	}
	
	/* LOOP */
	
	int idx = direction == 3 ? dist - i : i;
	vec2 outward = VEC2_FROM_ANGLE(centerPix, angle, float(idx));
	
	xx = direction == 1 ? gl_FragCoord.x : outward.x;
	yy = direction == 0 ? gl_FragCoord.y : outward.y;
	
	if (i >= dist) break;
	
}

cap /= res;


//cap = pow( cap, capPower);
//if (useEdge) cap = step(1.-edgeSize, cap);



return vec4( HSL_TO_RGB(vec3(hue,saturation,cap*lightness)), INPUT.a);