scale([scale, scale, scale]) briteBody();

module briteBody() {
    translate([0, 100, 0])
    difference() {
        union() {
            translate([0, 0, 40]) briteMainBody();
            briteLegs();
            translate([0, 0, 20]) briteLegBraces();
            translate([0, 0, 140]) briteTop();

            color("red") briteOutputShaft();
        }
        translate([0, 0, 105]) briteGaugeCutouts();
    }
}

module briteMainBody() {
    cylinder(d=90, h=100);
}

module briteBottomCOne() {
    cylinder(d1=20, d2=90, h=40);
}

module briteLegs() {
    translate([-27, 27, 0]) briteLeg();
    translate([-27, -27, 0]) briteLeg();
    translate([27, 27, 0]) briteLeg();
    translate([27, -27, 0]) briteLeg();
}

module briteLeg() {
    cylinder(d=10, h=70);
}

module briteLegBraces() {
    legSpacing = 25 * 2;
    diffSpacing = 23 * 2;

    difference() {
        translate([-legSpacing / 2, -legSpacing / 2, 0])
        cube([legSpacing, legSpacing, 2]);

        translate([-diffSpacing / 2, -diffSpacing / 2, -0.5])
        cube([diffSpacing, diffSpacing, 3]);
    }
}

module briteTop() {
    intersection() {
        translate([0, 0, -56])
        sphere(d=150);
        cylinder(d=85, h=15);
    }
}

module briteGaugeCutouts() {
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

module briteOutputShaft() {
    translate([-40, 0, 50])
    rotate([0, 90, 0])
    cylinder(d=5, h=30);
}
