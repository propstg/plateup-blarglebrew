﻿using KitchenBlargleBrew;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace BlargleBrew.cards {

    public class HomebrewWheatDish : CustomDish {

        public override string UniqueNameID => "BlargleBrew - Homebrew Wheat";
        public override DishType Type => DishType.Main;
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override CardType CardType => CardType.Default;
        public override GameObject DisplayPrefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("HomebrewDisplay");
        public override GameObject IconPrefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("HomebrewDisplay");

        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Medium;
        public override bool IsAvailableAsLobbyOption =>
            #if DEBUG
                true;
            #else
                false;
            #endif
        public override bool RequiredNoDishItem => true;
        public override bool IsUnlockable => true;

        public override HashSet<Item> MinimumIngredients => new HashSet<Item> {
            Refs.WheatGrainPortion,
            Refs.BeerWheat,
            Refs.Pot,
            Refs.Water,
            Refs.HopsBag,
            Refs.YeastFull,
            Refs.WheatFinished,
            Refs.CleanEmptyKeg,
        };

        public override HashSet<Process> RequiredProcesses => new HashSet<Process> {
            Refs.CookProcess,
            Refs.ChopProcess,
        };

        public override HashSet<Item> BlockProviders => new HashSet<Item> {
            Refs.KegLight
        };

        public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>() {
            new Dish.MenuItem() { Phase = MenuPhase.Starter, Item = Refs.BeerWheat, Weight = 1 },
            new Dish.MenuItem() { Phase = MenuPhase.Main, Item = Refs.BeerWheat, Weight = 2 },
        };

        public override List<Unlock> HardcodedRequirements => new List<Unlock> {
            Refs.HomebrewDish,
        };

        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string> {
            { Locale.English, "Chop/grind grains. Add to pot of water with hops.\nCook.\nLet it cool down.\nAdd yeast.\nAdd to fermenter.\nUse clean, empty keg to retrieve tomorrow.\nServe normally." }
        };

        public override List<(Locale, UnlockInfo)> InfoList => new List<(Locale, UnlockInfo)> {
            { (Locale.English, LocalisationUtils.CreateUnlockInfo("Homebrew Wheat", "Adds homebrew wheat", "") )}
        };

        public override void SetupIconPrefab(GameObject prefab) {
            setupCommonDisplayPrefab(prefab);
        }

        public override void SetupDisplayPrefab(GameObject prefab) {
            setupCommonDisplayPrefab(prefab);
        }
        
        private void setupCommonDisplayPrefab(GameObject prefab) {
            MaterialUtils.ApplyMaterial(prefab, "body", CommonMaterials.metalShiny);
            MaterialUtils.ApplyMaterial(prefab, "spigot", CommonMaterials.metalBlack);
            MaterialUtils.ApplyMaterial(prefab, "body-hose", CommonMaterials.metalDirty);
            MaterialUtils.ApplyMaterial(prefab, "body-hose-clamps", CommonMaterials.metalBlack);
            MaterialUtils.ApplyMaterial(prefab, "brite-body", CommonMaterials.metalShiny);
            MaterialUtils.ApplyMaterial(prefab, "brite-gauge", CommonMaterials.thinGlass);
            MaterialUtils.ApplyMaterial(prefab, "brite-gauge-holder", CommonMaterials.metalBlack);
            MaterialUtils.ApplyMaterial(prefab, "fermenter-gauge", CommonMaterials.thinGlass);
            MaterialUtils.ApplyMaterial(prefab, "fermenter-gauge-holder", CommonMaterials.metalBlack);
        }
    }
}