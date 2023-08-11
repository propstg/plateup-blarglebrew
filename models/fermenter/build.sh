"C:\Program Files\OpenSCAD\openscad.exe" -o stl/body.stl -D scale=0.01 --render body.scad
"C:\Program Files\OpenSCAD\openscad.exe" -o stl/gauge.stl -D scale=0.01 --render gauge.scad
"C:\Program Files\OpenSCAD\openscad.exe" -o stl/spigot.stl -D scale=0.01 --render spigot.scad
"C:\Program Files\OpenSCAD\openscad.exe" -o stl/brite-body.stl -D scale=0.01 --render brite-body.scad
"C:\Program Files\OpenSCAD\openscad.exe" -o stl/body-hose.stl -D scale=0.01 --render body-hose.scad
"C:\Program Files\OpenSCAD\openscad.exe" -o stl/body-hose-clamps.stl -D scale=0.01 --render body-hose-clamps.scad
"C:\Program Files\OpenSCAD\openscad.exe" -o stl/brite-gauge.stl -D scale=0.01 --render brite-gauge.scad
"C:\Program Files\OpenSCAD\openscad.exe" -o stl/brite-gauge-holder.stl -D scale=0.01 --render brite-gauge-holder.scad
for i in {1..10}; do
	"C:\Program Files\OpenSCAD\openscad.exe" -o stl/brite-gauge-segment-$i.stl -D scale=0.01 -D segmentNumber=$i --render brite-gauge-segment.scad
done
"C:\Program Files\OpenSCAD\openscad.exe" -o stl/fermenter-gauge.stl -D scale=0.01 --render fermenter-gauge.scad
"C:\Program Files\OpenSCAD\openscad.exe" -o stl/fermenter-gauge-holder.stl -D scale=0.01 --render fermenter-gauge-holder.scad
for i in {1..10}; do
	"C:\Program Files\OpenSCAD\openscad.exe" -o stl/fermenter-gauge-segment-$i.stl -D scale=0.01 -D segmentNumber=$i --render fermenter-gauge-segment.scad
done

