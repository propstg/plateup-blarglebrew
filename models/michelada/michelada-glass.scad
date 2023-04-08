use <./michelada-glass-shape.scad>

scale([scale, scale, scale])
difference() {
	fullGlass();
	translate([0, 0, 3]) fullGlass();
}
