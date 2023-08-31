$fn = 30;
scale([scale, scale, scale])
translate([0, 0, 2]) 
intersection() {
	cylinder(d1=22, d2=8, h=25);
	cylinder(d=25, h=10);
}

