rm -rf stl
mkdir stl
"C:\Program Files\OpenSCAD\openscad.exe" -o stl/coil.stl -D scale=0.01 --render coil.scad
"C:\Program Files\OpenSCAD\openscad.exe" -o stl/mast.stl -D scale=0.01 --render mast.scad
