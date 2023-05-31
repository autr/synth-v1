
/* GROKKED FROM learn/WebGLImageFiler */

vec2 pos = POS_NORM;
float amt = Amt;

if (TYPE == 0) { //int(TYPE) == 0) {

	// BLUR


	vec4 pix = vec4(0.0);
	amt *= -0.2;
	float adj = 0.5;
	
	pix += IMG_NORM_PIXEL(TEXTURE, pos + vec2(-7.0*amt, -7.0*amt))*0.0044299121055113265 * adj;
	pix += IMG_NORM_PIXEL(TEXTURE, pos + vec2(-6.0*amt, -6.0*amt))*0.00895781211794 * adj;
	pix += IMG_NORM_PIXEL(TEXTURE, pos + vec2(-5.0*amt, -5.0*amt))*0.0215963866053 * adj;
	pix += IMG_NORM_PIXEL(TEXTURE, pos + vec2(-4.0*amt, -4.0*amt))*0.0443683338718 * adj;
	pix += IMG_NORM_PIXEL(TEXTURE, pos + vec2(-3.0*amt, -3.0*amt))*0.0776744219933 * adj;
	pix += IMG_NORM_PIXEL(TEXTURE, pos + vec2(-2.0*amt, -2.0*amt))*0.115876621105 * adj;
	pix += IMG_NORM_PIXEL(TEXTURE, pos + vec2(-1.0*amt, -1.0*amt))*0.147308056121 * adj;
	
	pix += IMG_NORM_PIXEL(TEXTURE, pos + vec2( 7.0*amt,  7.0*amt))*0.0044299121055113265 * adj;
	pix += IMG_NORM_PIXEL(TEXTURE, pos + vec2( 6.0*amt,  6.0*amt))*0.00895781211794 * adj;
	pix += IMG_NORM_PIXEL(TEXTURE, pos + vec2( 5.0*amt,  5.0*amt))*0.0215963866053 * adj;
	pix += IMG_NORM_PIXEL(TEXTURE, pos + vec2( 4.0*amt,  4.0*amt))*0.0443683338718 * adj;
	pix += IMG_NORM_PIXEL(TEXTURE, pos + vec2( 3.0*amt,  3.0*amt))*0.0776744219933 * adj;
	pix += IMG_NORM_PIXEL(TEXTURE, pos + vec2( 2.0*amt,  2.0*amt))*0.115876621105 * adj;
	pix += IMG_NORM_PIXEL(TEXTURE, pos + vec2( 1.0*amt,  1.0*amt))*0.147308056121 * adj;
	
	pix += IMG_NORM_PIXEL(TEXTURE, pos + vec2( 7.0*amt,  -7.0*amt))*0.0044299121055113265 * adj;
	pix += IMG_NORM_PIXEL(TEXTURE, pos + vec2( 6.0*amt,  -6.0*amt))*0.00895781211794 * adj;
	pix += IMG_NORM_PIXEL(TEXTURE, pos + vec2( 5.0*amt,  -5.0*amt))*0.0215963866053 * adj;
	pix += IMG_NORM_PIXEL(TEXTURE, pos + vec2( 4.0*amt,  -4.0*amt))*0.0443683338718 * adj;
	pix += IMG_NORM_PIXEL(TEXTURE, pos + vec2( 3.0*amt,  -3.0*amt))*0.0776744219933 * adj;
	pix += IMG_NORM_PIXEL(TEXTURE, pos + vec2( 2.0*amt,  -2.0*amt))*0.115876621105 * adj;
	pix += IMG_NORM_PIXEL(TEXTURE, pos + vec2( 1.0*amt,  -1.0*amt))*0.147308056121 * adj;

	pix += IMG_NORM_PIXEL(TEXTURE, pos + vec2( -7.0*amt,  7.0*amt))*0.0044299121055113265 * adj;
	pix += IMG_NORM_PIXEL(TEXTURE, pos + vec2( -6.0*amt,  6.0*amt))*0.00895781211794 * adj;
	pix += IMG_NORM_PIXEL(TEXTURE, pos + vec2( -5.0*amt,  5.0*amt))*0.0215963866053 * adj;
	pix += IMG_NORM_PIXEL(TEXTURE, pos + vec2( -4.0*amt,  4.0*amt))*0.0443683338718 * adj;
	pix += IMG_NORM_PIXEL(TEXTURE, pos + vec2( -3.0*amt,  3.0*amt))*0.0776744219933 * adj;
	pix += IMG_NORM_PIXEL(TEXTURE, pos + vec2( -2.0*amt,  2.0*amt))*0.115876621105 * adj;
	pix += IMG_NORM_PIXEL(TEXTURE, pos + vec2( -1.0*amt,  1.0*amt))*0.147308056121 * adj;

	// pix += IMG_NORM_PIXEL(TEXTURE, pos ).rgb * 0.159576912161 * adj;

	return pix * 1.2;

} else if (TYPE == 1) {

	// SIMPLE BLUR

	vec2 off1 = vec2(1.3846153846) * amt;
    vec2 off2 = vec2(3.2307692308) * amt;
	vec4 color = IMG_NORM_PIXEL(TEXTURE, pos) * 0.2270270270;

	color += IMG_NORM_PIXEL(TEXTURE, pos + off1) * 0.3162162162;
	color += IMG_NORM_PIXEL(TEXTURE, pos - off1) * 0.3162162162;
	color += IMG_NORM_PIXEL(TEXTURE, pos + off2) * 0.0702702703;
	color += IMG_NORM_PIXEL(TEXTURE, pos - off2) * 0.0702702703;
	
	return color;

} else if (TYPE == 2) {

	// SHARPEN

	amt *= 1.0;

	float CV_0 = 0.0;
	float CV_1 = -1.0*amt;
	float CV_2 = 0.0;
	float CV_3 = -1.0*amt;
	float CV_4 = 1.0 + 4.0*amt;
	float CV_5 = -1.0*amt;
	float CV_6 = 0.0;
	float CV_7 = -1.0*amt;
	float CV_8 = 0.0;

	vec4 c11 = IMG_NORM_PIXEL(TEXTURE, pos - amt); // top left
	vec4 c12 = IMG_NORM_PIXEL(TEXTURE, vec2(pos.x, pos.y - amt)); // top center
	vec4 c13 = IMG_NORM_PIXEL(TEXTURE, vec2(pos.x + amt, pos.y - amt)); // top right

	vec4 c21 = IMG_NORM_PIXEL(TEXTURE, vec2(pos.x - amt, pos.y) ); // mid left
	vec4 c22 = IMG_NORM_PIXEL(TEXTURE, pos); // mid center
	vec4 c23 = IMG_NORM_PIXEL(TEXTURE, vec2(pos.x + amt, pos.y) ); // mid right

	vec4 c31 = IMG_NORM_PIXEL(TEXTURE, vec2(pos.x - amt, pos.y + amt) ); // bottom left
	vec4 c32 = IMG_NORM_PIXEL(TEXTURE, vec2(pos.x, pos.y + amt) ); // bottom center
	vec4 c33 = IMG_NORM_PIXEL(TEXTURE, pos + amt ); // bottom right

	return c11 * CV_0 + c12 * CV_1 + c22 * CV_2 + c21 * CV_3 + c22 * CV_4 + c23 * CV_5 + c31 * CV_6 + c32 * CV_7 + c33 * CV_8;

} else if (TYPE == 3 ) {

	// UNSHARP

	vec2 pos = POS_NORM;
	vec2 d = 1.0/RENDERSIZE;
	
	vec2 LC = clamp(vec2(pos.xy + vec2(-d.x , 0)),0.0,1.0);
	vec2 RC = clamp(vec2(pos.xy + vec2(d.x , 0)),0.0,1.0);
	vec2 TC = clamp(vec2(pos.xy + vec2(0,d.y)),0.0,1.0);
	vec2 BC = clamp(vec2(pos.xy + vec2(0,-d.y)),0.0,1.0);

	vec2 LC_A = clamp(vec2(pos.xy + vec2(-d.x , d.x)),0.0,1.0);
	vec2 RC_A = clamp(vec2(pos.xy + vec2(d.x , d.x)),0.0,1.0);
	vec2 LC_B = clamp(vec2(pos.xy + vec2(-d.x , -d.x)),0.0,1.0);
	vec2 RC_B = clamp(vec2(pos.xy + vec2(d.x , -d.x)),0.0,1.0);

	vec4 C = IMG_NORM_PIXEL(TEXTURE, pos);
	vec4 CL = IMG_NORM_PIXEL(TEXTURE, LC);
	vec4 CR = IMG_NORM_PIXEL(TEXTURE, RC);
	vec4 CA = IMG_NORM_PIXEL(TEXTURE, TC);
	vec4 CB = IMG_NORM_PIXEL(TEXTURE, BC);

	vec4 CLA = IMG_NORM_PIXEL(TEXTURE, LC_A);
	vec4 CRA = IMG_NORM_PIXEL(TEXTURE, RC_A);
	vec4 CLB = IMG_NORM_PIXEL(TEXTURE, LC_B);
	vec4 CRB = IMG_NORM_PIXEL(TEXTURE, RC_B);

	return C + (amt * 10.) * (8.0*C - CL - CR - CA - CB - CLA - CRA - CLB - CRB);

} else if (TYPE == 4 ) {


	vec2 pos = POS_NORM;
	vec2 step = (Radius * 10.0) / pos.xy;

	vec3 texA = IMG_NORM_PIXEL( TEXTURE, pos.xy + vec2(-step.x, -step.y) * 1.5 ).rgb;
	vec3 texB = IMG_NORM_PIXEL( TEXTURE, pos.xy + vec2( step.x, -step.y) * 1.5 ).rgb;
	vec3 texC = IMG_NORM_PIXEL( TEXTURE, pos.xy + vec2(-step.x,  step.y) * 1.5 ).rgb;
	vec3 texD = IMG_NORM_PIXEL( TEXTURE, pos.xy + vec2( step.x,  step.y) * 1.5 ).rgb;

	vec3 around = 0.25 * (texA + texB + texC + texD);
	vec3 center  = IMG_NORM_PIXEL( TEXTURE, pos.xy ).rgb;

	float sharpness = Amt * 20.0;

	vec3 col = center + (center - around) * sharpness;

	return vec4( col, 1.0 );
	
} else if (TYPE == 5) {

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