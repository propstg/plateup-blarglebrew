scale([scale, scale, scale])
union() {
	base();
	stem();
	translate([0, 0, 28]) 
	difference() {
		cup();
		translate([0, 0, 1]) cupLiquid();
	}

}

module base() {
	cylinder(d=20, h=2);
}

module stem() {
	cylinder(d1=3, d2=6, h=15);
}

module cup() {
	difference() {
		sphere(d=30);
		translate([-50, -50, 0]) cube([100, 100, 100]);
	}
	cylinder(d=30, h=5);
}

module cupLiquid() {
	difference() {
		sphere(d=28);
		translate([-50, -50, 1]) cube([100, 100, 100]);
	}
	cylinder(d=28, h=5);
}
