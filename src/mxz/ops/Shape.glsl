bool SnapShape = true; // TODO
float Skew = 0.5; // TODO


// float Skew = 0.5; // SKEW (optional - expose it)

vec2 pos = POS_FRAG;
float ratio = RENDERSIZE.y / RENDERSIZE.x;

vec2 center = Center * RENDERSIZE;
vec2 trueCenter = vec2( 0.5, 0.5 ) * RENDERSIZE;

vec3 rgb = INPUT.rgb;
bool inv = false;

// Rotate entire thing

pos = ROTATE_VEC2( center, pos, Rotate * 360.0 );

// LOGICK: stretch to Fit

if (Fit) pos.x = (pos.x * ratio) + (( RENDERSIZE.x - RENDERSIZE.y) / 2.0);

// DEFS: segment angle

float shape = float(Shape);
float pointsTotal = shape + 1.0;
float segmentAng = 360.0 / pointsTotal;
float miniAngle = segmentAng * mod( pointsTotal, 1. );

// LOGICK:: Rotate to top

float flip = 90.;
int p = int( floor( pointsTotal ) );
if (p == 2) {
    flip +=  miniAngle / 2. ;
    flip += 180.;
} else if (p == 3) {
    flip +=  miniAngle / 2. ;
} else if (p == 4) {
    flip -= (segmentAng / 2.0);
    flip - (miniAngle / 2.);
    inv = !inv;
} else if (p == 5) {
    flip += 180.;
    flip +=  miniAngle / 2. ;
    inv = !inv;
} else if (p == 6) {
    flip -= (segmentAng / 2.0);
    flip +=  miniAngle / 2. ;
    inv = !inv;
} else if (p == 7) {
    flip +=  miniAngle / 2. ;
    inv = !inv;
} else if (p == 8) {
    flip -= (segmentAng / 2.0);
    flip +=  miniAngle / 2. ;
} else if (p == 9) {
    flip +=  miniAngle / 2. ;
} else if (p == 10) {
    flip -= (segmentAng / 2.0);
    flip +=  miniAngle / 2. ;
    inv = !inv;
} else if (p == 11) {
    inv = !inv;
}

pos = ROTATE_VEC2( center, pos, flip );

// DEFS: more distances and angles

float posAngle = ANGLE( center, pos );
float centerDist = distance(center, pos);
bool isMini = posAngle > 360.0 - miniAngle && posAngle < 360.;



// LOGICK: stripes Invert




float prevAngle = posAngle -mod( posAngle, segmentAng );
float midpointAngle;

if (!isMini) {

    // LOGICK: normal stripes

    midpointAngle = prevAngle + (segmentAng / 2.0);

} else {

    midpointAngle = -( (miniAngle) / 2.0 );

}

vec2 rotatedLoc = ROTATE_VEC2( center, pos, midpointAngle );
vec2 rotatePrev = ROTATE_VEC2( center, pos, midpointAngle);

float ogDist2Center = distance( rotatedLoc.x, center.x );
float dist2Center = ogDist2Center;
float DIST = RENDERSIZE.x * Size;
float HDIST = DIST / 2.0;

// DO EXTERNAL INVERT HERE (based on >>> DISTANCE <<<)
    
// LOGICK: segments Invert

float alter = (ShapeMode == 1) ? Alternate : 0.0;
bool ODD = mod( posAngle, segmentAng * (1.0 + alter) ) > segmentAng;
if (ODD) dist2Center += DIST / 2.0;

// TODO: this is full scroll without timer

// dist2Center -= DIST * Scroll;
// centerDist -= DIST * Scroll;

dist2Center -= TIME * Scroll * DIST;
centerDist -= TIME * Scroll * DIST;

// BEGIN CONFUZZLE

float skew = MAP( Skew, 0.0, 1.0, -1.0, 1.0);
float pointy = abs( center.y - rotatePrev.y  ) * skew * 10.;

float idxDist = mix( dist2Center, centerDist, Circular) + pointy;
float idxMod = mod( idxDist, DIST );
int idx = int( (idxDist - idxMod) / DIST );


// idxMod -= (DIST * Scroll);

vec3 red = vec3(0.0);

// LOGICK: smooth

float wipe = Recursion * DIST;
float smo = (DIST * Smooth);
bool isRecur = ShapeMode == 1;
if (!isRecur) idxMod = idxDist;
red.r = MAP(idxMod, wipe, wipe + smo, 1.0, 0.0);
red.r = clamp(red.r, 0.0, 1.0);

if (Invert) red.r = 1.0 - red.r;

vec3 black = vec3(0.0,0.0,0.0);
vec3 white = vec3(1.0,1.0,1.0);

// TODO

if ( Mode == 0 ) {

    return vec4( HSL_TO_RGB( Color[0], Color[1], Color[2] * red.r ), 1.0);

} else if (Mode == 1) {
    vec3 invt = RGB_SHIFT(vec3(1.0,1.0,1.0)-rgb,0.5);
    vec3 mixed = (invt * red.r) + (rgb * (1.0-red.r));
    return vec4( mixed, 1.0);
} else if (Mode == 2) {
    return vec4( mix(Mask.rgb,rgb,red.r), 1.0);
} else {
    return vec4( mix(Mask.rgb,rgb,red.r), 1.0);
}
