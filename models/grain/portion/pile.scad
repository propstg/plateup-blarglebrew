use <../wheat.scad>

scale([scale, scale, scale]) {
	translate([20, 0, 0]) 
	union() {
		rotate([0, -90, 0]) makeGrainHead();
		translate([-40, 20, 0]) rotate([90, 0, 15]) makeGrainHead();
		rotate([0, 15, 0]) translate([-40, 15, -3]) rotate([180, -90, -15]) makeGrainHead();
		//color("red") translate([-0, -20, 0]) rotate([-75, -55, 15]) makeGrainHead();
	}
}
