color("blue")

scale([scale, scale, scale])
translate([-36, -3, 70])
union() {
	translate([0, 0, 9])
	rotate([0, 65, 0])
	cube([10, 6, 1]);

	rotate([0, -65, 0])
	cube([10, 6, 1]);
}
