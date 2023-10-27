scale([scale, scale, scale]) 
mugGlass();

module mugGlass() {
    difference() {
        cylinder(d=40, h=50, $fn=50);
        translate([0, 0, 0.2])
        cylinder(d=35, h=55, $fn=50);
    }
    
    translate([-27, -2.5, 10])
    difference() {
        cube([10, 5, 30]);
        translate([3.01, -.05, 3])
        cube([6, 6, 23]);
    }
}
