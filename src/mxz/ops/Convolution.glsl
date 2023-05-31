
/* GROKKED FROM learn/WebGLImageFiler */

vec2 pos = POS_NORM;
float amt = Amt;
float Amount = Amt;

if (TYPE == 0) { //int(TYPE) == 0) {


	/*
		LumaSharpen 1.4.1

		original hlsl by Christian Cann Schuldt Jensen ~ CeeJay.dk
		port to glsl by Anon

		It blurs the original pixel with the surrounding pixels and then subtracts this blur to sharpen the image.
		It does this in luma to avoid color artifacts and allows limiting the maximum sharpning to avoid or lessen halo artifacts.

		This is similar to using Unsharp Mask in Photoshop.
	*/


	float sharp_strength = Amount;
	float sharp_clamp = sharp_strength;
	float offset_bias = Radius * 10.0;
	// #define COEFLUMA vec3(0.2126, 0.7152, 0.0722)      // BT.709 & sRBG luma coefficient (Monitors and HD Television)
	#define COEFLUMA vec3(0.299, 0.587, 0.114)       // BT.601 luma coefficient (SD Television)
	// #define COEFLUMA vec3(1.0/3.0, 1.0/3.0, 1.0/3.0) // Equal weight coefficient

	vec4 colorInput = IMG_NORM_PIXEL(TEXTURE, POS_NORM);
	
	vec3 ori = colorInput.rgb;
	vec3 sharp_strength_luma = (COEFLUMA * sharp_strength);
	//   [ .25, .50, .25]     [ 1 , 2 , 1 ]
	//   [ .50,   1, .50]  =  [ 2 , 4 , 2 ]
	//   [ .25, .50, .25]     [ 1 , 2 , 1 ]

	float px = 1.0/RENDERSIZE.x;
	float py = 1.0/RENDERSIZE.y;
	vec2 xy = gl_FragCoord.xy;

	// ---------------------- ORIGINAL 

	vec3 blur_ori = IMG_NORM_PIXEL(TEXTURE, POS_NORM.xy + vec2(px,-py) * 0.5 * offset_bias).rgb; // South East
	blur_ori += IMG_NORM_PIXEL(TEXTURE, POS_NORM.xy + vec2(-px,-py) * 0.5 * offset_bias).rgb;  // South West
	blur_ori += IMG_NORM_PIXEL(TEXTURE, POS_NORM.xy + vec2(px,py) * 0.5 * offset_bias).rgb; // North East
	blur_ori += IMG_NORM_PIXEL(TEXTURE, POS_NORM.xy + vec2(-px,py) * 0.5 * offset_bias).rgb; // North West
	blur_ori *= 0.25;
	vec3 sharp = ori - blur_ori;
	vec4 sharp_strength_luma_clamp = vec4(sharp_strength_luma * (0.5 / sharp_clamp),0.5);
	float sharp_luma = clamp((dot(vec4(sharp,1.0), sharp_strength_luma_clamp)), 0.0,1.0 );
	sharp_luma = (sharp_clamp * 2.0) * sharp_luma - sharp_clamp;
	colorInput.rgb = colorInput.rgb + sharp_luma;

	return clamp(colorInput, 0.0,1.0);

	// --------------------- RGB ATTEMPT (WORKS-ISH)

	for (int i = 0; i < 4; i++) {

		float blur_ori = IMG_NORM_PIXEL(TEXTURE, POS_NORM.xy + vec2(px,-py) * 0.5 * offset_bias)[i]; // South East
		blur_ori += IMG_NORM_PIXEL(TEXTURE, POS_NORM.xy + vec2(-px,-py) * 0.5 * offset_bias)[i];  // South West
		blur_ori += IMG_NORM_PIXEL(TEXTURE, POS_NORM.xy + vec2(px,py) * 0.5 * offset_bias)[i]; // North East
		blur_ori += IMG_NORM_PIXEL(TEXTURE, POS_NORM.xy + vec2(-px,py) * 0.5 * offset_bias)[i]; // North West

		blur_ori *= 0.25;  // ( /= 4) Divide by the number of texture fetches

		// -- Calculate the sharpening --
		float sharp = ori[i] - blur_ori;  // Subtracting the blurred image from the original image

		// -- Adjust strength of the sharpening and clamp it--
		float sharp_strength_luma_clamp = sharp_strength_luma[i] * (0.5 / sharp_clamp); //Roll part of the clamp into the dot

		float sharp_luma = clamp((sharp + sharp_strength_luma_clamp), 0.0,1.0 ); //Calculate the luma, adjust the strength, scale up and clamp
		sharp_luma = (sharp_clamp * 2.0) * sharp_luma - sharp_clamp; //scale down


		// -- Combining the values to get the final sharpened pixel	--

		colorInput[i] = colorInput[i] + sharp_luma;    // Add the sharpening to the input color.
	}

	return clamp(colorInput, 0.0,1.0);
	
} else if (TYPE == 1) {

	// DITHER

	vec3 res = vec3(RENDERSIZE, 1.);
	float time = TIME;

	const vec2 blurdir = vec2( 1.0, 0.0 );

	float blurdist_px = float(RENDERSIZE.x*Radius);
	vec2 POS = POS_FRAG;
	vec2 suv = POS / res.xy; 
	vec2 uv = POS / res.xy;

	float blur = 10. * amt * blurdist_px;
	blur *= .1; //empiric constant...

	float da = 6.283;
	float a = 1.0;

    if (Jitter) { 
    	a = da * HASH12N(uv+(time)); 
	} else { 
		a = da * HASH12N(uv); 
	}

	vec3 sumcol = vec3(0.0);

	for (int i=0;i<10;++i) {
		vec2 ofs = vec2( cos(a), sin(a) ) / res.xy * blur*float(i+1)*.31;
		vec2 p = uv+(ofs/10.);
		vec3 pix = IMG_NORM_PIXEL(TEXTURE, p).rgb;
		sumcol = sumcol+SRGB2LIN(pix);
		a += da;
	}

	sumcol = sumcol / 10.;
	sumcol = max( sumcol, 0.0 );

	return vec4( LIN2SRGB( sumcol ), INPUT.a);
} else {

	// vec2 pixelate = PIXELATE(pos, vec2(amt,amt));
	return IMG_NORM_PIXEL(TEXTURE, pos );

}