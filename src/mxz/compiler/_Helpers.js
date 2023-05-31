
export default e => `



float CLAMP( float v, float min, float max ) {

    if (v > max) v = max;
    if (v < min) v = min;
    return v;
}


// wenn yu perfekt lieber Gott boese (Nam june Paik 1963)

#define COLOR_MAP(f, a, b) vec3(f(a.r, b.r), f(a.g, b.g), f(a.b, b.b))
#define PI 3.14159265358979323846264338327
#define HPI 1.5707963267948966

/*  EXPERIMENTAL CONVOLUTION

varying vec2 VTC_11;
varying vec2 VTC_00;
varying vec2 VTC_02;
varying vec2 VTC_20;
varying vec2 VTC_22;
*/


vec3 SRGB2LIN(vec3 c) { return c*c; }
vec3 LIN2SRGB(vec3 c) { return sqrt(c); }

//note: uniform pdf rand [0;1]

float HASH12N(vec2 p)
{
    p  = fract(p * vec2(5.3987, 5.4421));
    p += dot(p.yx, p.xy + vec2(21.5351, 14.3137));
    return fract(p.x * p.y * 95.4307);
}

vec2 PIXELATE( vec2 coord, vec2 size ) {
    return floor( coord / size ) * size;
}

float ADD(float a, float b) { return min(a + b, 1.0); }
float COLORBURN(float a, float b) { return (b == 0.0) ? b : max((1.0 - ((1.0 - a) / b)), 0.0); }
float DARKEN(float a, float b) { return min(b, a); }
float LIGHTEN(float a, float b) { return max(b, a); }
float PIN(float a, float b) { return (b < 0.5) ? DARKEN(a, (2.0 * b)) : LIGHTEN(a , (2.0 * (b - 0.5))); }
float COLORDODGE(float a, float b) { return (b == 1.0) ? b : min(a / (1.0 - b), 1.0); }
float REFLECT(float a, float b) { return (b == 1.0) ? b : min(a * a / (1.0 - b), 1.0); }
float VIVID(float a, float b) { return (b < 0.5) ? COLORBURN(a, (2.0 * b)) : COLORDODGE(a, (2.0 * (b - 0.5))); }
float HARD_MIX(float a, float b) { return (VIVID(a, b) < 0.5) ? 0.0 : 1.0; }
float OVERLAY(float a, float b) { return a < 0.5 ? (2.0 * a * b) : (1.0 - 2.0 * (1.0 - a) * (1.0 - b)); }
float DODGE(float a, float b) { return min(a + b, 1.0); }
float SCREEN(float a, float b) { return 1.0 - ((1.0 - a) * (1.0 - b)); }
float SOFT(float a, float b) { return (b < 0.5) ? (2.0 * a * b + a * a * (1.0 - 2.0 * b)) : (sqrt(a) * (2.0 * b - 1.0) + 2.0 * a * (1.0 - b)); }
float SUBTRACT(float a, float b) { return max(a + b - 1.0, 0.0); }
float LINEAR(float a, float b) { return b < 0.5 ? SUBTRACT(a, (2.0 * b)) : DODGE(a, (2.0 * (b - 0.5))); }

float SUM_RGBA( vec4 v ) {
    return v.r + v.g + v.b;
}

float SUM_RGB( vec3 v ) {
    return v.r + v.g + v.b;
}

float PHI = 1.61803398874989484820459;  // Φ = Golden Ratio  


float HASH(float n) { return fract(sin(n) * 1e4); }
float HASH(vec2 p) { return fract(1e4 * sin(17.0 * p.x + p.y * 0.1) * (0.1 + abs(sin(p.y * 13.0 + p.x)))); }


vec3 GAMMA_CORRECT(vec3 color, float gamma){
    return pow(color, vec3(1.0/gamma));
}

vec3 LEVEL_RANGE(vec3 color, float minInput, float maxInput){
    return min(max(color - vec3(minInput), vec3(0.0)) / (vec3(maxInput) - vec3(minInput)), vec3(1.0));
}

vec3 LEVELS(vec3 color, float minInput, float gamma, float maxInput){
    return GAMMA_CORRECT(LEVEL_RANGE(color, minInput, maxInput), gamma);
}

float RANDOM(vec2 co)
{
    return fract(sin(dot(co.xy, vec2(12.9898, 78.233))) * 43758.5453);
}

vec2 NORM_TO_VEC2( vec2 xy ) {

    xy.x = ( ( xy.x * 2.0 ) - 1.0 );
    xy.y = ( ( xy.y * 2.0 ) - 1.0 );
    return xy;
}
vec2 NORM_TO_VEC2( float x, float y ) {


    x = ( ( x * 2.0 ) - 1.0 );
    y = ( ( y * 2.0 ) - 1.0 );
    return vec2(x,y);
}

float BRIGHT( vec4 xyz ) {

    return (xyz.r + xyz.g + xyz.b)/3.0;
}

float MAP(float oldValue, float oldMin, float oldMax, float newMin, float newMax) {
    float oldRange = oldMax - oldMin;
    float newRange = newMax - newMin;

    float newVal = ((oldValue - oldMin) * newRange / oldRange) + newMin;
    return newVal;
}

float MAP(float oldValue, float oldMin, float oldMax, float newMin, float newMax, bool clamp) {
    float oldRange = oldMax - oldMin;
    float newRange = newMax - newMin;

    float newVal = ((oldValue - oldMin) * newRange / oldRange) + newMin;
    if (clamp) return CLAMP(newVal, min(newMin,newMax), max(newMin,newMax));
    return newVal;
}


float FMOD( float a, float b ) {
    return a - b * floor(a/b);
}


int WITHIN(float value, float low, float high) {
  bool a = value > low && value < high;
  bool b = value + 1.0 > low && value + 1.0 < high;
  bool c = value - 1.0 > low && value - 1.0 < high;
  if (a) return 1;
  if (b) return 2;
  if (c) return 3;
  return 0;
}


vec2 INTERSECTION(vec2 a,vec2 b,vec2 c,vec2 d) {
    float ua, ub, denom = (d.y - c.y)*(b.x - a.x) - (d.x - c.x)*(b.y - a.y);
    if (denom == 0.0) return vec2(-1.0,-1.0);
    ua = ((d.x - c.x)*(a.y - c.y) - (d.y - c.y)*(a.x - c.x))/denom;
    ub = ((b.x - a.x)*(a.y - c.y) - (b.y - a.y)*(a.x - c.x))/denom;
    return vec2(
        a.x + ua * (b.x - a.x),
        a.y + ua * (b.y - a.y)
    );
}
vec2 INTERLACE_VEC2(vec2 pointA, vec2 pointB, vec2 pointC, vec2 pointD) {

  float z1 = (pointA.x - pointB.x);
  float z2 = (pointC.x - pointD.x);
  float z3 = (pointA.y - pointB.y);
  float z4 = (pointC.y - pointD.y);
  float dist = z1 * z4 - z3 * z2;
  vec2 blank = vec2(-1.0,-1.0);
  if (dist == 0.0) {
    return blank;
  }
  float tempA = (pointA.x * pointB.y - pointA.y * pointB.x);
  float tempB = (pointC.x * pointD.y - pointC.y * pointD.x);
  float xCoor = (tempA * z2 - z1 * tempB) / dist;
  float yCoor = (tempA * z4 - z3 * tempB) / dist;

  return vec2(xCoor, yCoor);
}

vec2 ROTATE_VEC2(vec2 origin, vec2 point, float angle) {
  float rad = (PI / 180.0) * angle;
  float _cos = cos(rad);
  float _sin = sin(rad);
  float run = point.x - origin.x;
  float rise = point.y - origin.y;
  float cx = (_cos * run) + (_sin * rise) + origin.x;
  float cy = (_cos * rise) - (_sin * run) + origin.y;
  return vec2(
    cx,
    cy
  );
}


float ANGLE( vec2 a, vec2 b ) {
    return ((atan(b.y - a.y, b.x - a.x)  * 360.0 / PI) + 360.0) / 2.0;
}

vec2 VEC2_FROM_ANGLE(vec2 xy, float angle, float dist) {
    float x = cos(angle * PI / 180.0) * dist + xy.x;
    float y = sin(angle * PI / 180.0) * dist + xy.y;
    return vec2(x,y);
}


vec2 VEC2_POLAR( vec2 a, vec2 b, vec2 c) {

    float slope = (a.y - b.y) / (a.x - b.x);
    float m = -1.0 / slope;
    float x = (m * c.x - c.y - slope * a.x + a.y) / (m - slope);
    float y = m * x - m * c.x + c.y;
    return vec2(x,y);
}

float VEC2_POLAR_DIST(vec2 a, vec2 b, vec2 c) {

    return ((c.x - a.x)*(b.x - a.x) + (c.y - a.y)*(b.y - a.y)) /
    (pow(b.x - a.x, 2.0) + pow(b.y - a.y, 2.0));
}



vec3 CMYK_TO_RGB (vec4 cmyk) {
    float c = cmyk.x;
    float m = cmyk.y;
    float y = cmyk.z;
    float k = cmyk.w;

    float invK = 1.0 - k;
    float r = 1.0 - min(1.0, c * invK + k);
    float g = 1.0 - min(1.0, m * invK + k);
    float b = 1.0 - min(1.0, y * invK + k);
    return clamp(vec3(r, g, b), 0.0, 1.0);
}

vec4 RGB_TO_CMYK (vec3 rgb) {
    float r = rgb.r;
    float g = rgb.g;
    float b = rgb.b;
    float k = min(1.0 - r, min(1.0 - g, 1.0 - b));
    vec3 cmy = vec3(0.0);
    float invK = 1.0 - k;
    if (invK != 0.0) {
        cmy.x = (1.0 - r - k) / invK;
        cmy.y = (1.0 - g - k) / invK;
        cmy.z = (1.0 - b - k) / invK;
    }
    return clamp(vec4(cmy, k), 0.0, 1.0);
}

vec3 RGB_TO_HSL(vec3 color) {
    vec3 hsl; // init to 0 to avoid warnings ? (and reverse if + remove first part)

    float fmin = min(min(color.r, color.g), color.b); //Min. value of RGB
    float fmax = max(max(color.r, color.g), color.b); //Max. value of RGB
    float delta = fmax - fmin; //Delta RGB value

    hsl.z = (fmax + fmin) / 2.0; // Luminance

    if (delta == 0.0) //This is a gray, no chroma...
    {
        hsl.x = 0.0; // Hue
        hsl.y = 0.0; // Saturation
    } else //Chromatic data...
    {
        if (hsl.z < 0.5)
            hsl.y = delta / (fmax + fmin); // Saturation
        else
            hsl.y = delta / (2.0 - fmax - fmin); // Saturation

        float deltaR = (((fmax - color.r) / 6.0) + (delta / 2.0)) / delta;
        float deltaG = (((fmax - color.g) / 6.0) + (delta / 2.0)) / delta;
        float deltaB = (((fmax - color.b) / 6.0) + (delta / 2.0)) / delta;

        if (color.r == fmax)
            hsl.x = deltaB - deltaG; // Hue
        else if (color.g == fmax)
            hsl.x = (1.0 / 3.0) + deltaR - deltaB; // Hue
        else if (color.b == fmax)
            hsl.x = (2.0 / 3.0) + deltaG - deltaR; // Hue

        if (hsl.x < 0.0)
            hsl.x += 1.0; // Hue
        else if (hsl.x > 1.0)
            hsl.x -= 1.0; // Hue
    }

    return hsl;
}

float HUE_TO_RGB(float f1, float f2, float hue) {
    if (hue < 0.0)
        hue += 1.0;
    else if (hue > 1.0)
        hue -= 1.0;
    float res;
    if ((6.0 * hue) < 1.0)
        res = f1 + (f2 - f1) * 6.0 * hue;
    else if ((2.0 * hue) < 1.0)
        res = f2;
    else if ((3.0 * hue) < 2.0)
        res = f1 + (f2 - f1) * ((2.0 / 3.0) - hue) * 6.0;
    else
        res = f1;
    return res;
}

vec3 HSL_TO_RGB(vec3 hsl) {
    vec3 rgb;
    
    if (hsl.y == 0.0) {
        rgb = vec3(hsl.z); // Luminance
    } else {
        float f2;
        
        if (hsl.z < 0.5)
            f2 = hsl.z * (1.0 + hsl.y);
        else
            f2 = hsl.z + hsl.y - hsl.y * hsl.z;
            
        float f1 = 2.0 * hsl.z - f2;
        
        rgb.r = HUE_TO_RGB(f1, f2, hsl.x + (1.0/3.0));
        rgb.g = HUE_TO_RGB(f1, f2, hsl.x);
        rgb.b = HUE_TO_RGB(f1, f2, hsl.x - (1.0/3.0));
    }   
    return rgb;
}

vec3 HSL_TO_RGB(float h, float s, float l) {
    return HSL_TO_RGB(vec3(h, s, l));
}


vec3 RGB_SHIFT(vec3 color, float hue) {
    hue *= 6.28318530718;
    const vec3 k = vec3(0.57735, 0.57735, 0.57735);
    float cosAngle = cos(hue);
    return vec3(color * cosAngle + cross(k, color) * sin(hue) + k * dot(k, color) * (1.0 - cosAngle));
}

vec3 HSV_TO_RGB(vec3 c)
{
vec4 K = vec4(1.0, 2.0 / 3.0, 1.0 / 3.0, 3.0);
vec3 p = abs(fract(c.xxx + K.xyz) * 6.0 - K.www);
return c.z * mix(K.xxx, clamp(p - K.xxx, 0.0, 1.0), c.y);
}

vec3 RGB_TO_HSV(vec3 rgb) {
    float Cmax = max(rgb.r, max(rgb.g, rgb.b));
    float Cmin = min(rgb.r, min(rgb.g, rgb.b));
    float delta = Cmax - Cmin;

    vec3 hsv = vec3(0., 0., Cmax);

    if (Cmax > Cmin) {
        hsv.y = delta / Cmax;

        if (rgb.r == Cmax)
            hsv.x = (rgb.g - rgb.b) / delta;
        else {
            if (rgb.g == Cmax)
                hsv.x = 2. + (rgb.b - rgb.r) / delta;
            else
                hsv.x = 4. + (rgb.r - rgb.g) / delta;
        }
        hsv.x = fract(hsv.x / 6.);
    }
    return hsv;
}


vec3 GRID( float width, vec2 coord ) {
    float size = width * RENDERSIZE.x;
    vec3 a = HSL_TO_RGB( vec3(0.0,0.0,0.9) );
    vec3 b = HSL_TO_RGB( vec3(0.0,0.0,0.7) );

    if (size == 0.0)    {
        return a;
    } else if ((mod((coord.x / size),2.0) < 1.0)&&(mod((coord.y / size),2.0) > 1.0))  {
        return a;
    } else if ((mod((coord.x / size),2.0) > 1.0)&&(mod((coord.y / size),2.0) < 1.0))  {
        return a;
    }
    
    return b;

}

float SAW( float t ) {
    return 1.0-abs(2.*fract(t/PI)-1.);
}

float WAVE( float t, float shape, float amp, float exp ) {

    float sine = sin(t);
    float saw = SAW(t);
    return pow((mix(sine,saw,shape)*(1.+amp))-(amp/2.),exp);
}



`