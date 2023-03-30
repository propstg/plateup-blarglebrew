use <boot-glass.scad>

liquid4();

module liquid4() {
    scale([scale, scale, scale])
    intersection() {
        bodyScaledForLiquid();
        translate([0, 0, 35]) cube([50, 30, 10], center=true);
    }
}
