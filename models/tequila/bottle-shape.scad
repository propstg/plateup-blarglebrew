module bottle() {
	union() {
		hull() {
			cube([18, 18, 1], center=true);
			translate([0, 0, 2]) cube([20, 20, 1], center=true);
		}
		hull() {
			translate([0, 0, 2.5]) cube([20, 20, 2], center=true);
			translate([0, 0, 4]) cube([18, 18, 1], center=true);
		}

		hull() {
			translate([0, 0, 4]) cube([18, 18, 1], center=true);
			translate([0, 0, 50]) cube([20, 20, 1], center=true);
		}

		hull() {
			translate([0, 0, 50]) cube([20, 20, 1], center=true);
			translate([0, 0, 59]) cylinder(d=10, h=1);
		}
		translate([0, 0, 58])
		cylinder(d1=10, d2=9, h=25);

	}
}
