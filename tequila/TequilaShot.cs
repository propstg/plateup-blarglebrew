using KitchenBlargleBrew;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace BlargleBrew.tequila {

    public class TequilaShot : CustomItem {

        public override string UniqueNameID => "BlargleBrew - Tequila Shot";
        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("TequilaShot");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.Small;
        public override string ColourBlindTag => "Te";

        public override void OnRegister(Item item) {
            MaterialUtils.ApplyMaterial(Prefab, "shotglass", CommonMaterials.Tequila.glass);
            MaterialUtils.ApplyMaterial(Prefab, "liquid", CommonMaterials.Tequila.liquid);
        }
    }
}
