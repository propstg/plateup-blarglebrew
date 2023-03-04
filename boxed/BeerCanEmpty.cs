using BlargleBrew;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace KitchenBlargleBrew {

    public class BeerCanEmpty : CustomItem {

        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("BeerCanCrushed");
        public override string ColourBlindTag => "";
        public override string UniqueNameID => "BlargleBrew - Beer Can Empty";

        public override void OnRegister(GameDataObject gdo) {
            MaterialUtils.ApplyMaterial(Prefab, "metal", CommonMaterials.Can.metal);
            MaterialUtils.ApplyMaterial(Prefab, "painted", CommonMaterials.Can.paint);
        }
    }
}