using KitchenBlargleBrew;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace BlargleBrew.draft {

    public abstract class AbstractBeerMug : CustomItem {

        protected abstract Material[] beerMaterial { get; }
        protected abstract Material[] foamMaterial { get; }
        protected abstract string name { get; }
        protected abstract string prefabName { get; }

        public override Appliance DedicatedProvider => Refs.Kegerator;
        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>(prefabName);
        public override string UniqueNameID => $"BlargleBrew - Mug {name}";

        public override void OnRegister(GameDataObject gdo) {
            MaterialUtils.ApplyMaterial(Prefab, "glass", CommonMaterials.Mug.glass);
            MaterialUtils.ApplyMaterial(Prefab, "beer", beerMaterial);
            MaterialUtils.ApplyMaterial(Prefab, "foam", foamMaterial);
        }
    }
}