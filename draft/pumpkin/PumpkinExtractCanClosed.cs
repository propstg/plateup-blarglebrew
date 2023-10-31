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
        public override Appliance DedicatedProvider => Refs.PumpkinExtractCanProvider;

        // TODO materials
        public override void OnRegister(Item item) {
            MaterialUtils.ApplyMaterial(Prefab, "body", CommonMaterials.ExtractStout.glass);
            MaterialUtils.ApplyMaterial(Prefab, "extract", CommonMaterials.ExtractStout.extractUndiluted);
            MaterialUtils.ApplyMaterial(Prefab, "label", CommonMaterials.ExtractStout.label);
            MaterialUtils.ApplyMaterial(Prefab, "lid", CommonMaterials.ExtractStout.lid);
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