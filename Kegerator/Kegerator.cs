using ApplianceLib.Api;
using BlargleBrew;
using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenBlargleBrew.kegerator {

    public class Kegerator : CustomAppliance {

        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("Kegerator2");
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
        };

        public override List<(Locale, ApplianceInfo)> InfoList => new List<(Locale, ApplianceInfo)> {
            (Locale.English, new ApplianceInfo() {
                Name = "Kegerator",
                Description = "Put kegs in it and pour drinks"
            })
        };

        public override void OnRegister(Appliance appliance) {
            setupMaterials();
            setupHoldPoint();
            setupCustomView();
            Prefab.transform.localPosition += new Vector3(0, 0.1f, 0);
            NotActuallyProviders.RemoveProvidersFrom(appliance);
        }

        private void setupMaterials() {
            MaterialUtils.ApplyMaterial(Prefab, "base", CommonMaterials.metalBlack);
            MaterialUtils.ApplyMaterial(Prefab, "top", CommonMaterials.metalShiny);
            MaterialUtils.ApplyMaterial(Prefab, "tap", CommonMaterials.metalBlack);
            MaterialUtils.ApplyMaterial(Prefab, "label", CommonMaterials.metalDirty);
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