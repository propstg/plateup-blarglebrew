using KitchenBlargleBrew;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Linq;
using UnityEngine;
using UnityEngine.VFX;

namespace BlargleBrew.draft {

    public abstract class AbstractBeerMug : CustomItem {

        protected abstract Material[] beerMaterial { get; }
        protected abstract Material[] foamMaterial { get; }
        protected abstract string name { get; }
        protected abstract string prefabName { get; }

        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override Appliance DedicatedProvider => Refs.Kegerator;
        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>(prefabName);
        public override string UniqueNameID => $"BlargleBrew - Mug {name}";

        public const string VFX_NAME = "Freezer Vapour";

        public override void OnRegister(Item gdo) {
            MaterialUtils.ApplyMaterial(Prefab, "glass", CommonMaterials.Mug.glass);
            MaterialUtils.ApplyMaterial(Prefab, "beer", beerMaterial);
            MaterialUtils.ApplyMaterial(Prefab, "foam", foamMaterial);
            GameObject vfxGameObject = new GameObject($"Beer VFX - {VFX_NAME}");
            VisualEffectAsset asset = Resources.FindObjectsOfTypeAll<VisualEffectAsset>().Where(vfx => vfx.name == VFX_NAME).FirstOrDefault();
            if (asset != default) {
                VisualEffect vfx = vfxGameObject.GetComponent<VisualEffect>();
                if (vfx == null) {
                    vfx = vfxGameObject.AddComponent<VisualEffect>();
                }
                vfx.visualEffectAsset = asset;

                vfxGameObject.transform.parent = Prefab.transform;
                vfxGameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                vfxGameObject.transform.localPosition = Vector3.zero;
                vfxGameObject.transform.rotation = Quaternion.identity;
            }
        }
    }
}