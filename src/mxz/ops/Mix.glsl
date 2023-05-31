
if (Mode == 0) {
	return INPUT;
} else if (Mode == 1) {
	return IMG_NORM_PIXEL( u999, POS_NORM ).rgb;
} else if (Mode == 2) {
	return Src;
}