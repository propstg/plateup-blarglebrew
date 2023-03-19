using BlargleBrew;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace KitchenBlargleBrew {

    public class BeerBottleEmpty : CustomItem {

        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("BeerBottleEmpty");
        public override string ColourBlindTag => "";
        public override string UniqueNameID => "BlargleBrew - Beer Bottle Empty";

        public override void OnRegister(Item gdo) {
            MaterialUtils.ApplyMaterial(Prefab, "glass", CommonMaterials.Bottle.glass);
        }
    }
}