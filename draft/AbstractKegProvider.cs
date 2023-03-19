using KitchenBlargleBrew;
using KitchenBlargleBrew.kegerator;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace BlargleBrew.draft {

    public abstract class AbstractKegProvider<T> : CustomAppliance {

        protected abstract string name { get; }
        protected abstract Material[] labelMaterial { get; }
        protected abstract string prefabName { get; }

        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>(prefabName);

        public override PriceTier PriceTier => PriceTier.Medium;
        public override ShoppingTags ShoppingTags => ShoppingTags.Cooking | ShoppingTags.Misc;
        public override bool IsPurchasable => true;
        public override bool SellOnlyAsDuplicate => true;
        public override string UniqueNameID => $"BlargleBrew - Keg {name}";

        public override List<IApplianceProperty> Properties { get {
                var itemProvider = KitchenPropertiesUtils.GetUnlimitedCItemProvider(GDOUtils.GetCustomGameDataObject<T>().GameDataObject.ID);
                itemProvider.PreventReturns = true;
                
                return new List<IApplianceProperty> { itemProvider, new CKegProvider() };
            }
        }

        public override List<(Locale, ApplianceInfo)> InfoList => new List<(Locale, ApplianceInfo)> {
            (Locale.English, new ApplianceInfo() {
                Name = $"Keg {name}",
                Description = $"Provides {name} keg"
            })
        };

        public override void OnRegister(Appliance gdo) {
            MaterialUtils.ApplyMaterial(Prefab, "kegs", CommonMaterials.Keg.metal);
            MaterialUtils.ApplyMaterial(Prefab, "labels", labelMaterial);
            MaterialUtils.ApplyMaterial(Prefab, "rack", CommonMaterials.Keg.rack);
        }
    }
}