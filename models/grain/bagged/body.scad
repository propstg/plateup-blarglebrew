scale([scale, scale, scale])
translate([0, 0, 10])
difference() {
	union() {
		hull() {
			sphere(d=30);
			translate([0, 0, 35])
			sphere(d=2);
		}
		translate([0, 0, 35]) sphere(d=5);
		translate([0, 0, 35]) cylinder(d1=1, d2=3, h=5);
	}
	translate([0, 0, 1])
	hull() {
		sphere(d=29);
		translate([0, 0, 34])
		sphere(d=1);
	}
}
