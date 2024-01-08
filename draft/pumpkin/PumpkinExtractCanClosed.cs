using BlargleBrew;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenBlargleBrew.draft.pumpkin {

    public class PumpkinExtractCanClosed : CustomItem {

        public override string UniqueNameID => "PumpkinExtractCanClosed";
        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("PumpkinExtractClosed");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.None;
        public override string ColourBlindTag => "Pe";

        public override void OnRegister(Item item) {
            MaterialUtils.ApplyMaterial(Prefab, "body", CommonMaterials.PumpkinBrew.glass);
            MaterialUtils.ApplyMaterial(Prefab, "extract", CommonMaterials.PumpkinBrew.pumpkinExtractUndiluted);
            MaterialUtils.ApplyMaterial(Prefab, "label", CommonMaterials.PumpkinBrew.label);
            MaterialUtils.ApplyMaterial(Prefab, "lid", CommonMaterials.PumpkinBrew.pumpkinExtractUndiluted);
        }

        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess> {
            new Item.ItemProcess {
                Duration = 0.5f,
                IsBad = false,
                Process = Refs.ChopProcess,
                Result = Refs.PumpkinExtractCanOpen
            }
        };
    }
}