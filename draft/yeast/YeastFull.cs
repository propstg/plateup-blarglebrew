using BlargleBrew;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace KitchenBlargleBrew.draft.yeast {

    public class YeastFull : CustomItem {

        public override string UniqueNameID => "YeastFull";
        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("YeastPacket");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.None;
        public override Appliance DedicatedProvider => Refs.YeastProvider;

        public override void OnRegister(Item item) {
            MaterialUtils.ApplyMaterial(Prefab, "yeast", CommonMaterials.metalShinyBlue);
            MaterialUtils.ApplyMaterial(Prefab, "label", CommonMaterials.metalBlack);
        }
    }
}