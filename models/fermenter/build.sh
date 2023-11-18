rm -rf stl
mkdir stl
"C:\Program Files\OpenSCAD\openscad.exe" -o stl/legs.stl -D scale=0.01 --render brite-legs.scad
"C:\Program Files\OpenSCAD\openscad.exe" -o stl/brite-body.stl -D scale=0.01 --render brite-body.scad
"C:\Program Files\OpenSCAD\openscad.exe" -o stl/fermenter-body.stl -D scale=0.01 --render fermenter-body.scad
for i in {0..19}; do
	"C:\Program Files\OpenSCAD\openscad.exe" -o stl/brite-segment-$i.stl -D scale=0.01 -D zPosition=3 -D segmentNumber=$i --render brite-body-segment.scad
done
for i in {0..19}; do
	"C:\Program Files\OpenSCAD\openscad.exe" -o stl/fermenter-segment-$i.stl -D scale=0.01 -D zPosition=75 -D segmentNumber=$i --render brite-body-segment.scad
done