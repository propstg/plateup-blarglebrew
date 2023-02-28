using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenBlargleBrew {

    public class KegIpa : CustomItem {

        public override Appliance DedicatedProvider => Refs.KegIpaProvider;
        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("Keg");
        public override string ColourBlindTag => "";
        public override string UniqueNameID => "BlargleBrew - IPA Keg";
        public override bool AllowSplitMerging => false;
        public override float SplitSpeed => 1f;
        public override int SplitCount => 3;
        public override Item SplitSubItem => Refs.BeerIpa;
        public override List<Item> SplitDepletedItems => new List<Item>() { Refs.EmptyKeg };
        public override Item DisposesTo => Refs.EmptyKeg;
        //public override bool PreventExplicitSplit => true;

        /*
        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess> {
            new Item.ItemProcess {
                Duration = 1f,
                IsBad = false,
                Process = (Process)GDOUtils.GetExistingGDO(ProcessReferences.Chop),
                Result = Refs.Keg
            }
        };
        */

        public override void OnRegister(GameDataObject gdo) {
            var metalBlack = MaterialUtils.GetExistingMaterial("Metal Black");
            var metalShiny = MaterialUtils.GetExistingMaterial("Metal- Shiny");
            MaterialUtils.ApplyMaterial(Prefab, "keg", new Material[] { metalShiny });
            MaterialUtils.ApplyMaterial(Prefab, "label", new Material[] { metalBlack });
        }

        public override List<IItemProperty> Properties => new List<IItemProperty>() {
        };
    }

    public class EmptyKeg : CustomItem {

        public override Appliance DedicatedProvider => Refs.KegIpaProvider;
        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("KegEmpty");
        public override string ColourBlindTag => "";
        public override string UniqueNameID => "BlargleBrew - EMPTY Keg";

        /*
        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess> {
            new Item.ItemProcess {
                Duration = 1f,
                IsBad = false,
                Process = (Process)GDOUtils.GetExistingGDO(ProcessReferences.por),
                Result = Refs.Keg
            }
        };
        */

        public override void OnRegister(GameDataObject gdo) {
            var metalBlack = MaterialUtils.GetExistingMaterial("Metal - Dirty");
            MaterialUtils.ApplyMaterial(Prefab, "keg", new Material[] { metalBlack });
        }
    }
}