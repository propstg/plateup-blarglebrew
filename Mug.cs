using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace KitchenBlargleBrew {
    public class Mug : CustomItem {

        public override Appliance DedicatedProvider => Refs.Kegerator;
        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("mug");
        public override string ColourBlindTag => "";
        public override string UniqueNameID => "BlargleBrew - Mug";

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
            var glass = MaterialUtils.GetExistingMaterial("BobaCup");
            var beer = MaterialUtils.GetExistingMaterial("Wood - Default");
            var foam = MaterialUtils.GetExistingMaterial("Wood - Corkboard");
            MaterialUtils.ApplyMaterial(Prefab, "glass", new Material[] { glass });
            MaterialUtils.ApplyMaterial(Prefab, "beer", new Material[] { beer });
            MaterialUtils.ApplyMaterial(Prefab, "foam", new Material[] { foam });
        }
    }
}