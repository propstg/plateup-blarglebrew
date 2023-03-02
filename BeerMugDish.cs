using ApplianceLib.Customs.GDO;
using KitchenData;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenBlargleBrew {

    public class BeerMugDish : ModDish {

        public override string UniqueNameID => "Blargle Beer";
        public override DishType Type => DishType.Base;
        public override GameObject DisplayPrefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("mug");
        public override GameObject IconPrefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("mug");

        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.LargeIncrease;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Medium;
        public override bool IsAvailableAsLobbyOption => true;
        public override List<string> StartingNameSet => new List<string> {
            "BLARGLEBEER"
        };

        public override HashSet<Item> MinimumIngredients => new HashSet<Item> {
            Refs.BeerIpa,
            Refs.BeerLight,
            Refs.KegIpa,
            Refs.KegLight,
            Refs.BeerCanClosed,
            (Item) GDOUtils.GetExistingGDO(ItemReferences.WineBottle)
        };

        public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>() {
            new Dish.MenuItem() {
                Item = Refs.BeerIpa,
                Phase = MenuPhase.Main,
                Weight = 1
            },
            new Dish.MenuItem() {
                Item = Refs.BeerLight,
                Phase = MenuPhase.Main,
                Weight = 1
            },
            new Dish.MenuItem() {
                Item = Refs.BeerIpa,
                Phase = MenuPhase.Starter,
                Weight = 1
            },
            new Dish.MenuItem() {
                Item = Refs.BeerLight,
                Phase = MenuPhase.Starter,
                Weight = 1
            },
            new Dish.MenuItem() {
                Item = Refs.BeerCanOpen,
                Phase = MenuPhase.Main,
                Weight = 10
            },
            new Dish.MenuItem() {
                Item = Refs.BeerIpa,
                Phase = MenuPhase.Side,
                Weight = 10 
            },
            new Dish.MenuItem() {
                Item = Refs.BeerLight,
                Phase = MenuPhase.Side,
                Weight = 10 
            },
            new Dish.MenuItem() {
                Item = (Item) GDOUtils.GetExistingGDO(ItemReferences.WineBottle),
                Phase = MenuPhase.Side,
                Weight = 10,
                
            },
            new Dish.MenuItem() {
                Item = Refs.BeerIpa,
                Phase = MenuPhase.Dessert,
                Weight = 1
            },
            new Dish.MenuItem() {
                Item = Refs.BeerLight,
                Phase = MenuPhase.Dessert,
                Weight = 1
            }
        };

        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string> {
            { Locale.English, "RECIPE" }
        };

        public override List<(Locale, UnlockInfo)> InfoList => new List<(Locale, UnlockInfo)> {
            { (Locale.English, LocalisationUtils.CreateUnlockInfo("Blargle Beer", "description", "flavor text") )}
        };
    }
}