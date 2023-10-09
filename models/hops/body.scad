scale([scale, scale, scale])
difference() {
	union() {
		hull() {
			sphere(d=15);
			translate([0, 0, 35])
			sphere(d=2);
		}
		translate([0, 0, 35]) sphere(d=5);
		translate([0, 0, 35]) cylinder(d1=1, d2=3, h=5);
	}
	translate([0, 0, 1])
	hull() {
		sphere(d=14);
		translate([0, 0, 36])
		sphere(d=1);
	}
}
