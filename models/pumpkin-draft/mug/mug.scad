scale([scale, scale, scale]) 
mugGlass();

module mugGlass() {
    difference() {
        cylinder(d=40, h=50, $fn=10);
        translate([0, 0, 0.2])
        cylinder(d=38, h=55, $fn=50);
    }
    
    translate([-27, 0, 10])
    difference() {
        cube([7, 2, 30]);
        translate([1.01, -.05, 1])
        cube([6, 3, 28]);
    }
}
