using ApplianceLib.Api;
using BlargleBrew;
using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenBlargleBrew.kegerator {

    public class InfiniteFermenterWheat : CustomAppliance {

        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("Fermenter");
        public override PriceTier PriceTier => PriceTier.Medium;
        public override ShoppingTags ShoppingTags => ShoppingTags.Cooking;
        public override bool IsNonInteractive => false;
        public override bool IsPurchasable => true;
        public override bool SellOnlyAsDuplicate => true;
        public override string UniqueNameID => "BlargleBrew - Infinite Fermenter Wheat";

        public override List<IApplianceProperty> Properties => new List<IApplianceProperty>() {
            new CFermenterState() {
                infinite = true,
                kegQuantity = 10,
                colorId = 2,
                doneFermenting = true,
            },
        };

        public override List<(Locale, ApplianceInfo)> InfoList => new List<(Locale, ApplianceInfo)> {
            (Locale.English, new ApplianceInfo() {
                Name = "Fermenter",
                Description = "Put wort in it and wait a day. Fill kegs from it the next day."
            })
        };

        public override void OnRegister(Appliance appliance) {
            setupMaterials();
            setupCustomView();
        }

        private void setupMaterials() {
            MaterialUtils.ApplyMaterial(Prefab, "body", CommonMaterials.metalShiny);
            MaterialUtils.ApplyMaterial(Prefab, "spigot", CommonMaterials.metalBlack);
            MaterialUtils.ApplyMaterial(Prefab, "gauge", CommonMaterials.Keg.wheatLabel);
        }

        private void setupCustomView() {
            Prefab.AddComponent<FermenterView>().Setup(Prefab);
        }
    }
}