scale([scale, scale, scale]) fermenterBody();

module fermenterBody() {
    difference() {
        union() {
            translate([0, 0, 75]) fermenterMainBody();
            //translate([0, 0, 20]) briteLegBraces();
            //translate([0, 0, 140]) briteTop();

            //color("red") briteOutputShaft();
        }
        //translate([0, 0, 105]) briteGaugeCutouts();
    }
}

module fermenterMainBody() {
    translate([-45, 0, 27])
    rotate([0, 90, 0])
    difference() {
        cylinder(d=55, h=90);
        translate([0, 0, 1])
        cylinder(d=54, h=88);
    }
}