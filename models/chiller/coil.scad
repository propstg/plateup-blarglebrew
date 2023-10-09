diameter = 35;
thicknessZ = 1;
thicknessX = 1;
angle = 15;
spacing = 1.5;

scale([scale,scale,scale]) {
	translate([0, 0, 60])
	for (i = [0 : 1 : 40]) {
		ring(i);
	}

}

module ring(z) {
	translate([0, 0, z * spacing])
	rotate([angle, 0, 0])
	difference() {
		cylinder(d=diameter, h=thicknessZ);
		translate([0, 0, -thicknessZ]) cylinder(d=diameter - thicknessX, h=thicknessZ * 3);
	}
}
