use <./egg.scad>

servingEggs();

module servingEggs() {
	scale([scale, scale, scale])
	union() {
		translate([0, -0.5, 3]) rotate([45, 0, 0]) egg();
		translate([0, 2.1, 7]) rotate([0, 80, 0]) egg();
	}
}
