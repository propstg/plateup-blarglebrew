scale([scale/1.5, scale/1.5, scale/1.5])

translate([0, 0, 106])
translate([0, 0, 1])
rotate([0, 180, 0])
scale([0.9, 0.9, 0.95])
subBottleLiquid();


module subBottleLiquid() {
    difference() {
	    union() {
		    glassBottomLiquid();
		    glassTaperLiquid();
		    glassStemLiquid();
	    }
	    translate([-20, -20, -0.1]) cube([40, 40, 10]);
    }
}

module glassBottomLiquid() {
    translate([0, 0, 3])
    cylinder(d=20, h=37);
    
    cylinder(d1=18, d2=20, h=3);
}

module glassTaperLiquid() {
    translate([0, 0, 40])
    sphere(d=20);
}

module glassStemLiquid() {
    translate([0, 0, 45])
    cylinder(d1=12, d2=8, h=35);
    
    translate([0, 0, 77])
    cylinder(d=9, h=1);
}
