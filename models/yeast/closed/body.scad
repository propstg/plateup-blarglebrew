$fn = 30;
scale([scale, scale, scale])
difference() {
	union() {
		cylinder(d1=20, d2=23, h=2);
		translate([0, 0, 2]) cylinder(d1=23, d2=8, h=25);
		translate([0, 0, 27]) cylinder(d=8, h=8);
		translate([0, 0, 33]) cylinder(d=9, h=2);
	}
	translate([0, 0, 2]) cylinder(d1=22, d2=8, h=25.001);
	translate([0, 0, 2]) cylinder(d=7, h=40);
}

