vec2 pos = POS_NORM;
vec2 xy = POS_FRAG;
float idx = ( xy.y * RENDERSIZE.x ) + ( xy.x );

if (Mode == 1) {
	idx = distance(pos,Origin) * (RENDERSIZE.x * RENDERSIZE.y);
}

float freq = (Frequency.x * 0.01) + (Frequency.y * 0.0001);
float wobble = sin((TIME * Speed) + (idx * freq));

pos = VEC2_FROM_ANGLE( pos, Angle, wobble * Amount * 0.5 );

pos.x = FMOD(pos.x, 1.);
pos.y = FMOD(pos.y, 1.);

return IMG_NORM_PIXEL(TEXTURE,pos);
