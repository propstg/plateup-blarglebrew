use <./michelada-glass-shape.scad>

scale([scale, scale, scale])
intersection() {
	translate([0, 0, 1]) fullGlass();
	translate([0, 0, 8]) cylinder(d=50, h=6);
}
