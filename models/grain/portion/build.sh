rm -rf stl
mkdir stl
echo "pile"
"C:\Program Files\OpenSCAD\openscad.exe" -o stl/pile.stl -D scale=0.015 --render pile.scad
