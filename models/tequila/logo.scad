color("green")
scale([scale, scale, scale]) {
	translate([0, 0, 33]) {
		translate([10, 0, 0]) rotate([90, 0, 90]) logo();
		translate([-10, 0, 0]) rotate([90, 0, 90]) logo();
		translate([0, -10, 0]) rotate([90, 0, 0]) logo();
		translate([0, 10, 0]) rotate([90, 0, 0]) logo();
	}
}

module logo() {
	linear_extrude(1)
	for (rot = [-50 : 22 : 50]) {
		rotate([0, 0, rot]) translate([0, 7, 0]) scale([0.1, 1, 1]) circle(d=12);
	}
}
