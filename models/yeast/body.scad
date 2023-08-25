$fn = 30;
scale([scale, scale, scale])
hull() {
	translate([-0.5, -9, 0]) cube([1, 18, 1]);
	translate([-0.25, -9, 0]) cube([0.5, 18, 20]);
	translate([-2.5, -5, 0]) cube([5, 10, 1]);
	cylinder(d=7, h=1);
}

