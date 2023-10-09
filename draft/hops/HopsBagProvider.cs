using ApplianceLib.Api.Prefab;
using BlargleBrew;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenBlargleBrew.draft.hops {

    public class HopsBagProvider : CustomAppliance {

        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("HopsFridge");
        public override PriceTier PriceTier => PriceTier.Medium;
        public override ShoppingTags ShoppingTags => ShoppingTags.Cooking;
        public override bool IsPurchasable => true;
        public override bool SellOnlyAsDuplicate => true;
        public override string UniqueNameID => "BlargleBrew - Hops Provider";

        public override void OnRegister(Appliance gdo) {
            var fridgePrefab = (GDOUtils.GetExistingGDO(ApplianceReferences.SourceMeat) as IHasPrefab)?.Prefab.transform.Find("Fridge").gameObject;
            Prefab.AttachPrefabAsChild(fridgePrefab);
            MaterialUtils.ApplyMaterial(Prefab, "bag", CommonMaterials.Hops.bag);
            MaterialUtils.ApplyMaterial(Prefab, "hops", CommonMaterials.Hops.hops);
            Prefab.transform.Find("bag").transform.localPosition += new Vector3(0, 0.5f, 0);
            Prefab.transform.Find("hops").transform.localPosition += new Vector3(0, 0.5f, 0);
        }

        public override List<IApplianceProperty> Properties => new List<IApplianceProperty> {
            KitchenPropertiesUtils.GetUnlimitedCItemProvider(GDOUtils.GetCustomGameDataObject<HopsBag>().GameDataObject.ID)
        };

        public override List<(Locale, ApplianceInfo)> InfoList => new List<(Locale, ApplianceInfo)> {
            (Locale.English, new ApplianceInfo() {
                Name = "Hops",
                Description = "Provides hops for beer"
            })
        };
    }
}