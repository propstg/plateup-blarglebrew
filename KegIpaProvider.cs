using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenBlargleBrew {

    public class KegIpaProvider : CustomAppliance {

        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("KegRackIpa");
        public override PriceTier PriceTier => PriceTier.Medium;
        public override ShoppingTags ShoppingTags => ShoppingTags.Cooking | ShoppingTags.Misc;
        public override bool IsPurchasable => true;
        public override bool SellOnlyAsDuplicate => true;
        public override string UniqueNameID => "BlargleBrew - Keg IPA";

        public override void OnRegister(GameDataObject gdo) {
            var metalVeryDark = MaterialUtils.GetExistingMaterial("Metal Very Dark");
            var metalBlack = MaterialUtils.GetExistingMaterial("Metal Black");
            var metalShiny = MaterialUtils.GetExistingMaterial("Metal- Shiny");
            MaterialUtils.ApplyMaterial(Prefab, "kegs", new Material[] { metalShiny });
            MaterialUtils.ApplyMaterial(Prefab, "labels", new Material[] { metalBlack });
            MaterialUtils.ApplyMaterial(Prefab, "rack", new Material[] { metalVeryDark });
        }

        public override List<IApplianceProperty> Properties => new List<IApplianceProperty> {
            KitchenPropertiesUtils.GetUnlimitedCItemProvider(GDOUtils.GetCustomGameDataObject<KegIpa>().GameDataObject.ID)
        };

        public override List<(Locale, ApplianceInfo)> InfoList => new List<(Locale, ApplianceInfo)> {
            (Locale.English, new ApplianceInfo() {
                Name = "Keg IPA",
                Description = "Provides keg"
            })
        };
    }

    public class KegLightProvider : CustomAppliance {

        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("KegRackLight");
        public override PriceTier PriceTier => PriceTier.Medium;
        public override ShoppingTags ShoppingTags => ShoppingTags.Cooking | ShoppingTags.Misc;
        public override bool IsPurchasable => true;
        public override bool SellOnlyAsDuplicate => true;
        public override string UniqueNameID => "BlargleBrew - Keg Light";

        public override void OnRegister(GameDataObject gdo) {
            var metalBlack = MaterialUtils.GetExistingMaterial("Metal Very Dark");
            var metalShiny = MaterialUtils.GetExistingMaterial("Metal- Shiny");
            var label = MaterialUtils.GetExistingMaterial("Paper - Postit Yellow");
            MaterialUtils.ApplyMaterial(Prefab, "kegs", new Material[] { metalShiny });
            MaterialUtils.ApplyMaterial(Prefab, "labels", new Material[] { label });
            MaterialUtils.ApplyMaterial(Prefab, "rack", new Material[] { metalBlack });
        }

        public override List<IApplianceProperty> Properties => new List<IApplianceProperty> {
            KitchenPropertiesUtils.GetUnlimitedCItemProvider(GDOUtils.GetCustomGameDataObject<KegLight>().GameDataObject.ID)
        };

        public override List<(Locale, ApplianceInfo)> InfoList => new List<(Locale, ApplianceInfo)> {
            (Locale.English, new ApplianceInfo() {
                Name = "Keg Light",
                Description = "Provides keg"
            })
        };
    }
}