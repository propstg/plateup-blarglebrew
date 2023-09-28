using BlargleBrew;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace KitchenBlargleBrew.draft.hops {

    public class HopsBagEmpty : CustomItem {

        public override string UniqueNameID => "HopsBagEmpty";
        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("HopsEmpty");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemValue ItemValue => ItemValue.None;

        public override void OnRegister(Item item) {
            MaterialUtils.ApplyMaterial(Prefab, "bag", CommonMaterials.Hops.bag);
        }
    }
}