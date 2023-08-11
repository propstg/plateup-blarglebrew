color("black")
scale([scale, scale, scale]) {
	translate([-50, 130, 45]) sphere(d=8);
	translate([-50, 130, 135]) sphere(d=8);
	translate([-50, 130, 45]) rotate([0, 90, 0]) cylinder(d=8, h=20);
	translate([-50, 130, 135]) rotate([0, 90, 0]) cylinder(d=8, h=20);
}
