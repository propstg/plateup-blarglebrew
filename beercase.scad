
//referenceCube();
//fakeCounter();
translate([0, 0, 41]) closedBeerCan();
translate([20, 0, 41]) openBeerCan();
translate([0, 0, 41]) beerCanBox();

showCanOpened = false;
showCanClosed = false;
showPaintedParts = false;
showAluminumParts = false;
showFoam = false;
showCanBox = true;

module beerCanBox() {
    if (showCanBox) {
        if (showCanClosed) {
            //translate([11, 15, 38]) rotate([90, 0, 0]) closedBeerCan();
            translate([17, 15, 37]) rotate([90, 0, 0]) closedBeerCan();
            translate([28, 15, 37]) rotate([90, 0, 0]) closedBeerCan();
            
            translate([-22, 15, 27]) rotate([90, 0, 0]) closedBeerCan();
            translate([-11, 15, 27]) rotate([90, 0, 0]) closedBeerCan();
            translate([0, 15, 27]) rotate([90, 0, 0]) closedBeerCan();
            translate([11, 15, 27]) rotate([90, 0, 0]) closedBeerCan();
            translate([22, 15, 27]) rotate([90, 0, 0]) closedBeerCan();
            translate([33, 15, 27]) rotate([90, 0, 0]) closedBeerCan();
        } else {
            
        }
        color("white")
        translate([-30, -19, -1])
        difference() {
            cube([70, 36, 45]);
            translate([0.5, 0.5, 0])
            cube([69, 35, 44]);
            translate([46, -0.5, 30])
            cube([25, 37, 44]);
        }
        
        
        
        
        


    }
}

module closedBeerCan() {
    canBottom();
    canSideWall();
    canTopClosed();  
}

module openBeerCan() {
    if (showCanOpened) {
        canBottom();
        canSideWall();
        canTopOpen();
        canOpenFoam();
    }
}

module canBottom() {
    if (showAluminumParts) {
        cylinder(d1=10, d2=11, h=1, $fn=50);
    }
}

module canTopClosed() {
    if (showAluminumParts && showCanClosed) {
        translate([0, 0, 30])
        cylinder(d2=10, d1=11, h=1.5, $fn=50);
        
        translate([0, 0, 31.5])
        difference() {
            color("blue")
            cylinder(d=10, h=0.5, $fn=50);
            
            translate([0, 0, -1])
            cylinder(d=9, h=2, $fn=50);
        }
        
        translate([-3/2, 0, 31.5])
        cube([3, 4, 0.5]);
    }
}

module canTopOpen() {
    if (showAluminumParts && showCanOpened) {
        translate([0, 0, 30])
        cylinder(d2=10, d1=11, h=1.5, $fn=50);
        
        translate([0, 0, 31.5])
        difference() {
            color("blue")
            cylinder(d=10, h=0.5, $fn=50);
            
            translate([0, 0, -1])
            cylinder(d=9, h=2, $fn=50);
        }
        
        translate([-3/2, 0, 31.5])
        rotate([90, 0, 0])
        cube([3, 4, 0.5]);
    }
}

module canOpenFoam() {
    if (showFoam) { 
        intersection() {
            union() {
                //translate([0, -7, 28])
                //sphere(d=13);
                
                translate([0, -2, 0])
                cylinder(d=11.1, h=32.5);
                
            }
        
            cylinder(d1=9, d2=15, h=50);
        }
    }
}

module canSideWall() {
    if (showPaintedParts) {
        translate([0, 0, 1])
        cylinder(d=11, h=29.0, $fn=50);
    }
}

module fakeCounter() {
    translate([-50, -50, 0])
    cube([100, 100, 40]);
}

module referenceCube() {
    translate([-50, -200, 0])
    cube([100, 100, 100]);
}