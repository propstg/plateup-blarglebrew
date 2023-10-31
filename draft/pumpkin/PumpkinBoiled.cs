﻿using BlargleBrew;
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

        // TODO materials
        public override void OnRegister(Item item) {
            MaterialUtils.ApplyMaterial(Prefab, "pot", CommonMaterials.WheatBrew.pot);
            MaterialUtils.ApplyMaterial(Prefab, "liquid", CommonMaterials.WheatBrew.wheatBrew);
            MaterialUtils.ApplyMaterial(Prefab, "foam", CommonMaterials.WheatBrew.foam);

            GameObject clonedColourBlind = ColorblindUtils.cloneColourBlindObjectAndAddToItem(item);
            clonedColourBlind.transform.localPosition = new Vector3(0, 0.8f, 0);
            ColorblindUtils.getTextMeshProFromClonedObject(clonedColourBlind).text = "PEH";
        }

        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess> {
            new Item.ItemProcess {
                Duration = 10f,
                IsBad = false,
                Process = Refs.CoolProcess,
                Result = Refs.PumpkinCooled,
            }
        };
    }
}