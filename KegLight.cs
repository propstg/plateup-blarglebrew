using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenBlargleBrew {

    public class KegLight : CustomItem {

        public override Appliance DedicatedProvider => Refs.KegLightProvider;
        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("KegLight");
        public override string ColourBlindTag => "";
        public override string UniqueNameID => "BlargleBrew - Light Keg";
        public override bool AllowSplitMerging => false;
        public override float SplitSpeed => 1f;
        public override int SplitCount => 3;
        public override Item SplitSubItem => Refs.BeerLight;
        public override List<Item> SplitDepletedItems => new List<Item>() { Refs.EmptyKeg };
        public override Item DisposesTo => Refs.EmptyKeg;

        public override void OnRegister(GameDataObject gdo) {
            var metalShiny = MaterialUtils.GetExistingMaterial("Metal- Shiny");
            var metalBlack = MaterialUtils.GetExistingMaterial("Metal Black");
            var beer = MaterialUtils.GetExistingMaterial("Paper - Postit Yellow");

            MaterialUtils.ApplyMaterial(Prefab, "keg", new Material[] { metalShiny });
            MaterialUtils.ApplyMaterial(Prefab, "label", new Material[] { beer });
        }

        public override List<IItemProperty> Properties => new List<IItemProperty>() {
        };
    }
}