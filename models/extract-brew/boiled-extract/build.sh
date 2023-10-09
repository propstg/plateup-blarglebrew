rm -rf stl
mkdir stl
echo "pot"
"C:\Program Files\OpenSCAD\openscad.exe" -o stl/pot.stl -D scale=0.01 --render ../pot.scad
echo "liquid"
"C:\Program Files\OpenSCAD\openscad.exe" -o stl/liquid.stl -D liquid_height=55 -D scale=0.01 --render ../liquid.scad
echo "foam"
"C:\Program Files\OpenSCAD\openscad.exe" -o stl/foam.stl -D liquid_height=55 -D scale=0.01 --render ../light-foam.scad
