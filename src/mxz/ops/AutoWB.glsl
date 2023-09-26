

vec3 hsl = RGB_TO_HSL( INPUT.rgb );


// if (Luma < High * 255.0 && AutoWB > 0.0) {
// 	hsl.z += Amp * 0.1;
// } else if (Luma > Low * 255.0  && AutoWB < 0.0) { 
// 	hsl.z += Amp * -0.1;
// }

hsl.z += Exp * Amp * 0.001;
return vec4( HSL_TO_RGB(hsl).rgb, INPUT.a );
