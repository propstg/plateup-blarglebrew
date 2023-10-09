scale([scale, scale, scale])
difference() {
	union() {
		cylinder(d1=15, d2=18, h=3);
		translate([0, 0, 3]) cylinder(d=18, h=25);
		translate([0, 0, 28]) cylinder(d=17, h=2);
	}
	translate([0, 0, 2]) cylinder(d=15, h=30);
}
