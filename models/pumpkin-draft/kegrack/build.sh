rm -rf stl
mkdir stl
"C:\Program Files\OpenSCAD\openscad.exe" -o stl/kegs.stl -D scale=0.01 --render kegs.scad
"C:\Program Files\OpenSCAD\openscad.exe" -o stl/faces.stl -D scale=0.01 --render keg-labels.scad
"C:\Program Files\OpenSCAD\openscad.exe" -o stl/kegrack.stl -D scale=0.01 --render kegrack.scad
"C:\Program Files\OpenSCAD\openscad.exe" -o stl/keg-bands.stl -D scale=0.01 --render normal-keg-bands.scad
