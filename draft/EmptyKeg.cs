using KitchenBlargleBrew;
using KitchenBlargleBrew.kegerator;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace BlargleBrew.draft {

    public class EmptyKeg : CustomItem {

        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("KegEmpty");
        public override string ColourBlindTag => "";
        public override string UniqueNameID => "BlargleBrew - EMPTY Keg";
        public override List<IItemProperty> Properties => new List<IItemProperty>() {
            new CKegColor { colorId = 0 },
            new CKeg { }
        };

        public override void OnRegister(Item item) {
            MaterialUtils.ApplyMaterial(Prefab, "keg", CommonMaterials.Keg.dirty);
        }

        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess> {
            new Item.ItemProcess {
                Duration = 1.0f,
                IsBad = false,
                Process = (Process)GDOUtils.GetExistingGDO(ProcessReferences.Clean),
                Result = Refs.CleanEmptyKeg
            }
        };
    }
}