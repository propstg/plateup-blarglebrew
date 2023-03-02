using KitchenBlargleBrew;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace BlargleBrew.draft {

    public abstract class AbstractKegProvider<T> : CustomAppliance {

        protected abstract string name { get; }
        protected abstract string labelMaterial { get; }
        protected abstract string prefabName { get; }

        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>(prefabName);

        public override PriceTier PriceTier => PriceTier.Medium;
        public override ShoppingTags ShoppingTags => ShoppingTags.Cooking | ShoppingTags.Misc;
        public override bool IsPurchasable => true;
        public override bool SellOnlyAsDuplicate => true;
        public override string UniqueNameID => $"BlargleBrew - Keg {name}";

        public override List<IApplianceProperty> Properties => new List<IApplianceProperty> {
            KitchenPropertiesUtils.GetUnlimitedCItemProvider(GDOUtils.GetCustomGameDataObject<T>().GameDataObject.ID)
        };

        public override List<(Locale, ApplianceInfo)> InfoList => new List<(Locale, ApplianceInfo)> {
            (Locale.English, new ApplianceInfo() {
                Name = $"Keg {name}",
                Description = $"Provides {name} keg"
            })
        };

        public override void OnRegister(GameDataObject gdo) {
            var metalShiny = MaterialUtils.GetExistingMaterial("Metal- Shiny");
            var label = MaterialUtils.GetExistingMaterial(labelMaterial);
            MaterialUtils.ApplyMaterial(Prefab, "kegs", new Material[] { metalShiny });
            MaterialUtils.ApplyMaterial(Prefab, "labels", new Material[] { label });
            MaterialUtils.ApplyMaterial(Prefab, "rack", new Material[] { metalShiny });
        }
    }
}