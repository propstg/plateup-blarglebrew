scale([scale, scale, scale])

translate([0, 0, 28])
lime();

module lime() {
	difference() {
		sphere(d=28);
		translate([-50, -50, -5]) cube([100, 100, 100]);
	}
}
