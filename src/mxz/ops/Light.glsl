
float MINI = Mini ? 0.2 : 1.; // TODO

// CYCLE

vec3 hsl = RGB_TO_HSL( INPUT.rgb );


/*------------ MODES ------------*/

if (ColorMode == 3) {

	// TWEAKS

	float maxDelta = sqrt(hsl.y) - hsl.y;
	hsl.y += (maxDelta * Vibrance);

} else if (ColorMode == 1) {

	// TINY

	vec3 tint = vec3(TintHue / 360.0,1.0,0.5);
	hsl = RGB_TO_HSL(mix(HSL_TO_RGB(hsl),HSL_TO_RGB(tint),TintAmount * hsl.z * MINI));

} else if (ColorMode == 2) {

	// COLORIZE

	// float length = float(int(Levels));
	// float spacing = Spacing;
	// float total = length * spacing;
	// float light = (hsl.z * total);
	// float value = light / spacing;
	// float blend = FMOD( value, 1.0 );

	// float a = floor( value );
	// float b = floor( value * 1.0 ); 

	// vec3 A = HSL_TO_RGB(FMOD(a * spacing, 1.0), 1.0, 0.5);
	// vec3 B = HSL_TO_RGB(FMOD(b * spacing, 1.0), 1.0, 0.5);
	// hsl = RGB_TO_HSL(mix( A, B, blend ));


	float space = 1./Levels;
	float snapped = hsl.z - FMOD(hsl.z,space); // indexed
	float blend = FMOD(hsl.z,space)*Levels; // smooth
	if (blend > 0.5) blend -= blend - 0.5;
	blend *= 2.;

	float h1 = snapped * Spacing;
	float h2 = (snapped + space) * Spacing;
	vec3 rgb1 = HSL_TO_RGB(vec3(h1, 1.0, 0.5));
	vec3 rgb2 = HSL_TO_RGB(vec3(h2, 1.0, 0.5));

	hsl = RGB_TO_HSL(mix(rgb1,rgb2,blend*Smooth));

}

/*------------ SATURATION ------------*/

hsl.y += Saturation * MINI;
hsl.y = clamp( hsl.y, 0.0, 1.0 );
hsl.x = FMOD( hsl.x + (Shift * MINI), 1.0);

/*------------ LIGHT / RGB ------------*/

vec3 rgb = HSL_TO_RGB(hsl);
vec3 final;

if (LightMode == 0) {

	// LIGHTNESS

	vec3 hsl = RGB_TO_HSL(rgb);
	hsl.z += Light * MINI;
	final = HSL_TO_RGB(hsl);

} else if (LightMode == 1) {

	// EXPOSURE

	final = rgb * pow(2.0, Light * MINI);

} else if (LightMode == 2) {

	// RGB BRIGHT

	vec3 hsv = RGB_TO_HSV(rgb);
	hsv.z += Light * MINI;
	final = HSV_TO_RGB(hsv);

}

/*------------ INVERT ------------*/

if (Invert) final = RGB_SHIFT( vec3(1.0,1.0,1.0) - final, 0.5);


/*------------ LOW / HIGH ------------*/


float low = Low * (MINI/2.);
float high = 1.0 - (High * (MINI/2.));


/*------------ NOISE ------------*/


// vec2 uv = POS_FRAG / RENDERSIZE.xy;
// float ti = TIME;
// vec3 noiz = vec3(HASH12N(uv+(ti)),HASH12N(uv+(ti+1.)),HASH12N(uv+(ti+1.))) * Noise;


return vec4( LEVELS(final.rgb, Low, 1.0, High).rgb, INPUT.a );

