scale([scale, scale, scale])
difference() {
	cylinder(d1=9, d2=12, h=16, $fn=10);
	translate([0, 0, 2]) cylinder(d1=9, d2=12, h=16, $fn=10);
}
