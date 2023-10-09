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

        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("FermenterBrite");
        public override PriceTier PriceTier => PriceTier.ExtremelyExpensive;
        public override ShoppingTags ShoppingTags => ShoppingTags.Cooking;
        public override bool IsNonInteractive => false;
        public override bool IsPurchasable => true;
        public override bool SellOnlyAsDuplicate => true;
        public override string UniqueNameID => $"BlargleBrew - Fermenter {beerName}";

        public override List<IApplianceProperty> Properties => new List<IApplianceProperty>() {
            new CFermenterState() {
                finishedQuantity = 5,
                fermentingQuantity = 0,
                colorId = colorId,
            },
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
            MaterialUtils.ApplyMaterial(Prefab, "body", CommonMaterials.metalShiny);
            MaterialUtils.ApplyMaterial(Prefab, "spigot", CommonMaterials.metalBlack);
            MaterialUtils.ApplyMaterial(Prefab, "body-hose", CommonMaterials.metalDirty);
            MaterialUtils.ApplyMaterial(Prefab, "body-hose-clamps", CommonMaterials.metalBlack);
            MaterialUtils.ApplyMaterial(Prefab, "brite-body", CommonMaterials.metalShiny);
            MaterialUtils.ApplyMaterial(Prefab, "brite-gauge", CommonMaterials.thinGlass);
            MaterialUtils.ApplyMaterial(Prefab, "brite-gauge-holder", CommonMaterials.metalBlack);
            MaterialUtils.ApplyMaterial(Prefab, "brite-gauge-segment-0", CommonMaterials.wheat);
            MaterialUtils.ApplyMaterial(Prefab, "brite-gauge-segment-1", CommonMaterials.wheat);
            MaterialUtils.ApplyMaterial(Prefab, "brite-gauge-segment-2", CommonMaterials.wheat);
            MaterialUtils.ApplyMaterial(Prefab, "brite-gauge-segment-3", CommonMaterials.wheat);
            MaterialUtils.ApplyMaterial(Prefab, "brite-gauge-segment-4", CommonMaterials.wheat);
            MaterialUtils.ApplyMaterial(Prefab, "brite-gauge-segment-5", CommonMaterials.wheat);
            MaterialUtils.ApplyMaterial(Prefab, "brite-gauge-segment-6", CommonMaterials.wheat);
            MaterialUtils.ApplyMaterial(Prefab, "brite-gauge-segment-7", CommonMaterials.wheat);
            MaterialUtils.ApplyMaterial(Prefab, "brite-gauge-segment-8", CommonMaterials.wheat);
            MaterialUtils.ApplyMaterial(Prefab, "brite-gauge-segment-9", CommonMaterials.wheat);
            MaterialUtils.ApplyMaterial(Prefab, "fermenter-gauge", CommonMaterials.thinGlass);
            MaterialUtils.ApplyMaterial(Prefab, "fermenter-gauge-holder", CommonMaterials.metalBlack);
            MaterialUtils.ApplyMaterial(Prefab, "fermenter-gauge-segment-0", CommonMaterials.wheat);
            MaterialUtils.ApplyMaterial(Prefab, "fermenter-gauge-segment-1", CommonMaterials.wheat);
            MaterialUtils.ApplyMaterial(Prefab, "fermenter-gauge-segment-2", CommonMaterials.wheat);
            MaterialUtils.ApplyMaterial(Prefab, "fermenter-gauge-segment-3", CommonMaterials.wheat);
            MaterialUtils.ApplyMaterial(Prefab, "fermenter-gauge-segment-4", CommonMaterials.wheat);
            MaterialUtils.ApplyMaterial(Prefab, "fermenter-gauge-segment-5", CommonMaterials.wheat);
            MaterialUtils.ApplyMaterial(Prefab, "fermenter-gauge-segment-6", CommonMaterials.wheat);
            MaterialUtils.ApplyMaterial(Prefab, "fermenter-gauge-segment-7", CommonMaterials.wheat);
            MaterialUtils.ApplyMaterial(Prefab, "fermenter-gauge-segment-8", CommonMaterials.wheat);
            MaterialUtils.ApplyMaterial(Prefab, "fermenter-gauge-segment-9", CommonMaterials.wheat);
        }

        private void setupCustomView() {
            Prefab.AddComponent<FermenterView>().Setup(Prefab);
        }
    }
}