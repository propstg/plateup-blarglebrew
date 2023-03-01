using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenBlargleBrew {

    public class BeerCanClosed : CustomItem {

        public override Appliance DedicatedProvider => Refs.BeerCanProvider;
        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("BeerCanClosed");
        public override string ColourBlindTag => "";
        public override string UniqueNameID => "BlargleBrew - Beer Can Closed";

        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess> {
            new Item.ItemProcess {
                Duration = 0.5f,
                IsBad = false,
                Process = (Process)GDOUtils.GetExistingGDO(ProcessReferences.Chop),
                Result = Refs.BeerCanOpen
            }
        };

        public override void OnRegister(GameDataObject gdo) {
            var metal = MaterialUtils.GetExistingMaterial("Metal- Shiny");
            var paint = MaterialUtils.GetExistingMaterial("Metal- Shiny Blue");
            MaterialUtils.ApplyMaterial(Prefab, "metal", new Material[] { metal });
            MaterialUtils.ApplyMaterial(Prefab, "painted", new Material[] { paint });
            Prefab.transform.localScale = new Vector3(2, 2, 2);
        }
    }
}