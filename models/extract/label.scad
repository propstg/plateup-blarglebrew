color("black")
scale([scale, scale, scale])
difference() {
	translate([0, 0, 13]) cylinder(d=18.1, h=5);
	translate([0, 0, 12]) cylinder(d=18, h=8);
}
