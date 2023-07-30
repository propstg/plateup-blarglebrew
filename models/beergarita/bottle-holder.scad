scale([scale, scale, scale]) {

	translate([0, 0, 31])
	linear_extrude(3)
	difference() {
		hull() {
			circle(d=11);
			translate([0, 10]) square([10, 10], center=true);
			
		}
		circle(d=10);
	}
}
