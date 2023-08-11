include <./body.scad>
include <./spigot.scad>
//include <./gauge.scad>
include <./brite-body.scad>
include <./body-hose.scad>
include <./body-hose-clamps.scad>
segmentNumber=0;
include <./brite-gauge.scad>
include <./brite-gauge-segment.scad>
for (i = [0 : 9]) {
    briteGaugeSegment(i);
}
include <./brite-gauge-holder.scad>
include <./fermenter-gauge.scad>
include <./fermenter-gauge-segment.scad>
for (i = [0 : 9]) {
    fermenterGaugeSegment(i);
}
include <./fermenter-gauge-holder.scad>
include <./reference-cube.scad>

scale = 1;

//body();
//spigot();
//gauge();