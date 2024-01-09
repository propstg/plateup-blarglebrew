height = 35;

scale([scale, scale, scale])
difference() {
	union() {
		cylinder(d1=68, d2=70, h=2);
		translate([0, 0, 2]) cylinder(d=70, h=height);

		// spigot
		translate([30, 0, 10])
		rotate([0, 90, 0])
		cylinder(d=8, h=15);

		// handles
		translate([0, -35, height])
		cube([15, 8, 2], center=true);
		translate([0, 35, height])
		cube([15, 8, 2], center=true);


	}
	translate([0, 0, 1]) cylinder(d=69, h=height+2); // cutout
}
