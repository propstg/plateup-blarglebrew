use <boot-glass.scad>

liquid3();

module liquid3() {
    scale([scale, scale, scale])
    intersection() {
        bodyScaledForLiquid();
        translate([0, 0, 25]) cube([50, 30, 10], center=true);
    }
}
