using ApplianceLib.Api.Prefab;
using BlargleBrew;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenBlargleBrew.boot {

    public class EmptyBootProvider : CustomAppliance {

        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("BootProvider");
        public override PriceTier PriceTier => PriceTier.Medium;
        public override ShoppingTags ShoppingTags => ShoppingTags.Cooking | ShoppingTags.Misc;
        public override bool IsPurchasable => true;
        public override bool SellOnlyAsDuplicate => true;
        public override string UniqueNameID => "BlargleBrew - Empty Boot Provider";

        public override void OnRegister(Appliance gdo) {
            Prefab.AttachCounter(CounterType.Drawers);
            MaterialUtils.ApplyMaterial(Prefab, "Boot/glass", CommonMaterials.Mug.glass);
            MaterialUtils.ApplyMaterial(Prefab, "Boot2/glass", CommonMaterials.Mug.glass);
        }

        public override List<IApplianceProperty> Properties => new List<IApplianceProperty> {
            KitchenPropertiesUtils.GetUnlimitedCItemProvider(GDOUtils.GetCustomGameDataObject<EmptyBoot>().GameDataObject.ID)
        };

        public override List<(Locale, ApplianceInfo)> InfoList => new List<(Locale, ApplianceInfo)> {
            (Locale.English, new ApplianceInfo() {
                Name = "Empty boot",
                Description = "Provides empty boot"
            })
        };
    }
}