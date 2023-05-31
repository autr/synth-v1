vec3 mask = INPUT.rgb;
vec3 foreground = INPUT.rgb;

if (Mode == 1) {
	mask = Mask.rgb;
	foreground = Foreground.rgb;
}

float amt;
float sat = RGB_TO_HSL(mask).y;


if (LightMode == 0) {
	// Lightness
	amt = RGB_TO_HSL(mask).z;
} else if (LightMode == 1) {
	// Brightness
	amt = RGB_TO_HSV(mask).z;
} else {
	// RGB
	amt = mask.r + mask.g + mask.b;
}

if (Invert) amt = 1.0 - amt;

float ll = MAP(Threshold.x,0.0,1.0,-0.1,1.1);
float hh = MAP(Threshold.y,0.0,1.0,-0.1,1.1);

float low = MAP(amt,ll, ll+Smooth.x,1.0,0.0, true);
float high = MAP(amt,hh-Smooth.y,hh,0.0,1.0, false);
float blend = CLAMP(max(low,high),-1.0,1.0);
blend = MAP(blend,0.0,1.0,-1.0,1.0);

blend *= 1.0 + (sat * SatInfluence * 1.);
blend = (blend+1.0)/2.0;

return vec4( mix(foreground,Background.rgb,blend), 1.0); // TODO