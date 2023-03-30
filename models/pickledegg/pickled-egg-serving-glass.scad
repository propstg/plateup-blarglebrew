scale([scale, scale, scale])
difference() {
	cylinder(d1=6, d2=11, h=8, $fn=10);
	translate([0, 0, 2]) cylinder(d1=6, d2=11, h=8, $fn=10);
}
