rm -rf stl
mkdir stl
echo "pot"
"C:\Program Files\OpenSCAD\openscad.exe" -o stl/pot.stl -D scale=0.01 --render ../pot.scad
echo "liquid"
"C:\Program Files\OpenSCAD\openscad.exe" -o stl/liquid.stl -D scale=0.01 --render ../liquid.scad
echo "foam"
"C:\Program Files\OpenSCAD\openscad.exe" -o stl/foam.stl -D scale=0.01 --render ../medium-foam.scad
echo "bag"
"C:\Program Files\OpenSCAD\openscad.exe" -o stl/bag.stl -D scale=0.01 --render ../bag.scad
echo "bag-contents"
"C:\Program Files\OpenSCAD\openscad.exe" -o stl/bag-contents.stl -D scale=0.01 --render ../bag-contents.scad
echo "bag-clip"
"C:\Program Files\OpenSCAD\openscad.exe" -o stl/bag-clip.stl -D scale=0.01 --render ../bag-clip.scad
