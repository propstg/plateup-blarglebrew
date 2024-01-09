import bpy,os
for f in os.listdir(".\\stl"):
    bpy.ops.import_mesh.stl(filepath = ".\\stl\\" + f)

bpy.ops.export_scene.fbx(filepath = os.environ["FBX_NAME"], object_types = {"MESH"})
