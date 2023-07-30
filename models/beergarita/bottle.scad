scale([scale/1.5, scale/1.5, scale/1.5])

translate([0, 0, 106])
rotate([0, 180, 0])
bottle();

module bottle() {
	difference() {
	    subBottle();
	    
	    translate([0, 0, 1])
	    scale([0.9, 0.9, 0.95])
	    subBottle();
	    
	    translate([0, 0, 0.2])
	    cylinder(d=7, h=100);
	}
    
}


module subBottle() {
    glassBottom();
    glassTaper();
    glassStem();
}

module glassBottom() {
    translate([0, 0, 3])
    cylinder(d=20, h=37);
    
    cylinder(d1=18, d2=20, h=3);
}

module glassTaper() {
    translate([0, 0, 40])
    sphere(d=20);
}

module glassStem() {
    translate([0, 0, 45])
    cylinder(d1=12, d2=8, h=35);
    
    translate([0, 0, 77])
    cylinder(d=9, h=1);
}
