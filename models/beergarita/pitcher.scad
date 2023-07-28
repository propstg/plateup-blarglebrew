scale([scale, scale, scale])
union() {
    difference() {
        base();
	removeCenter();
    }
    
    handle();
    spout();
}

module base() {
    union() {
        cylinder(d=45, h=55, $fn=12);
        cylinder(d=44, h=55, $fn=50);
    }
}

module removeCenter() {
    translate([0, 0, 0.2])
    cylinder(d=42, h=65, $fn=50);
}

module handle() {
    translate([-33, 0, 15])
    difference() {
        cube([10, 2, 30]);
        translate([2.01, -.05, 2])
        cube([8, 3, 26]);
    }
}

module spout() {
    translate([0, 0, 54])
    difference() {
	    hull() {
		    cylinder(d1=44, d2=44, h=1);
		    translate([30, 0, 5])
		    cylinder(d=1, h=1);
	    }
	    translate([0, 0, -0.1])
	    hull() {
		    cylinder(d1=42, d2=42, h=2);
		    translate([28, 0, 5])
		    cylinder(d=1, h=1);
	    }
    }
}
