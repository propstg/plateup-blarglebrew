use <boot-glass.scad>

liquid1();

module liquid1() {
    scale([scale, scale, scale])
    intersection() {
        bodyScaledForLiquid();
        translate([0, 0, 5]) cube([50, 30, 10], center=true);
    }
}
