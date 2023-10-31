using BlargleBrew;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace KitchenBlargleBrew.draft.pumpkin {

    public class PumpkinExtractCanOpen : CustomItem {

        public override string UniqueNameID => "PumpkinExtractCanOpen";
        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("PumpkinExtractOpen");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.None;
        public override string ColourBlindTag => "Pe";

        public override void OnRegister(Item item) {
            MaterialUtils.ApplyMaterial(Prefab, "body", CommonMaterials.PumpkinBrew.glass);
            MaterialUtils.ApplyMaterial(Prefab, "extract", CommonMaterials.PumpkinBrew.pumpkinExtractUndiluted);
            MaterialUtils.ApplyMaterial(Prefab, "label", CommonMaterials.PumpkinBrew.label);
        }
    }
}