scale([scale, scale, scale])
translate([-27, 0, 15])
difference() {
	union() {
		// bag inside pot
		hull() {
			sphere(d=15);
			translate([-7, -4, 22]) cube([1, 8, 1]);
		}
		// top of bag outside of pot
		hull() {
			translate([-8, -4, 22]) cube([1, 8, 1]);
			translate([-10, -0.5, 10]) cube([1, 1, 1]);
		}

		// knot on outside of pot
		translate([-10, 0, 5])
		union() {
			translate([0, 0, 4]) sphere(d=5);
			cylinder(d1=3, d2=1, h=5);
		}
	}
	// cutout for bag inside pot
	translate([0, 0, 0.5])
	hull() {
		sphere(d=14);
		translate([-7, -4, 22]) cube([0.5, 7, 0.1]);
	}
}
