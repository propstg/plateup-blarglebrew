using BlargleBrew;
using IngredientLib.Util;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenBlargleBrew.draft.extract {

    public class ExtractBoiled : CustomItem {

        public override string UniqueNameID => "ExtractBoiled";
        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("ExtractBoiled");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemValue ItemValue => ItemValue.None;
        public override string ColourBlindTag => "ExH";
        public override Item DisposesTo => Refs.Pot;

        public override void OnRegister(Item item) {
            MaterialUtils.ApplyMaterial(Prefab, "pot", CommonMaterials.ExtractStout.pot);
            MaterialUtils.ApplyMaterial(Prefab, "liquid", CommonMaterials.ExtractStout.extractDiluted);
            MaterialUtils.ApplyMaterial(Prefab, "foam", CommonMaterials.ExtractStout.foam);
            Prefab.ApplyVisualEffect("Steam");
        }

        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess> {
            AutomaticItemProcess
        };

        public override Item.ItemProcess AutomaticItemProcess => new Item.ItemProcess {
            Result = Refs.ExtractCooled,
            Process = Refs.SteepProcess,
            Duration = 10f,
        };
    }
}