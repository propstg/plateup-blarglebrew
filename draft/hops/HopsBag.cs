﻿using BlargleBrew;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace KitchenBlargleBrew.draft.hops {

    public class HopsBag : CustomItem {

        public override string UniqueNameID => "HopsBag";
        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("Hops");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.None;
        public override string ColourBlindTag => "H";
        public override Appliance DedicatedProvider => Refs.HopsBagProvider;

        public override void OnRegister(Item item) {
            MaterialUtils.ApplyMaterial(Prefab, "bag", CommonMaterials.Hops.bag);
            MaterialUtils.ApplyMaterial(Prefab, "hops", CommonMaterials.Hops.hops);
        }
    }
}