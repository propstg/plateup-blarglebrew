module makeGrainHead() {
	translate([0.5, 0, 0]) cylinder(d1=2, d2=2, h=10);


	translate([0, 0, 8]) {
		for (i = [0 : 1 : 2]) {
			grainModified(curvePosition = 1.9^i, rotateAroundCenterAngle = 0, verticalPosition = 8 * i, seedTiltAngle = [0, 0, 0]);

			grainModified(curvePosition = 1.9^i, rotateAroundCenterAngle = 90, verticalPosition = 4 + 8 * i, seedTiltAngle = [i * 5, 0, 0]);

			grainModified(curvePosition = 1.9^i, rotateAroundCenterAngle = 180, verticalPosition = 8 * i, seedTiltAngle = [0, -i * 1, 0]);

			grainModified(curvePosition = 1.9^i, rotateAroundCenterAngle = -90, verticalPosition = 4 + 8 * i, seedTiltAngle = [-i * 5, 0, 0]);
		}
	}
}

module grainModified(curvePosition, rotateAroundCenterAngle, seedTiltAngle, verticalPosition) {
	translate([curvePosition, 0, 0])
	rotate(rotateAroundCenterAngle)
	translate([0, 0, verticalPosition])
	rotate(seedTiltAngle)
	grain();
}

module grain() {
	translate([1, 0, 0])
	rotate([0, 25, 0])
	hull() {
		sphere(d=4);

		translate([-0.25, 0, 1])
		rotate([0, 90, 0])
		cylinder(d=5, h=0.5);

		translate([-0.25, 0, 5])
		rotate([0, 90, 0])
		cylinder(d=2, h=0.5);
	}
}
