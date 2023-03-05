using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace KitchenBlargleBrew {
    public class EmptyMug : CustomItem {

        public override Appliance DedicatedProvider => Refs.KegStoutProvider;
        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("empty mug");
        public override string ColourBlindTag => "";
        public override string UniqueNameID => "BlargleBrew - Empty Mug";

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
            MaterialUtils.ApplyMaterial(Prefab, "glass", new Material[] { glass });
        }
    }
}