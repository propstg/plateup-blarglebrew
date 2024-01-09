rm -rf stl
mkdir stl

"C:\Program Files\OpenSCAD\openscad.exe" -o stl/bottle.stl -D scale=0.0075 --render bottle.scad
"C:\Program Files\OpenSCAD\openscad.exe" -o stl/lid.stl -D scale=0.0075 --render bottle-lid.scad
"C:\Program Files\OpenSCAD\openscad.exe" -o stl/logo.stl -D scale=0.0075 --render logo.scad
"C:\Program Files\OpenSCAD\openscad.exe" -o stl/liquid.stl -D scale=0.0075 --render liquid.scad

FBX_NAME=".\tequila-bottle.fbx" /c/Program\ Files/Blender\ Foundation/Blender\ 3.1/blender.exe --background --python ../blend.py
