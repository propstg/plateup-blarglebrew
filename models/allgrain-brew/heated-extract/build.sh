rm -rf stl
mkdir stl
"C:\Program Files\OpenSCAD\openscad.exe" -o stl/pot.stl -D scale=0.01 --render ../pot.scad
"C:\Program Files\OpenSCAD\openscad.exe" -o stl/foam.stl -D scale=0.01 --render ../full-foam.scad
