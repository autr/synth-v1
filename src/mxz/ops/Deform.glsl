vec2 pos = POS_NORM;
vec2 center = vec2( 0.5, 0.5 );
float off = Offset;
float all = mix(SUM_RGBA(Src)/3.0,1.0,1.0-SrcAmount);
if (Invert) all = 1.0 - all;
float bb = (all*2.0)-1.0;
bb += off;

float mini = Mini ? 0.1 : 1.;

vec2 xy = XY * vec2(mini,mini);
vec2 zoom = Zoom * vec2(mini,mini);

float angle = ANGLE(center, pos);

pos.x += xy.x * bb;
pos.y += xy.y * bb;
pos.x += (((pos.x * 2.0) - 1.0) * zoom.x) * bb;
pos.y += ((pos.y * 2.0) - 1.0) * (zoom.y * bb);
if (Rotate) pos = ROTATE_VEC2(Origin, pos, 	Degree * bb * 180. * mini);

return IMG_NORM_PIXEL(TEXTURE,pos);
