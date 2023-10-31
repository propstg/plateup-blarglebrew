using ApplianceLib.Api.Prefab;
using BlargleBrew;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenBlargleBrew.draft.pumpkin {

    public class PumpkinExtractCanProvider : CustomAppliance {

        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("PumpkinExtractFridge");
        public override PriceTier PriceTier => PriceTier.Medium;
        public override ShoppingTags ShoppingTags => ShoppingTags.Cooking;
        public override bool IsPurchasable => true;
        public override bool SellOnlyAsDuplicate => true;
        public override string UniqueNameID => "BlargleBrew - Pumpkin Extract Provider";

        // TODO materials
        public override void OnRegister(Appliance gdo) {
            var fridgePrefab = (GDOUtils.GetExistingGDO(ApplianceReferences.SourceMeat) as IHasPrefab)?.Prefab.transform.Find("Fridge").gameObject;
            Prefab.AttachPrefabAsChild(fridgePrefab);
            MaterialUtils.ApplyMaterial(Prefab, "body", CommonMaterials.ExtractStout.glass);
            MaterialUtils.ApplyMaterial(Prefab, "extract", CommonMaterials.ExtractStout.extractUndiluted);
            MaterialUtils.ApplyMaterial(Prefab, "label", CommonMaterials.ExtractStout.label);
            MaterialUtils.ApplyMaterial(Prefab, "lid", CommonMaterials.ExtractStout.lid);
            Prefab.transform.Find("body").transform.localPosition += new Vector3(0, 0.5f, 0);
            Prefab.transform.Find("extract").transform.localPosition += new Vector3(0, 0.5f, 0);
            Prefab.transform.Find("label").transform.localPosition += new Vector3(0, 0.5f, 0);
            Prefab.transform.Find("lid").transform.localPosition += new Vector3(0, 0.5f, 0);
        }

        public override List<IApplianceProperty> Properties => new List<IApplianceProperty> {
            KitchenPropertiesUtils.GetUnlimitedCItemProvider(GDOUtils.GetCustomGameDataObject<PumpkinExtractCanClosed>().GameDataObject.ID)
        };

        public override List<(Locale, ApplianceInfo)> InfoList => new List<(Locale, ApplianceInfo)> {
            (Locale.English, new ApplianceInfo() {
                Name = "Pumpkin Extract Can",
                Description = "Provides extract for pumpkin beer"
            })
        };
    }
}