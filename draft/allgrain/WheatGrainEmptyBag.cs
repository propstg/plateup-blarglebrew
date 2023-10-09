using BlargleBrew;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace KitchenBlargleBrew.draft.allgrain {

    public class WheatGrainEmptyBag : CustomItem {

        public override string UniqueNameID => "WheatGrainTrash";
        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("GrainBagTrash");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemValue ItemValue => ItemValue.None;

        public override void OnRegister(Item item) {
            MaterialUtils.ApplyMaterial(Prefab, "bag", CommonMaterials.Hops.bag);
        }
    }
}