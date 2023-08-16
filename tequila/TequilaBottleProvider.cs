using ApplianceLib.Api.Prefab;
using Kitchen;
using KitchenBlargleBrew;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace BlargleBrew.tequila {

    class TequilaBottleProvider : CustomAppliance {
        public override string UniqueNameID => "BlargleBrew - Tequila Bottle Provider";
        public override PriceTier PriceTier => PriceTier.Medium;
        public override bool SellOnlyAsDuplicate => true;
        public override bool IsPurchasable => true;
        public override ShoppingTags ShoppingTags => ShoppingTags.Cooking | ShoppingTags.Misc;
        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("TequilaBottleProvider");
        public override List<(Locale, ApplianceInfo)> InfoList => new List<(Locale, ApplianceInfo)> {
            (Locale.English, new ApplianceInfo() {
                Name = "Tequila",
                Description = "Provides tequila"
            })
        };
        public override List<IApplianceProperty> Properties => new List<IApplianceProperty> {
            new CItemHolder(),
            KitchenPropertiesUtils.GetCItemProvider(Refs.Tequila.ID, 1, 1, false, false, true, false, false, true, false)
        };

        public override void SetupPrefab(GameObject prefab) {
            prefab.AttachCounter(CounterType.DoubleDoors);
            var holdTransform = prefab.GetChild("HoldPoint").transform;

            prefab.ApplyMaterialToChild("HoldPoint/Bottle/bottle", CommonMaterials.glass);
            prefab.ApplyMaterialToChild("HoldPoint/Bottle/lid", CommonMaterials.cardboard);
            prefab.ApplyMaterialToChild("HoldPoint/Bottle/liquid", CommonMaterials.cardboard);
            prefab.ApplyMaterialToChild("HoldPoint/Bottle/logo", CommonMaterials.cardboard);

            var holdPoint = prefab.AddComponent<HoldPointContainer>();
            holdPoint.HoldPoint = holdTransform;
            var sourceView = prefab.AddComponent<LimitedItemSourceView>();
            sourceView.HeldItemPosition = holdTransform;
            ReflectionUtils.GetField<LimitedItemSourceView>("Items").SetValue(sourceView, new List<GameObject>() {
                GameObjectUtils.GetChildObject(prefab, "HoldPoint/Bottle")
            });
        }
    }
}
