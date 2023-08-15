using KitchenBlargleBrew;
using KitchenBlargleBrew.kegerator;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace BlargleBrew.draft {

    public class CleanEmptyKeg : CustomItem {

        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("KegEmptyClean");
        public override string ColourBlindTag => "";
        public override string UniqueNameID => "BlargleBrew - Clean EMPTY Keg";
        public override List<IItemProperty> Properties => new List<IItemProperty>() {
            new CKegColor { colorId = 0 },
            new CKeg { },
            new CCleanEmptyKeg{ },
        };

        public override void OnRegister(Item item) {
            MaterialUtils.ApplyMaterial(Prefab, "keg", CommonMaterials.Keg.metal);
        }

        public override Appliance DedicatedProvider => Refs.KegEmptyProvider;
    }
}