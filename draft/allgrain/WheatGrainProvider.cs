using ApplianceLib.Api.Prefab;
using BlargleBrew;
using KitchenBlargleBrew.draft.allgrain;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenBlargleBrew.draft.allgrain {

    public class WheatGrainProvider : CustomAppliance {

        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("GrainPileProvider");
        public override PriceTier PriceTier => PriceTier.Medium;
        public override ShoppingTags ShoppingTags => ShoppingTags.Cooking;
        public override bool IsPurchasable => true;
        public override bool SellOnlyAsDuplicate => true;
        public override string UniqueNameID => "BlargleBrew - Wheat Grain Provider";

        public override void OnRegister(Appliance gdo) {
            var flourSackPrefab = (GDOUtils.GetExistingGDO(ApplianceReferences.SourceFlour) as IHasPrefab)?.Prefab.transform.Find("FlourSack").gameObject;
            Prefab.AttachPrefabAsChild(flourSackPrefab);
            MaterialUtils.ApplyMaterial(Prefab, "Wheat", CommonMaterials.wheat);
            Prefab.transform.Find("Wheat").transform.localPosition += new Vector3(0, 0.85f, 0);
            MaterialUtils.ApplyMaterial(Prefab, "FlourSack(Clone)", CommonMaterials.wheatSack);
        }

        public override List<IApplianceProperty> Properties => new List<IApplianceProperty> {
            KitchenPropertiesUtils.GetUnlimitedCItemProvider(GDOUtils.GetCustomGameDataObject<WheatGrainPortion>().GameDataObject.ID)
        };

        public override List<(Locale, ApplianceInfo)> InfoList => new List<(Locale, ApplianceInfo)> {
            (Locale.English, new ApplianceInfo() {
                Name = "Wheat Grain",
                Description = "Provides grain for wheat beer"
            })
        };
    }
}