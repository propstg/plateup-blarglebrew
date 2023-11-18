scale = 1;
include <./brite-legs.scad>
include <./brite-body.scad>
include <./fermenter-body.scad>
segmentNumber=1;
zPosition = 3;
include <./brite-body-segment.scad>
for (i = [0 : 19]) {
    translate([-10, 0, 0])
    briteGaugeSegment(3, i);
}
for (i = [0 : 19]) {
    translate([-10, 0, 0])
    briteGaugeSegment(75, i);
}
include <./reference-cube.scad>