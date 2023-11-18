scale([scale, scale, scale])
normalLabels();

module normalLabels() {
	// first shelf
	translate([30, 29, 57]) rotate([-90, 90, 90]) kegBand();
	translate([30, -23, 61]) rotate([-90, 90, 90]) kegBand();

	// middle shelf
	translate([30, 29, 121]) rotate([-90, 90, 90]) kegBand();
	translate([30, -23, 124]) rotate([-90, 90, 90]) kegBand();
}

module kegBand() {
    color("red")
    translate([0, 0, 22])
    cylinder(r=25.2, h=15);
}