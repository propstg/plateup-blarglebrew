use <boot-glass.scad>

liquid2();

module liquid2() {
    scale([scale, scale, scale])
    intersection() {
        bodyScaledForLiquid();
        translate([0, 0, 15]) cube([50, 30, 10], center=true);
    }
}
