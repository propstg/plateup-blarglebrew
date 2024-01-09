color("black")
scale([scale, scale, scale])
translate([-10, 0, 3])
rotate([0, 90, 0])
union () {
	translate([-2.2, -4.75, 7])
	rotate([0, 99, 0])
	linear_extrude(1)
	rotate(90)
	text("Y");

	translate([1.2, -4.75, 7])
	rotate([0, 81, 0])
	linear_extrude(1)
	rotate(90)
	text("Y");
}
