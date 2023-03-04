using ApplianceLib.Customs.GDO;
using KitchenBlargleBrew;
using KitchenData;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace BlargleBrew.cards {

    public class BoxedBeerDish : ModDish {

        public override string UniqueNameID => "BlargleBrew - CannedBeer";
        public override DishType Type => DishType.Main;
        public override GameObject DisplayPrefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("BeerBottleOpen");
        public override GameObject IconPrefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("BeerBottleOpen");

        //public override DishCustomerChange CustomerMultiplier => DishCustomerChange.LargeIncrease;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Medium;
        public override bool IsAvailableAsLobbyOption => true;
        public override List<string> StartingNameSet => new List<string> {
            "Canned Beer"
        };

        public override HashSet<Item> MinimumIngredients => new HashSet<Item> {
            Refs.BeerCanClosed,
            Refs.BeerBottleClosed,
            Refs.Lime,
        };

        public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>() {
            new Dish.MenuItem() { Item = Refs.BeerCanOpen, Phase = MenuPhase.Starter, Weight = 1 },
            new Dish.MenuItem() { Item = Refs.BeerBottleOpen, Phase = MenuPhase.Starter, Weight = 1 },

            new Dish.MenuItem() { Item = Refs.BeerCanOpen, Phase = MenuPhase.Main, Weight = 1 },
            new Dish.MenuItem() { Item = Refs.BeerBottleOpen, Phase = MenuPhase.Main, Weight = 1 },

            new Dish.MenuItem() { Item = Refs.BeerCanOpen, Phase = MenuPhase.Side, Weight = 1 },
            new Dish.MenuItem() { Item = Refs.BeerBottleOpen, Phase = MenuPhase.Side, Weight = 1 },
            new Dish.MenuItem() { Item = Refs.LimeChopped, Phase = MenuPhase.Side, Weight = 1 },

            new Dish.MenuItem() { Item = Refs.BeerCanOpen, Phase = MenuPhase.Dessert, Weight = 1 },
            new Dish.MenuItem() { Item = Refs.BeerBottleOpen, Phase = MenuPhase.Dessert, Weight = 1 },
        };

        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string> {
            { Locale.English, "Grab a canned or bottled beer, crack it open, serve. Add a lime slice, if requested." }
        };

        public override List<(Locale, UnlockInfo)> InfoList => new List<(Locale, UnlockInfo)> {
            { (Locale.English, LocalisationUtils.CreateUnlockInfo("Boxed Beer", "description", "flavor text") )}
        };
    }
}