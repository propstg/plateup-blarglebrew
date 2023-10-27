rm -rf stl
mkdir stl
"C:\Program Files\OpenSCAD\openscad.exe" -o stl/mug.stl -D scale=0.01 --render mug.scad
"C:\Program Files\OpenSCAD\openscad.exe" -o stl/liquid.stl -D scale=0.01 --render liquid.scad
"C:\Program Files\OpenSCAD\openscad.exe" -o stl/face.stl -D scale=0.01 --render face.scad
