color("black")
intersection() {
	theMug();
	theFace();
}

module theMug() {
	scale([scale, scale, scale]) 
	difference() {
		cylinder(d=42, h=50, $fn=10);
		translate([0, 0, 0.2])
		cylinder(d=40, h=55, $fn=50);
	}
}

module theFace() {
	scale([scale*.75, scale*.75, scale*.75]) 
	translate([10, 30, 45])
	rotate(90)
	rotate([0, -90, 0])
	union() {
		// left eye
		translate([0, -2.5, 0])
		cylinder(d=15, h=60, $fn=3);

		// right eye
		translate([0, 22.5, 0])
		cylinder(d=15, h=60, $fn=3);

		// nose
		translate([-13, 10, 0])
		cylinder(d=10, h=60, $fn=3);

		//mouth
		translate([-7, 10, 0])
		difference() {
			cylinder(d=50, h=60, $fn=15);
			translate([10, 0, -0.1])
			cylinder(d=60, h=61, $fn=10);
		}
	}
}
