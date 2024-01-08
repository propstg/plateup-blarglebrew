rm -rf stl
mkdir stl
echo "pile"
"C:\Program Files\OpenSCAD\openscad.exe" -o stl/Wheat.stl -D scale=0.015 --render pile.scad
echo "bag"
"C:\Program Files\OpenSCAD\openscad.exe" -o stl/Collider.stl -D scale=0.01 --render flour-bag.scad

FBX_NAME="..\GrainPileProvider.fbx" /c/Program\ Files/Blender\ Foundation/Blender\ 3.1/blender.exe --background --python ../../blend.py
