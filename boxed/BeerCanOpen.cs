using BlargleBrew;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace KitchenBlargleBrew {

    public class BeerCanOpen : CustomItem {

        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("BeerCanOpen");
        public override string ColourBlindTag => "Lt";
        public override string UniqueNameID => "BlargleBrew - Beer Can Open";
        public override Item DirtiesTo => Refs.BeerCanEmpty;

        public override void OnRegister(GameDataObject gdo) {
            MaterialUtils.ApplyMaterial(Prefab, "metal", CommonMaterials.Can.metal);
            MaterialUtils.ApplyMaterial(Prefab, "painted", CommonMaterials.Can.paint);
            MaterialUtils.ApplyMaterial(Prefab, "metal", CommonMaterials.Can.foam);
        }
    }
}