scale([scale, scale, scale])
translate([0, 0, liquid_height + 1])
difference() {
	cylinder(d=69, h=3);
	translate([0, 0, -1]) cylinder(d1=60, d2=70, h=5);
}
