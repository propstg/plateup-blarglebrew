use <../keg/face.scad>

scale([scale, scale, scale])
labels();

module labels() {
	// first shelf
	translate([30, 29, 57]) rotate([-90, 90, 90]) kegFace();
	translate([30, -23, 61]) rotate([-90, 90, 90]) kegFace();

	// middle shelf
	translate([30, 29, 121]) rotate([-90, 90, 90]) kegFace();
	translate([30, -23, 124]) rotate([-90, 90, 90]) kegFace();
}
