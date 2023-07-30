using KitchenBlargleBrew;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace BlargleBrew.tequila {

    public class TequilaBottle : CustomItem {

        public override string UniqueNameID => "BlargleBrew - Tequila";
        public override bool IsIndisposable => true;
        public override Item SplitSubItem => Refs.TequilaShot;
        public override float SplitSpeed => 1;
        public override int SplitCount => 999;
        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("TequilaBottle");
        public override string ColourBlindTag => "Te";

        public override void OnRegister(Item item) {
            MaterialUtils.ApplyMaterial(Prefab, "bottle", CommonMaterials.Tequila.glass);
            MaterialUtils.ApplyMaterial(Prefab, "liquid", CommonMaterials.Tequila.liquid);
            MaterialUtils.ApplyMaterial(Prefab, "lid", CommonMaterials.Tequila.lid);
            MaterialUtils.ApplyMaterial(Prefab, "logo", CommonMaterials.Tequila.logo);
            Prefab.transform.Find("Colour Blind").transform.localPosition = new Vector3(0, 0.6f, 0);
        }
    }
}
