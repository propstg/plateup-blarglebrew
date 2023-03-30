using BlargleBrew;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace KitchenBlargleBrew.boot {

    public class EmptyBoot : CustomItem {

        //public override Appliance DedicatedProvider => Refs.EmptyBootProvider;
        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("BeerBootEmpty");
        public override string ColourBlindTag => "";
        public override string UniqueNameID => "BlargleBrew - Empty Boot";

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

        public override void OnRegister(Item item) {
            MaterialUtils.ApplyMaterial(Prefab, "glass", CommonMaterials.Mug.glass);
        }
    }
}