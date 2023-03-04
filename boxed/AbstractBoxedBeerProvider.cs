using ApplianceLib.Api.Prefab;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenBlargleBrew {

    public abstract class AbstractBoxedBeerProvider : CustomAppliance {

        protected abstract string name { get; }
        protected abstract string prefabName { get; }
        protected abstract int provides { get; }

        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>(prefabName);
        public override PriceTier PriceTier => PriceTier.Medium;
        public override ShoppingTags ShoppingTags => ShoppingTags.Cooking | ShoppingTags.Misc;
        public override bool IsPurchasable => true;
        public override bool SellOnlyAsDuplicate => true;
        public override string UniqueNameID => $"BlargleBrew - Beer {name} Provider";

        public override void OnRegister(GameDataObject gdo) {
            Prefab.AttachCounter(CounterType.Drawers);
        }

        public override List<IApplianceProperty> Properties => new List<IApplianceProperty> {
            KitchenPropertiesUtils.GetUnlimitedCItemProvider(provides)
        };

        public override List<(Locale, ApplianceInfo)> InfoList => new List<(Locale, ApplianceInfo)> {
            (Locale.English, new ApplianceInfo() {
                Name = $"Beer {name}",
                Description = $"Provides Beer {name}s"
            })
        };
    }
}