rm -rf stl
mkdir stl
"C:\Program Files\OpenSCAD\openscad.exe" -o stl/keg.stl -D scale=0.01 --render keg.scad
"C:\Program Files\OpenSCAD\openscad.exe" -o stl/face.stl -D scale=0.01 --render face.scad
