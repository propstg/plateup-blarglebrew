$fn = 30;
scale([scale, scale, scale])
translate([-10, 0, 3])
rotate([0, 90, 0])
hull() {
	translate([-0.25, -8.5, 0]) cube([0.5, 17, 1]);
	translate([-0.25/2, -8.5, 0]) cube([0.25, 17, 20]);
	translate([-2, -4.5, 0]) cube([4, 9, 1]);
	cylinder(d=6, h=1);
}

