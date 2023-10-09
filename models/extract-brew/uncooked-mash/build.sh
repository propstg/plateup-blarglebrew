rm -rf stl
mkdir stl
echo "pot"
"C:\Program Files\OpenSCAD\openscad.exe" -o stl/pot.stl -D scale=0.01 --render ../pot.scad
echo "liquid"
"C:\Program Files\OpenSCAD\openscad.exe" -o stl/liquid.stl -D scale=0.01 -D liquid_height=66 --render ../liquid.scad
echo "bag"
"C:\Program Files\OpenSCAD\openscad.exe" -o stl/grain-bag.stl -D scale=0.01 --render ../grain-bag.scad
echo "bag-contents"
"C:\Program Files\OpenSCAD\openscad.exe" -o stl/grain-bag-contents.stl -D scale=0.01 --render ../grain-bag-contents.scad
echo "bag-clip"
"C:\Program Files\OpenSCAD\openscad.exe" -o stl/bag-clip.stl -D scale=0.01 --render ../bag-clip.scad
