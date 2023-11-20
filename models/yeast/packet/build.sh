rm -rf stl
mkdir stl
"C:\Program Files\OpenSCAD\openscad.exe" -o stl/label.stl -D scale=0.025 --render label.scad
"C:\Program Files\OpenSCAD\openscad.exe" -o stl/yeast.stl -D scale=0.025 --render yeast.scad
