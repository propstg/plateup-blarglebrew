color("black")
scale([scale, scale, scale]) {
	translate([-50, -30, 75]) sphere(d=8);
	translate([-50, -30, 165]) sphere(d=8);
	translate([-50, -30, 75]) rotate([0, 90, 0]) cylinder(d=8, h=20);
	translate([-50, -30, 165]) rotate([0, 90, 0]) cylinder(d=8, h=20);
}
