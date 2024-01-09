scale([scale, scale, scale])
kegRack();

module kegRack() {
    // bottom shelf
    translate([-50, -50, 35])
    union() {
        rotate([-5, 0, 0])      cube([100, 100, 2]);
        translate([0, 100, -6]) cube([100, 2, 15]);
    }
    
    // middle shelf
    translate([-50, -50, 100])
    union() {
        rotate([-5, 0, 0])      cube([100, 100, 2]);
        translate([0, 100, -6]) cube([100, 2, 15]);
    }
    
    // legs
    translate([-50, -50, 0])
    cylinder(d=5, 150);
    translate([-50, 50, 0])
    cylinder(d=5, 150);
    translate([50, -50, 0])
    cylinder(d=5, 150);
    translate([50, 50, 0])
    cylinder(d=5, 150);    
}
