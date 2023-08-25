rm -rf stl
mkdir stl
"C:\Program Files\OpenSCAD\openscad.exe" -o stl/body.stl -D scale=0.01 --render body.scad
"C:\Program Files\OpenSCAD\openscad.exe" -o stl/label.stl -D scale=0.01 --render label.scad
"C:\Program Files\OpenSCAD\openscad.exe" -o stl/lid.stl -D scale=0.01 --render lid.scad
"C:\Program Files\OpenSCAD\openscad.exe" -o stl/extract.stl -D scale=0.01 --render extract.scad
