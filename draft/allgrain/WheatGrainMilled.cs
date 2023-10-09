using BlargleBrew;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace KitchenBlargleBrew.draft.allgrain {

    public class WheatGrainMilled : CustomItem {

        public override string UniqueNameID => "WheatGrainMilled";
        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("GrainBag");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemValue ItemValue => ItemValue.None;
        public override string ColourBlindTag => "Wh";

        public override void OnRegister(Item item) {
            MaterialUtils.ApplyMaterial(Prefab, "body", CommonMaterials.Hops.bag);
            MaterialUtils.ApplyMaterial(Prefab, "wheat", CommonMaterials.wheat);
        }
    }
}