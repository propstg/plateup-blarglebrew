using ApplianceLib.Api;
using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenBlargleBrew.kegerator {

    public class Kegerator : CustomAppliance {

        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("kegerator");
        public override PriceTier PriceTier => PriceTier.Medium;
        public override ShoppingTags ShoppingTags => ShoppingTags.Cooking;
        public override bool IsNonInteractive => false;
        public override bool IsPurchasable => true;
        public override bool SellOnlyAsDuplicate => true;
        public override string UniqueNameID => "BlargleBrew - Kegerator";

        public override List<IApplianceProperty> Properties => new List<IApplianceProperty>() {
            new CItemHolder(),
            new CKegeratorState(),
            new CItemTransferRestrictions {
                AllowWhenInactive = false,
                AllowWhenActive = true,
            },
            new CRestrictedSplitter {
                ApplianceKey = UniqueNameID
            },
            //KitchenPropertiesUtils.GetUnlimitedCItemProvider(GDOUtils.GetCustomGameDataObject<Mug>().GameDataObject.ID)
        };

        public override List<(Locale, ApplianceInfo)> InfoList => new List<(Locale, ApplianceInfo)> {
            (Locale.English, new ApplianceInfo() {
                Name = "Kegerator",
                Description = "TODO"
            })
        };

        /*
        public override List<Appliance.ApplianceProcesses> Processes => new List<Appliance.ApplianceProcesses> {
            new Appliance.ApplianceProcesses() {
                Process = (Process)GDOUtils.GetExistingGDO(ProcessReferences.Chop),
                Speed = 1f,
                IsAutomatic = false
            },
            new Appliance.ApplianceProcesses() {
                Process = (Process)GDOUtils.GetExistingGDO(ProcessReferences.Knead),
                Speed = 1f,
                IsAutomatic = false
            },
        };
        */

        /*
        public override List<Appliance> Upgrades => new List<Appliance>() {
            GDOUtils.GetExistingGDO(ApplianceReferences.Countertop) as Appliance
        };
        */

        public override void OnRegister(GameDataObject gameDataObject) {
            setupMaterials();
            setupHoldPoint();
            setupCustomView();
            Prefab.transform.localPosition += new Vector3(0, 0.1f, 0);
            NotActuallyProviders.RemoveProvidersFrom(gameDataObject as Appliance);
        }

        private void setupMaterials() {
            var metal = MaterialUtils.GetExistingMaterial("Metal- Shiny");
            var metalBlack = MaterialUtils.GetExistingMaterial("Metal Black");
            var plasticRed = MaterialUtils.GetExistingMaterial("Plastic - Red");
            var glass = MaterialUtils.GetExistingMaterial("IngredientLib - \"Glass\"");

            MaterialUtils.ApplyMaterial(Prefab, "base", new Material[] { metal });
            MaterialUtils.ApplyMaterial(Prefab, "tap column", new Material[] { metalBlack });
            MaterialUtils.ApplyMaterial(Prefab, "tap label", new Material[] { plasticRed });
            MaterialUtils.ApplyMaterial(Prefab, "door/open/frame", new Material[] { metal });
            MaterialUtils.ApplyMaterial(Prefab, "door/closed/frame", new Material[] { metal });
            MaterialUtils.ApplyMaterial(Prefab, "door/open/glass", new Material[] { glass });
            MaterialUtils.ApplyMaterial(Prefab, "door/closed/glass", new Material[] { glass });
        }

        private void setupHoldPoint() {
            HoldPointContainer container = Prefab.AddComponent<HoldPointContainer>();
            container.HoldPoint = GameObjectUtils.GetChildObject(Prefab, "KegHoldPoint").transform;
        }

        private void setupCustomView() {
            Prefab.AddComponent<KegeratorView>().Setup(Prefab);
        }
    }
}