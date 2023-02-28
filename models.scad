$fn = 100;

//scale([0.01, 0.01, 0.01]) keg();
scale([0.01, 0.01, 0.01]) 
//mug();

//keg();
kegRack();
//kegBand();
//kegerator();
//referenceCube();


height = 70;
width = 100;

module kegRack() {
    // first shelf
    //translate([30, 29, 57]) rotate([-90, 90, 90]) keg();
    //translate([30, 29, 57]) rotate([-90, 90, 90]) kegBand();
    //translate([30, -23, 61]) rotate([-90, 90, 90]) keg();
    //translate([30, -23, 61]) rotate([-90, 90, 90]) kegBand();
    
    // middle shelf
    //translate([30, 29, 121]) rotate([-90, 90, 90]) keg();
    //translate([30, 29, 121]) rotate([-90, 90, 90]) kegBand();
    //translate([30, -23, 124]) rotate([-90, 90, 90]) keg();
    //translate([30, -23, 124]) rotate([-90, 90, 90]) kegBand();
    
    // top shelf
    //translate([30, 29, 185]) rotate([-90, 90, 90]) keg();
    //translate([30, 29, 185]) rotate([-90, 90, 90]) kegBand();
    
    // bottom shelf
    translate([-50, -50, 35])
    union() {
        rotate([-5, 0, 0])      cube([100, 100, 2]);
        translate([0, 100, -6]) cube([100, 2, 15]);
    }
    
    // middle shelf
    translate([-50, -50, 100])
    union() {
        rotate([-5, 0, 0])      cube([100, 100, 2]);
        translate([0, 100, -6]) cube([100, 2, 15]);
    }
    
    // top shelf
    translate([-50, -50, 165])
    union() {
        rotate([-5, 0, 0])      cube([100, 100, 2]);
        translate([0, 100, -6])  cube([100, 2, 15]);
    }
    
    // legs
    translate([-50, -50, 0])
    cylinder(d=5, 200);
    translate([-50, 50, 0])
    cylinder(d=5, 200);
    translate([50, -50, 0])
    cylinder(d=5, 200);
    translate([50, 50, 0])
    cylinder(d=5, 200);
    
}

module mug() {
    //mugGlass();
    mugContents();
    //mugFoam();
}

module mugGlass() {
    scale([0.6, 0.6, 0.6])
    union() {
    difference() {
        cylinder(d=40, h=50, $fn=50);
        translate([0, 0, 5])
        cylinder(d=35, h=55, $fn=50);
    }
    
    translate([-29, -2.5, 10])
    difference() {
        cube([10, 5, 30]);
        translate([4.01, -.05, 4])
        cube([7, 6, 22]);
    }
}
}

module mugContents() {
    scale([0.6, 0.6, 0.6])
    color("brown")
    translate([0, 0, 5])
    cylinder(d=34.5, h=40, $fn=50);
}

module mugFoam() {
    color("white")
    scale([0.6, 0.6, 0.6])
    union() {
        
        translate([0, 0, 44])
        cylinder(d=34.75, h=6, $fn=50);
        
        translate([0, 0, 50])
        cylinder(d=40, h=1, $fn=50);
        
        difference() {
            translate([0, 0, 0])
            cylinder(d=41, h=51, $fn=50);
            
            translate([0, 0, -0.5])
            cylinder(d=40, h=52, $fn=50);
            
            
            translate([35, 0, 10])
            sphere(d=75);
            
            
            translate([-34, 10, 10])
            sphere(d=80);
        }
        
    }
}

module kegBand() {
    color("red")
    translate([0, 0, 22])
    cylinder(r=25.2, h=15);
}

module keg() {
    //cylinder(r=25, h=50);
    cylinder(r1=24, r2=25, h=12);
    
    translate([0, 0, 12])
    hull() {
        cylinder(r=25, h=10);
        translate([0, 0, 5])
        cylinder(r=26, h=1);
    }
    
    translate([0, 0, 22])
    cylinder(r=25, h=15);
    
    translate([0, 0, 37])
    hull() {
        cylinder(r=25, h=10);
        translate([0, 0, 5])
        cylinder(r=26, h=1);
    }
    
    translate([0, 0, 45])
    difference() {
        cylinder(r=25, h=15);
        
        translate([0, 0, 5.01])
        cylinder(r=23, h=10);
        
        translate([-7.5, -50, 7])
        cube([15, 100, 5]);
    }
    
    cylinder(d=10, h=55);
}

module kegerator() {
    //translate([0, -10, 5]) keg();
    
    kegBase();
    //kegDoorFrameClosed();
    //kegDoorGlassClosed();
    
    //kegDoorFrameOpen();
    //kegDoorGlassOpen();
    //tapColumn();
    //tapLabel();
}



module kegBase() {
    translate([-50, -50, 0])
    difference() {
        cube([100, 70, height]);
        
        translate([2.5, 3, 7.5])
        cube([95, 100, height - 10]);
    }
}

module kegDoorGlassOpen() {
    translate([-4, 13, 0])
    rotate([0, 0, -15])
    kegDoorGlass();
}

module kegDoorFrameOpen() {
    translate([-4, 13, 0])
    rotate([0, 0, -15])
    kegDoorFrame();
}

module kegDoorGlassClosed() {
    kegDoorGlass();
}

module kegDoorFrameClosed() {
    kegDoorFrame();
}

module kegDoorFrame() {
    difference() {
        translate([-width/2, 20, 0])
        cube([width, 2.5, height]);
        
        kegDoorGlass();
    }
}

module kegDoorGlass() {
    translate([-width/2+15/2, 20-0.001, 15/2])
    cube([width-15, 2.7, height-15]);
}

module tapColumn() {
    translate([0, -15, height])
    cylinder(d=5, h=25, $fn=30);
    
    translate([-2.5/2, -15, height+20])
    cube([2.5, 10, 2.5]);
}

module tapLabel() {
    translate([-5, -18, height+20])
    cube([10, 2.5, 20]);
}

module referenceCube() {
    translate([-50, -200, 0])
    cube([100, 100, 100]);
}