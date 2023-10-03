﻿using BlargleBrew;
using KitchenData;
using KitchenLib.Colorblind;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenBlargleBrew.draft.allgrain {

    public class WheatMashWithTrash : CustomItem {

        public override string UniqueNameID => "WheatMashWithTrash";
        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("MashHeatedWithTrash");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.None;
        public override ItemValue ItemValue => ItemValue.None;

        public override float SplitSpeed => 5f;
        public override int SplitCount => 1;
        public override Item DisposesTo => Refs.Pot;
        public override List<Item> SplitDepletedItems => new List<Item>() { Refs.WheatHeated };
        public override Item SplitSubItem => Refs.WheatGrainEmptyBag;
        public override bool AllowSplitMerging => false;

        public override void OnRegister(Item item) {
            MaterialUtils.ApplyMaterial(Prefab, "pot", CommonMaterials.WheatBrew.pot);
            MaterialUtils.ApplyMaterial(Prefab, "liquid", CommonMaterials.WheatBrew.wheatBrew);
            MaterialUtils.ApplyMaterial(Prefab, "foam", CommonMaterials.WheatBrew.foam);
            MaterialUtils.ApplyMaterial(Prefab, "bag/contents", CommonMaterials.Keg.wheatLabel);
            MaterialUtils.ApplyMaterial(Prefab, "bag/clip", CommonMaterials.Keg.wheatLabel);
            MaterialUtils.ApplyMaterial(Prefab, "bag/bag", CommonMaterials.Hops.bag);

            GameObject clonedColourBlind = ColorblindUtils.cloneColourBlindObjectAndAddToItem(item);
            clonedColourBlind.transform.localPosition = new Vector3(0, 0.8f, 0);
            ColorblindUtils.getTextMeshProFromClonedObject(clonedColourBlind).text = "Wh";
        }
    }
}