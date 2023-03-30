body();

module body() {
    scale([scale, scale, scale])
    difference() {
        bodyNoScaling(0, 0);
	bodyScaledForLiquid();
    }
}

module bodyScaledForLiquid() {
    bodyNoScaling(-2, 0.5);
}

module bodyNoScaling(diameterOffset, zOffset) {
    translate([0, 0, zOffset])
    union() {
	    difference() {
		    hull() {
			    translate([12, 0, 0])
			    difference() {
				    translate([0, 0, 0]) sphere(d=15+diameterOffset);
				    translate([0, 0, -15]) cube([30, 30, 30], center=true);
			    }
			    translate([0, 0, 0]) cylinder(d=15+diameterOffset, h=10-zOffset);
		    }
		    translate([4, -10, -3])
		    rotate([0, 90, 90])
		    cylinder(d=10-diameterOffset, h=20+zOffset);
	    }


	    translate([0, 0, 10-zOffset-0.01]) cylinder(d1=15+diameterOffset, d2=15+diameterOffset, h=5+zOffset+0.02);
	    translate([0, 0, 15]) cylinder(d1=15+diameterOffset, d2=20+diameterOffset, h=10+zOffset);
	    translate([0, 0, 25]) cylinder(d1=20+diameterOffset, d2=22+diameterOffset, h=10+zOffset);
	    translate([0, 0, 35]) cylinder(d1=22+diameterOffset, d2=20+diameterOffset, h=5+zOffset);
    }
}
