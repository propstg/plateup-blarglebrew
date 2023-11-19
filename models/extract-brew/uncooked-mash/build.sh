rm -rf stl
mkdir stl
echo "pot"
"C:\Program Files\OpenSCAD\openscad.exe" -o stl/pot.stl -D scale=0.01 --render ../pot.scad
echo "liquid"
"C:\Program Files\OpenSCAD\openscad.exe" -o stl/liquid.stl -D scale=0.01 -D liquid_height=66 --render ../liquid.scad

echo "grain-bag"
"C:\Program Files\OpenSCAD\openscad.exe" -o stl/grain-bag.stl -D scale=0.01 --render ../grain-bag.scad
echo "grain-bag-contents"
"C:\Program Files\OpenSCAD\openscad.exe" -o stl/grain-bag-contents.stl -D scale=0.01 --render ../grain-bag-contents.scad
echo "grain-bag-clip"
"C:\Program Files\OpenSCAD\openscad.exe" -o stl/grain-bag-clip.stl -D scale=0.01 --render ../grain-bag-clip.scad

echo "hops-bag"
"C:\Program Files\OpenSCAD\openscad.exe" -o stl/bag.stl -D scale=0.01 --render ../bag.scad
echo "hops-bag-contents"
"C:\Program Files\OpenSCAD\openscad.exe" -o stl/bag-contents.stl -D scale=0.01 --render ../bag-contents.scad
echo "hops-clip"
"C:\Program Files\OpenSCAD\openscad.exe" -o stl/bag-clip.stl -D scale=0.01 --render ../bag-clip.scad
