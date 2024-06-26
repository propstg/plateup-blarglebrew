﻿using BlargleBrew;
using KitchenData;
using KitchenLib.Colorblind;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System;
using UnityEngine;

namespace KitchenBlargleBrew.draft.pumpkin {

    [Obsolete]
    public class PumpkinHeated : CustomItem {

        public override string UniqueNameID => "PumpkinHeated";
        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("PumpkinHeated");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemValue ItemValue => ItemValue.None;
        public override Item DisposesTo => Refs.Pot;

        public override void OnRegister(Item item) {
            MaterialUtils.ApplyMaterial(Prefab, "pot", CommonMaterials.PumpkinBrew.pot);
            MaterialUtils.ApplyMaterial(Prefab, "foam", CommonMaterials.PumpkinBrew.foam);

            GameObject clonedColourBlind = ColorblindUtils.cloneColourBlindObjectAndAddToItem(item);
            clonedColourBlind.transform.localPosition = new Vector3(0, 0.8f, 0);
            ColorblindUtils.getTextMeshProFromClonedObject(clonedColourBlind).text = "PeP";
        }
    }
}