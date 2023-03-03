using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace KitchenBlargleBrew {

    public class BeerCanOpen : CustomItem {

        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("BeerCanOpen");
        public override string ColourBlindTag => "Lt";
        public override string UniqueNameID => "BlargleBrew - Beer Can Open";
        public override Item DirtiesTo => Refs.BeerCanEmpty;

        public override void OnRegister(GameDataObject gdo) {
            var metal = MaterialUtils.GetExistingMaterial("Metal- Shiny");
            var paint = MaterialUtils.GetExistingMaterial("Metal- Shiny Blue");
            var foam = MaterialUtils.GetExistingMaterial("Snow");
            MaterialUtils.ApplyMaterial(Prefab, "metal", new Material[] { metal });
            MaterialUtils.ApplyMaterial(Prefab, "painted", new Material[] { paint });
            MaterialUtils.ApplyMaterial(Prefab, "foam", new Material[] { foam });
            Prefab.transform.localScale = new Vector3(2, 2, 2);
        }
    }
}