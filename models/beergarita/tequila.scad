scale([scale, scale, scale])

translate([0, 0, 28])
tequila();

module tequila() {
	difference() {
		union() {
			sphere(d=28);
			cylinder(d=28, h=5);
		}
		translate([-50, -50, 2]) cube([100, 100, 100]);
		translate([-50, -50, -25]) cube([100, 100, 20]);
	}
}
