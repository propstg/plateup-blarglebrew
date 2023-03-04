using BlargleBrew;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace KitchenBlargleBrew {

    public class BeerBottleOpen : CustomItem {

        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("BeerBottleOpen");
        public override string ColourBlindTag => "Pil";
        public override string UniqueNameID => "BlargleBrew - Beer Bottle Open";
        public override Item DirtiesTo => Refs.BeerBottleEmpty;

        public override void OnRegister(GameDataObject gdo) {
            MaterialUtils.ApplyMaterial(Prefab, "glass", CommonMaterials.Bottle.glass);
            MaterialUtils.ApplyMaterial(Prefab, "liquid", CommonMaterials.Bottle.liquid);
        }
    }
}