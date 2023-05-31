
vec3 src = INPUT.rgb;
vec2 frag = POS_FRAG;
vec2 norm = POS_NORM;
vec2 center = CENTER();
float ratio = RENDERSIZE.y / RENDERSIZE.x;

float mask = SUM_RGB( Mode != 1 ? vec3(.5) : Src.rgb ) / 3.0;
mask = pow(mask, SmoothExp);
if (Invert) mask = 1.0 - mask;

/* convert to normalised scanline */

float width = RENDERSIZE.x;
float height = RENDERSIZE.y;
float total = width*height;

/* define sizes */

float pixel = (frag.y * RENDERSIZE.x) + frag.x;
float scanline = MAP(pixel,0.,total, 0.,1.);

/* set frequencies */

float count = 30.; // maximum number of lines
float freq = float(int((Freq * count) + 1.));
// freq = (Freq * count) + 1.; // 3TRINS SYNC (TODO)

/* SYNC */

freq += Sync * 0.1;
freq += mask * ExtSync * 0.1;

/* MISC */

// float sync = mask * Sync;
// freq += sin( pixel * sync * PI ) * 0.001;
float space = Lock == 0 ? width/freq : total/freq;

/* do scrolls here */

frag.y -= RENDERSIZE.y / 2.0;

// pixel += TIME * Speed * 100.0;

/* OFFSET */

// pixel += Offset * ( Lock == 0 ? width : width * height );
pixel += Offset * TIME * ( Lock == 0 ? width : width * height );
pixel += mask * ExtOffset * ( Lock == 0 ? width : width * height );

float wave = clamp( MAP( FMOD(pixel,space),0.0, space * Ramp, 0.0, PI), 0.0, PI);
float r = WAVE( wave, 1., Amp, Exp );
if (Mask) r *= mask;


// returning transparency colour

// return vec4( HSL_TO_RGB( Color[0], Color[1], Color[2] ), r );

// returning single HSL colour

return vec4( HSL_TO_RGB( Color[0], Color[1], Color[2] * r ), 1.0);
// r = (r+1.0)/2.0;
// return vec3(r, r, r);