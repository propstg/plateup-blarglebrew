﻿using BlargleBrew.appliances;
using KitchenBlargleBrew;
using KitchenBlargleBrew.components;
using KitchenBlargleBrew.kegerator;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace BlargleBrew.draft {

    public abstract class AbstractKegProvider<T> : CustomAppliance {

        protected abstract string name { get; }
        protected abstract string displayName { get; }
        protected abstract Material[] labelMaterial { get; }
        protected abstract string prefabName { get; }
        protected abstract bool preventReturns { get; }
        protected virtual Material[] kegMaterial => CommonMaterials.Keg.metal;
        protected virtual bool conditionalProvider { get; }
        protected virtual string labelPath { get; }

        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>(prefabName);

        public override PriceTier PriceTier => PriceTier.Medium;
        public override ShoppingTags ShoppingTags => ShoppingTags.Cooking | ShoppingTags.Misc;
        public override bool IsPurchasable => true;
        public override bool SellOnlyAsDuplicate => true;
        public override string UniqueNameID => $"BlargleBrew - Keg {name}";

        public override List<IApplianceProperty> Properties { get {
                var itemProvider = KitchenPropertiesUtils.GetUnlimitedCItemProvider(GDOUtils.GetCustomGameDataObject<T>().GameDataObject.ID);
                itemProvider.PreventReturns = preventReturns;

                var applianceProperties = new List<IApplianceProperty> { itemProvider, new CKegProvider() };
                
                if (conditionalProvider) {
                    applianceProperties.Add(new CConditionallyPaidProvider() {
                        requiredCardId = Refs.HomebrewDish.ID,
                        price = 20,
                        preventBuyingOnCredit = true,
                        idForAccounting = GDOUtils.GetCustomGameDataObject<T>().GameDataObject.ID,
                    });
                }

                return applianceProperties;
            }
        }

        public override List<(Locale, ApplianceInfo)> InfoList => new List<(Locale, ApplianceInfo)> {
            (Locale.English, new ApplianceInfo() {
                Name = $"Keg {displayName}",
                Description = $"Provides {displayName} keg"
            })
        };

        public override void OnRegister(Appliance gdo) {
            MaterialUtils.ApplyMaterial(Prefab, "kegs", kegMaterial);
            MaterialUtils.ApplyMaterial(Prefab, "kegrack", CommonMaterials.Keg.rack);
            MaterialUtils.ApplyMaterial(Prefab, labelPath, labelMaterial);
            Prefab.AddComponent<ConditionallyPaidProviderView>().Setup(Prefab);
        }
    }
}