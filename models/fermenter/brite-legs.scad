scale([scale, scale, scale]) 
briteLegs();

module briteLegs() {
    translate([-30, 30, 0]) briteLeg();
    translate([-30, -30, 0]) briteLeg();
    translate([30, 30, 0]) briteLeg();
    translate([30, -30, 0]) briteLeg();
}

module briteLeg() {
    cylinder(d=8, h=110);
}
