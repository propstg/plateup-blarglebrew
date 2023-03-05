$fn=15;


hasCap = true;
hasBottle = false;
hasLiquid = false;
hasCardboard = false;
showBox = true;

scale([0.01, 0.01, 0.01])
//referenceCube();
//fakeCounter();
//scale([0.01, 0.01, 0.01])
//translate([0, 0, 41]) 

bottleBox();
//bottle();


module bottle() {
    if (hasCap) {
        color("green")
        translate([0, 0, 80])
        cylinder(d1=9, d2=7, h=2);
    } 
    
    if (hasBottle) {
        difference() {
            subBottle();
            
            translate([0, 0, 1])
            scale([0.9, 0.9, 0.95])
            subBottle();
            
            translate([0, 0, 0.2])
            cylinder(d=7, h=100);
        }
    }
    
    if (hasLiquid) {
        color("yellow")
        translate([0, 0, 1])
        scale([0.9, 0.9, 0.95])
        subBottle();
    }
}

module bottleBox() {
    translate([0, 0, 40])
    scale([0.5, 0.5, 0.5])
    if (showBox) {
        if (hasCardboard) {
            color("blue")
            translate([-21/2, -21/2, 0])
            difference() {
                cube([21*4 , 21*3, 85]);
                
                translate([1, 1, 1])
                cube([21*4 - 2, 21*3 - 2, 83]);
                
                translate([-1, -1, 50])
                cube([35, 22 * 3, 36]);
            }
        }
        
        for (x = [0 : 1]) {
            for (y = [0 : 2]) {
                translate([x * 21, y * 21, 0])
                bottle();
            }
        }
        
    }
}

module subBottle() {
    glassBottom();
    glassTaper();
    glassStem();
}

module glassBottom() {
    translate([0, 0, 3])
    cylinder(d=20, h=37);
    
    cylinder(d1=18, d2=20, h=3);
}

module glassTaper() {
    translate([0, 0, 40])
    sphere(d=20);
}

module glassStem() {
    translate([0, 0, 45])
    cylinder(d1=12, d2=8, h=35);
    
    translate([0, 0, 77])
    cylinder(d=9, h=1);
}

module referenceCube() {
    translate([-50, -200, 0])
    cube([100, 100, 100]);
}