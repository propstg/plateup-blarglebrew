using KitchenBlargleBrew;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace BlargleBrew.draft {

    public class EmptyKeg : CustomItem {

        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("KegEmpty");
        public override string ColourBlindTag => "";
        public override string UniqueNameID => "BlargleBrew - EMPTY Keg";

        public override void OnRegister(GameDataObject gdo) {
            MaterialUtils.ApplyMaterial(Prefab, "keg", new Material[] { MaterialUtils.GetExistingMaterial("Metal - Dirty") });
        }
    }
}