briteGaugeSegment(segmentNumber);

module briteGaugeSegment(segmentNumber) {
	scale([scale, scale, scale]) {
		translate([-50, 130, 45+(9*segmentNumber)]) rotate([0, 0, 0]) cylinder(d=7, h=90/10);
	}
}
