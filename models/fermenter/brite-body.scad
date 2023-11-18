scale([scale, scale, scale]) briteBody();

module briteBody() {
    difference() {
        union() {
            translate([0, 0, 20]) briteMainBody();
        }
    }
}

module briteMainBody() {
    translate([-45, 0, 10])
    rotate([0, 90, 0])
    difference() {
        cylinder(d=55, h=90);
        translate([0, 0, 1])
        cylinder(d=54, h=88);
    }
}
