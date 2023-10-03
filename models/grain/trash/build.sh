rm -rf stl
mkdir stl
"C:\Program Files\OpenSCAD\openscad.exe" -o stl/body.stl -D scale=0.01 --render body.scad
