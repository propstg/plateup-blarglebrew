using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace KitchenBlargleBrew {

    public class BeerCanEmpty : CustomItem {

        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("BeerCanCrushed");
        public override string ColourBlindTag => "";
        public override string UniqueNameID => "BlargleBrew - Beer Can Empty";

        public override void OnRegister(GameDataObject gdo) {
            var metal = MaterialUtils.GetExistingMaterial("Metal- Shiny");
            var paint = MaterialUtils.GetExistingMaterial("Metal- Shiny Blue");
            MaterialUtils.ApplyMaterial(Prefab, "metal", new Material[] { metal });
            MaterialUtils.ApplyMaterial(Prefab, "painted", new Material[] { paint });
            Prefab.transform.localScale = new Vector3(2, 2, 2);
        }
    }
}