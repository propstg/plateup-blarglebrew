using BlargleBrew;
using KitchenData;
using KitchenLib.Colorblind;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenBlargleBrew.draft.pumpkin {

    public class PumpkinBoiled : CustomItem {

        public override string UniqueNameID => "PumpkinBoiled";
        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("PumpkinBoiled");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemValue ItemValue => ItemValue.None;
        public override Item DisposesTo => Refs.Pot;

        public override void OnRegister(Item item) {
            MaterialUtils.ApplyMaterial(Prefab, "pot", CommonMaterials.PumpkinBrew.pot);
            MaterialUtils.ApplyMaterial(Prefab, "liquid", CommonMaterials.PumpkinBrew.pumpkinExtractDiluted);
            MaterialUtils.ApplyMaterial(Prefab, "foam", CommonMaterials.PumpkinBrew.foam);

            GameObject clonedColourBlind = ColorblindUtils.cloneColourBlindObjectAndAddToItem(item);
            clonedColourBlind.transform.localPosition = new Vector3(0, 0.8f, 0);
            ColorblindUtils.getTextMeshProFromClonedObject(clonedColourBlind).text = "PePH";
        }

        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess> {
            AutomaticItemProcess
        };

        public override Item.ItemProcess AutomaticItemProcess => new Item.ItemProcess {
            Result = Refs.PumpkinCooled,
            Process = Refs.SteepProcess,
            Duration = 10f,
        };
    }
}