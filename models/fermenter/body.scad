body();

module body() {
    scale([scale, scale, scale])
    difference() {
        union() {
            translate([0, 0, 70]) mainBody();
            translate([0, 0, 30]) bottomCone();
            legs();
            translate([0, 0, 20]) legBraces();
            translate([0, 0, 170]) top();

            color("red") outputShaft();
        }
        translate([0, 0, 105]) gaugeCutouts();
    }
}

module mainBody() {
    cylinder(d=90, h=100);
}

module bottomCone() {
    cylinder(d1=20, d2=90, h=40);
}

module legs() {
    translate([-27, 27, 0]) leg();
    translate([-27, -27, 0]) leg();
    translate([27, 27, 0]) leg();
    translate([27, -27, 0]) leg();
}

module leg() {
    cylinder(d=10, h=70);
}

module legBraces() {
    legSpacing = 25 * 2;
    diffSpacing = 23 * 2;

    difference() {
        translate([-legSpacing / 2, -legSpacing / 2, 0])
        cube([legSpacing, legSpacing, 2]);

        translate([-diffSpacing / 2, -diffSpacing / 2, -0.5])
        cube([diffSpacing, diffSpacing, 3]);
    }
}

module top() {
    intersection() {
        translate([0, 0, -56])
        sphere(d=150);
        cylinder(d=85, h=15);
    }
}

module gaugeCutouts() {
    translate([-50, 0, 0]) gaugeCutout();
    /*
    translate([50, 0, 0]) gaugeCutout();
    translate([0, -50, 0]) gaugeCutout();
    translate([0, 50, 0]) gaugeCutout();
    */
}

module gaugeCutout() {
    sphere(d=40);
}

module outputShaft() {
    translate([-40, 0, 50])
    rotate([0, 90, 0])
    cylinder(d=5, h=30);
}