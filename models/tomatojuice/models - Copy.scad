

//scale([0.01, 0.01, 0.01]) keg();
scale([0.01, 0.01, 0.01]) 
mug();

//keg();
//kegerator();
//referenceCube();


height = 70;
width = 100;

module mug() {
    //mugGlass();
    //mugContents();
    //mugFoam();
}

module mugGlass() {
    difference() {
        cylinder(d=40, h=50, $fn=10);
        translate([0, 0, 0.2])
        cylinder(d=38, h=55, $fn=50);
    }
    
    translate([-27, 0, 10])
    difference() {
        cube([7, 2, 30]);
        translate([1.01, -.05, 1])
        cube([6, 3, 28]);
    }
}

module mugContents() {
    color("brown")
    cylinder(d=38, h=40, $fn=50);
}

module mugFoam() {
    color("white")
    translate([0, 0, 40])
    cylinder(d=38, h=11, $fn=50);
}

module keg() {
    cylinder(r=25, h=50);    
}

module kegerator() {
    //translate([0, -10, 5]) keg();
    
    //kegBase();
    //kegDoorFrameClosed();
    //kegDoorGlassClosed();
    
    //kegDoorFrameOpen();
    //kegDoorGlassOpen();
    //tapColumn();
    tapLabel();
}



module kegBase() {
    translate([-50, -50, 0])
    difference() {
        cube([100, 70, height]);
        
        translate([2.5, 3, 2.5])
        cube([95, 100, height - 5]);
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