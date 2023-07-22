using BlargleBrew;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace KitchenBlargleBrew.michelada {

    public class TomatoJuice : CustomItem {

        public override string UniqueNameID => "TomatoJuice";
        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("TomatoJuice");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.None;
        public override string ColourBlindTag => "Tj";

        public override void OnRegister(Item item) {
            MaterialUtils.ApplyMaterial(Prefab, "glass", CommonMaterials.TomatoJuice.glass);
            MaterialUtils.ApplyMaterial(Prefab, "contents", CommonMaterials.TomatoJuice.contents);
        }
    }
}