using BlargleBrew;
using KitchenBlargleBrew.kegerator;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenBlargleBrew.draft.extract {

    public class ExtractFinished : CustomItem {

        public override string UniqueNameID => "ExtractFinished";
        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("ExtractBoiled");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.None;
        public override string ColourBlindTag => "ExH";
        public override List<IItemProperty> Properties => new List<IItemProperty>() {
            new CFinishedFerment { colorId = 1 },
        };

        public override void OnRegister(Item item) {
            MaterialUtils.ApplyMaterial(Prefab, "pot", CommonMaterials.ExtractStout.pot);
            MaterialUtils.ApplyMaterial(Prefab, "liquid", CommonMaterials.ExtractStout.extractDiluted);
            MaterialUtils.ApplyMaterial(Prefab, "foam", CommonMaterials.ExtractStout.foam);
        }
    }
}