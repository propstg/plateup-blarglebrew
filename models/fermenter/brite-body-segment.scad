//segmentNumber = 1;
//zPosition = 58;
// 3 for brite, 58 for fermenter
briteGaugeSegment(zPosition, segmentNumber);

module briteGaugeSegment(zPosition, segmentNumber) {
	scale([scale, scale, scale]) {
        amount = 54/20 * segmentNumber;
        translate([0, 0, zPosition])
        intersection() {
            translate([-45, 0, 54/2])
            rotate([0, 90, 0])
            translate([0, 0, 1])
            cylinder(d=54, h=88);

            translate([-50, -50, amount])
            cube([100, 100, 54/20]);
        }
	}
}
