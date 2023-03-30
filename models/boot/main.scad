scale = 1;

include <./boot-glass.scad>
use <./boot-liquid-1.scad>
use <./boot-liquid-2.scad>
use <./boot-liquid-3.scad>
use <./boot-liquid-4.scad>
include <./reference-cube.scad>


translate([0, 25, 0]) liquid1();
translate([0, 30, 0]) liquid2();
translate([0, 35, 0]) liquid3();
translate([0, 45, 0]) liquid4();
