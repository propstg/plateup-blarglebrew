using BlargleBrew;
using KitchenData;
using KitchenLib.Colorblind;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenBlargleBrew.draft.allgrain {

    public class WheatBoiled : CustomItem {

        public override string UniqueNameID => "WheatBoiled";
        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("WheatBoiled");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemValue ItemValue => ItemValue.None;
        public override Item DisposesTo => Refs.Pot;

        public override void OnRegister(Item item) {
            MaterialUtils.ApplyMaterial(Prefab, "pot", CommonMaterials.WheatBrew.pot);
            MaterialUtils.ApplyMaterial(Prefab, "liquid", CommonMaterials.WheatBrew.wheatBrew);
            MaterialUtils.ApplyMaterial(Prefab, "foam", CommonMaterials.WheatBrew.foam);

            GameObject clonedColourBlind = ColorblindUtils.cloneColourBlindObjectAndAddToItem(item);
            clonedColourBlind.transform.localPosition = new Vector3(0, 0.8f, 0);
            ColorblindUtils.getTextMeshProFromClonedObject(clonedColourBlind).text = "WhH";
        }
        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess> {
            AutomaticItemProcess
        };

        public override Item.ItemProcess AutomaticItemProcess => new Item.ItemProcess {
            Result = Refs.WheatCooled,
            Process = Refs.SteepProcess,
            Duration = 10f,
        };
    }
}