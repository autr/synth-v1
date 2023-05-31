
// TODO

var FRAG_BLUR = ` 
    precision mediump float;

    uniform sampler2D image;

    varying vec2 VTC_11;
    varying vec2 VTC_00;
    varying vec2 VTC_02;
    varying vec2 VTC_20;
    varying vec2 VTC_22;

    void main() {
	   vec4 blur;
	
	   blur = texture2D(image, VTC_11);
	   blur += texture2D(image, VTC_00);
	   blur += texture2D(image, VTC_02);
	   blur += texture2D(image, VTC_20);
	   blur += texture2D(image, VTC_22);

	   gl_FragColor = 0.2 * blur;} `;

var FRAG_SHARPEN = ` 
    precision mediump float;

    uniform sampler2D image;

    varying vec2 VTC_11;
    varying vec2 VTC_00;
    varying vec2 VTC_02;
    varying vec2 VTC_20;
    varying vec2 VTC_22;

    void main() {   
        vec4 s11 = texture2D(image, VTC_11);
        vec4 s00 = texture2D(image, VTC_00);
        vec4 s02 = texture2D(image, VTC_02);
        vec4 s20 = texture2D(image, VTC_20);
        vec4 s22 = texture2D(image, VTC_22);
        
        vec4 sharp = 5.0 * s11 - (s00 + s02 + s20 + s22);

        gl_FragColor = sharp;} `;

var FRAG_DILATE = ` 
    precision mediump float;

    uniform sampler2D image;

    varying vec2 VTC_00;
    varying vec2 VTC_01;
    varying vec2 VTC_02;
    varying vec2 VTC_10;
    varying vec2 VTC_12;
    varying vec2 VTC_20;
    varying vec2 VTC_21;
    varying vec2 VTC_22;

    void main() {
	   vec4 dilate = texture2D(image, 0.5 * (VTC_10 + VTC_12));
	
	   dilate = max(dilate, texture2D(image, VTC_00));
	   dilate = max(dilate, texture2D(image, VTC_01));
	   dilate = max(dilate, texture2D(image, VTC_02));
	   dilate = max(dilate, texture2D(image, VTC_10));
	   dilate = max(dilate, texture2D(image, VTC_12));
	   dilate = max(dilate, texture2D(image, VTC_20));
	   dilate = max(dilate, texture2D(image, VTC_21));
	   dilate = max(dilate, texture2D(image, VTC_22));

	   gl_FragColor = dilate;} `;

var FRAG_EMBOSS = `
    precision mediump float;

    uniform sampler2D image;
    uniform vec4 offset;

    varying vec2 VTC_00;
    varying vec2 VTC_01;
    varying vec2 VTC_02;
    varying vec2 VTC_10;
    varying vec2 VTC_12;
    varying vec2 VTC_20;
    varying vec2 VTC_21;
    varying vec2 VTC_22;

    void main() {
	   vec4 emboss = texture2D(image, VTC_00);
	
	   emboss += texture2D(image, VTC_01);
	   emboss += texture2D(image, VTC_10);
	   emboss -= texture2D(image, VTC_12);
	   emboss -= texture2D(image, VTC_21);
	   emboss -= texture2D(image, VTC_22);

	   gl_FragColor = emboss + offset;} `;

var FRAG_ERODE = `
    precision mediump float; 

    uniform sampler2D image;

    varying vec2 VTC_00;
    varying vec2 VTC_01;
    varying vec2 VTC_02;
    varying vec2 VTC_10;
    varying vec2 VTC_12;
    varying vec2 VTC_20;
    varying vec2 VTC_21;
    varying vec2 VTC_22;

    void main() {
	   vec4 erode = texture2D(image, 0.5 * (VTC_10 + VTC_12));
	
	   erode = min(erode, texture2D(image, VTC_00));
	   erode = min(erode, texture2D(image, VTC_01));
	   erode = min(erode, texture2D(image, VTC_02));
	   erode = min(erode, texture2D(image, VTC_10));
	   erode = min(erode, texture2D(image, VTC_12));
	   erode = min(erode, texture2D(image, VTC_20));
	   erode = min(erode, texture2D(image, VTC_21));
	   erode = min(erode, texture2D(image, VTC_22));

	   gl_FragColor = erode;} `;

var FRAG_LAPACE = ` 
    precision mediump float;

    uniform sampler2D image;
    uniform vec4 offset;

    varying vec2 VTC_01;
    varying vec2 VTC_10;
    varying vec2 VTC_11;
    varying vec2 VTC_12;
    varying vec2 VTC_21;

    void main() {
	   vec4 f01 = texture2D(image, VTC_01);
	   vec4 f10 = texture2D(image, VTC_10);
	   vec4 f11 = texture2D(image, VTC_11);
	   vec4 f12 = texture2D(image, VTC_12);
	   vec4 f21 = texture2D(image, VTC_21);

	   vec4 laplace = 4.0 * f11 - f01 - f10 - f12 - f21;

	   gl_FragColor = laplace + offset;} `;

var FRAG_MEDIAN = `
    precision mediump float;

    uniform sampler2D image;

    varying vec2 VTC_0;
    varying vec2 VTC_1;
    varying vec2 VTC_2;

    void main() {	
        vec4 sample0 = texture2D(image, VTC_0);
        vec4 sample1 = texture2D(image, VTC_1);
        vec4 sample2 = texture2D(image, VTC_2);

        vec4 max0 = max(sample0, sample1);
        vec4 max1 = max(sample1, sample2);
        vec4 max2 = max(sample2, sample0);

        vec4 median = min(min(max0, max1), max2);

        gl_FragColor = median;} `;

var FRAG_RADIAL = `
    precision mediump float;

    uniform sampler2D tex0;
    uniform vec2 resolution;
    uniform float width;
    
    varying vec2 v_VTC_;

    void main() {
        
        vec2 orn = 0.0*resolution;
        vec2 dst = v_VTC_-orn;
        vec2 off = dst*width*-0.05;
    
        vec4 pr1 = texture2D(tex0,dst+orn);
        vec4 pr2 = texture2D(tex0,dst+off+orn);
        vec4 pr3 = texture2D(tex0,(dst+off*2.)+orn);
        vec4 pr4 = texture2D(tex0,(dst+off*3.)+orn);
        vec4 pr5 = texture2D(tex0,(dst+off*4.)+orn);
        vec4 pr6 = texture2D(tex0,(dst+off*5.)+orn);
        vec4 pr7 = texture2D(tex0,(dst+off*6.)+orn);
        vec4 pr8 = texture2D(tex0,(dst+off*7.)+orn);
        vec4 pr9 = texture2D(tex0,(dst+off*8.)+orn);
        
        vec4 avg9 = (pr1+pr2+pr3+pr4+pr5+pr6+pr7+pr8+pr9)/9.0;
	       
        gl_FragColor = avg9;} `;
