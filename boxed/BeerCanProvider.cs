using ApplianceLib.Api.Prefab;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace KitchenBlargleBrew {

    public class BeerCanProvider : CustomAppliance {

        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("BeerCase");
        public override PriceTier PriceTier => PriceTier.Medium;
        public override ShoppingTags ShoppingTags => ShoppingTags.Cooking | ShoppingTags.Misc;
        public override bool IsPurchasable => true;
        public override bool SellOnlyAsDuplicate => true;
        public override string UniqueNameID => "BlargleBrew - Beer Case";

        public override void OnRegister(GameDataObject gdo) {
            var snow = MaterialUtils.GetExistingMaterial("Cardboard");
            var metalShiny = MaterialUtils.GetExistingMaterial("Metal- Shiny");
            var paint = MaterialUtils.GetExistingMaterial("Metal- Shiny Blue");
            MaterialUtils.ApplyMaterial(Prefab, "box", new Material[] { snow });
            MaterialUtils.ApplyMaterial(Prefab, "metal", new Material[] { metalShiny });
            MaterialUtils.ApplyMaterial(Prefab, "painted", new Material[] { paint });
            Prefab.AttachCounter(CounterType.Drawers);
        }

        public override List<IApplianceProperty> Properties => new List<IApplianceProperty> {
            KitchenPropertiesUtils.GetUnlimitedCItemProvider(GDOUtils.GetCustomGameDataObject<BeerCanClosed>().GameDataObject.ID)
        };

        public override List<(Locale, ApplianceInfo)> InfoList => new List<(Locale, ApplianceInfo)> {
            (Locale.English, new ApplianceInfo() {
                Name = "Beer Cans",
                Description = "Provides beer cans"
            })
        };
    }

}