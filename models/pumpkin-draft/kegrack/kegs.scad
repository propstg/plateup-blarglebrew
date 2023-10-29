use <../keg/keg-shape.scad>
use <../keg/keg.scad>

scale([scale, scale, scale])
kegs();

module kegs() {
	// first shelf
	translate([30, 29, 57]) rotate([-90, 90, 90]) keg();
	translate([30, -23, 61]) rotate([-90, 90, 90]) keg();

	// middle shelf
	translate([30, 29, 121]) rotate([-90, 90, 90]) keg();
	translate([30, -23, 124]) rotate([-90, 90, 90]) keg();

	// top shelf
	translate([30, 29, 185]) rotate([-90, 90, 90]) keg();
}
