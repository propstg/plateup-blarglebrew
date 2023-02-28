using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace KitchenBlargleBrew {

    public class BeerLight : CustomItem {

        public override Appliance DedicatedProvider => Refs.Kegerator;
        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("BeerLight");
        public override string ColourBlindTag => "";
        public override string UniqueNameID => "BlargleBrew - Light Mug";

        public override void OnRegister(GameDataObject gdo) {
            var glass = MaterialUtils.GetExistingMaterial("BobaCup");
            var beer = MaterialUtils.GetExistingMaterial("Paper - Postit Yellow");
            var foam = MaterialUtils.GetExistingMaterial("Uncooked Batter");
            MaterialUtils.ApplyMaterial(Prefab, "glass", new Material[] { glass });
            MaterialUtils.ApplyMaterial(Prefab, "beer", new Material[] { beer });
            MaterialUtils.ApplyMaterial(Prefab, "foam", new Material[] { foam });
        }
    }
}