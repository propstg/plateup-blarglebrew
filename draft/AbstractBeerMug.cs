using KitchenBlargleBrew;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace BlargleBrew.draft {

    public abstract class AbstractBeerMug : CustomItem {

        protected abstract string beerMaterial { get; }
        protected abstract string foamMaterial { get; }
        protected abstract string name { get; }
        protected abstract string prefabName { get; }

        public override Appliance DedicatedProvider => Refs.Kegerator;
        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>(prefabName);
        public override string UniqueNameID => $"BlargleBrew - Mug {name}";

        public override void OnRegister(GameDataObject gdo) {
            MaterialUtils.ApplyMaterial(Prefab, "glass", new Material[] { MaterialUtils.GetExistingMaterial("BobaCup") });
            MaterialUtils.ApplyMaterial(Prefab, "beer", new Material[] { MaterialUtils.GetExistingMaterial(beerMaterial) });
            MaterialUtils.ApplyMaterial(Prefab, "foam", new Material[] { MaterialUtils.GetExistingMaterial(foamMaterial) });
        }
    }
}