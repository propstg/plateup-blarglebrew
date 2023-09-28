using BlargleBrew;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenBlargleBrew.draft.allgrain {

    public class WheatGrainPortion : CustomItem {

        public override string UniqueNameID => "WheatGrainPortion";
        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("GrainPile");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.None;
        public override string ColourBlindTag => "Wh";

        public override void OnRegister(Item item) {
            MaterialUtils.ApplyMaterial(Prefab, "Wheat", CommonMaterials.wheat);
        }
        public override Appliance DedicatedProvider => Refs.WheatGrainProvider;

        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess> {
            new Item.ItemProcess {
                Duration = 5f,
                IsBad = false,
                Process = Refs.ChopProcess,
                Result = Refs.WheatGrainMilled
            }
        };
    }
}