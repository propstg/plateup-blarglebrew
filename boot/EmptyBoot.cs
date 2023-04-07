using BlargleBrew;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace KitchenBlargleBrew.boot {

    public class EmptyBoot : CustomItem {

        public override Appliance DedicatedProvider => Refs.EmptyBootProvider;
        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("BeerBootEmpty");
        public override string ColourBlindTag => "";
        public override string UniqueNameID => "BlargleBrew - Empty Boot";

        public override void OnRegister(Item item) {
            MaterialUtils.ApplyMaterial(Prefab, "glass", CommonMaterials.Mug.glass);
        }
    }
}