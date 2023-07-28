use <./bottle-shape.scad>

scale([scale, scale, scale])
difference() {
	bottle();
	scale([0.95, 0.95, 0.98]) bottle();
}
