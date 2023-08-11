fermenterGaugeSegment(segmentNumber);

module fermenterGaugeSegment(segmentNumber) {
	scale([scale, scale, scale]) {
		translate([-50, -30, 75+(9*segmentNumber)]) rotate([0, 0, 0]) cylinder(d=7, h=90/10);
	}
}
