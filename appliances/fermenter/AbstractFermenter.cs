using ApplianceLib.Api;
using BlargleBrew;
using KitchenBlargleBrew.components;
using KitchenBlargleBrew.kegerator;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenBlargleBrew.appliances.fermenter {

    public abstract class AbstractFermenter : CustomAppliance {

        public abstract int colorId { get; }
        public abstract string beerName { get; }

        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("FermenterSmall");
        public override PriceTier PriceTier => PriceTier.ExtremelyExpensive;
        public override ShoppingTags ShoppingTags => ShoppingTags.Cooking;
        public override bool IsNonInteractive => false;
        public override bool IsPurchasable => false;
        public override bool SellOnlyAsDuplicate => true;
        public override string UniqueNameID => $"BlargleBrew - Fermenter {beerName}";

        public override List<IApplianceProperty> Properties => new List<IApplianceProperty>() {
            new CFermenterState() {
                finishedQuantity = 0,
                fermentingQuantity = 0,
                colorId = colorId,
            },
            new CNewlySpawnedFermenter() { },
        };

        public override List<(Locale, ApplianceInfo)> InfoList => new List<(Locale, ApplianceInfo)> {
            (Locale.English, new ApplianceInfo() {
                Name = $"{beerName} Fermenter",
                Description = $"Put {beerName} wort in it and wait a day. Fill kegs from it the next day."
            })
        };

        public override void OnRegister(Appliance appliance) {
            setupMaterials();
            setupCustomView();
            NotActuallyProviders.RemoveProvidersFrom(appliance);
        }

        private void setupMaterials() {
            MaterialUtils.ApplyMaterial(Prefab, "brite-body", CommonMaterials.thinGlass);
            MaterialUtils.ApplyMaterial(Prefab, "fermenter-body", CommonMaterials.thinGlass);
            MaterialUtils.ApplyMaterial(Prefab, "legs", CommonMaterials.metalShiny);
        }

        private void setupCustomView() {
            Prefab.AddComponent<FermenterView>().Setup(Prefab);
        }
    }
}