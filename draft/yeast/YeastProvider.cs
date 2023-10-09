using ApplianceLib.Api.Prefab;
using BlargleBrew;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenBlargleBrew.draft.yeast {

    public class YeastProvider : CustomAppliance {

        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("YeastFridge");
        public override PriceTier PriceTier => PriceTier.Medium;
        public override ShoppingTags ShoppingTags => ShoppingTags.Cooking;
        public override bool IsPurchasable => true;
        public override bool SellOnlyAsDuplicate => true;
        public override string UniqueNameID => "BlargleBrew - Yeast Provider";

        public override void OnRegister(Appliance gdo) {
            var fridgePrefab = (GDOUtils.GetExistingGDO(ApplianceReferences.SourceMeat) as IHasPrefab)?.Prefab.transform.Find("Fridge").gameObject;
            Prefab.AttachPrefabAsChild(fridgePrefab);
            MaterialUtils.ApplyMaterial(Prefab, "body", CommonMaterials.Yeast.glass);
            MaterialUtils.ApplyMaterial(Prefab, "yeast", CommonMaterials.Yeast.yeast);
            Prefab.transform.Find("body").transform.localPosition += new Vector3(0, 0.5f, 0);
            Prefab.transform.Find("yeast").transform.localPosition += new Vector3(0, 0.5f, 0);
        }

        public override List<IApplianceProperty> Properties => new List<IApplianceProperty> {
            KitchenPropertiesUtils.GetUnlimitedCItemProvider(GDOUtils.GetCustomGameDataObject<YeastFull>().GameDataObject.ID)
        };

        public override List<(Locale, ApplianceInfo)> InfoList => new List<(Locale, ApplianceInfo)> {
            (Locale.English, new ApplianceInfo() {
                Name = "Yeast",
                Description = "Provides yeast for beer"
            })
        };
    }
}