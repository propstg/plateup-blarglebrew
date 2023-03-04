using KitchenBlargleBrew;
using KitchenBlargleBrew.kegerator;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace BlargleBrew.draft {

    public class EmptyKeg : CustomItem {

        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("KegEmpty");
        public override string ColourBlindTag => "";
        public override string UniqueNameID => "BlargleBrew - EMPTY Keg";
        public override List<IItemProperty> Properties => new List<IItemProperty>() {
            new CKegColor { colorId = 0 }
        };

        public override void OnRegister(GameDataObject gdo) {
            MaterialUtils.ApplyMaterial(Prefab, "keg", CommonMaterials.Keg.dirty);
        }
    }
}