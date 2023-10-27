module keg() {
    cylinder(r1=24, r2=25, h=12);

    translate([0, 0, 12])
    hull() {
        cylinder(r=25, h=10);
        translate([0, 0, 5])
        cylinder(r=26, h=1);
    }

    translate([0, 0, 22])
    cylinder(r=25, h=15);

    translate([0, 0, 37])
    hull() {
        cylinder(r=25, h=10);
        translate([0, 0, 5])
        cylinder(r=26, h=1);
    }

    translate([0, 0, 45])
    difference() {
        cylinder(r=25, h=15);

        translate([0, 0, 5.01])
        cylinder(r=23, h=10);

        translate([-7.5, -50, 7])
        cube([15, 100, 5]);
    }

    cylinder(d=10, h=55);

}
