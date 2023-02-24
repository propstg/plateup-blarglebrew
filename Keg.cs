using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace KitchenBlargleBrew {
    public class Keg : CustomItem {

        public override Appliance DedicatedProvider => Refs.KegProvider;
        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("Keg");
        public override string ColourBlindTag => "";
        public override string UniqueNameID => "BlargleBrew - IPA Keg";

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
            var metalBlack = MaterialUtils.GetExistingMaterial("Metal- Shiny");
            MaterialUtils.ApplyMaterial(Prefab, "keg", new Material[] { metalBlack });
        }
    }
}