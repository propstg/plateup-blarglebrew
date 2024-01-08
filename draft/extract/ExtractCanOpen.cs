using BlargleBrew;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace KitchenBlargleBrew.draft.extract {

    public class ExtractCanOpen : CustomItem {

        public override string UniqueNameID => "ExtractCanOpen";
        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("ExtractOpen");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.None;
        public override string ColourBlindTag => "Ex";
        public override Appliance DedicatedProvider => Refs.ExtractCanProvider;

        public override void OnRegister(Item item) {
            MaterialUtils.ApplyMaterial(Prefab, "body", CommonMaterials.ExtractStout.glass);
            MaterialUtils.ApplyMaterial(Prefab, "extract", CommonMaterials.ExtractStout.extractUndiluted);
            MaterialUtils.ApplyMaterial(Prefab, "label", CommonMaterials.ExtractStout.label);
        }
    }
}