using ApplianceLib.Api;
using IngredientLib.Util;
using Kitchen;
using KitchenBlargleBrew.kegerator;
using KitchenData;
using KitchenDrinksMod.Customs;
using KitchenLib;
using KitchenLib.Customs;
using KitchenLib.Event;
using KitchenLib.References;
using KitchenLib.Utils;
using KitchenMods;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace KitchenBlargleBrew {

    public class BlargleBrewMod : BaseMod {

        public const string MOD_ID = "blargle.BlargleBrew";
        public const string MOD_NAME = "BlargleBrew";
        public const string MOD_VERSION = "0.0.0";
        public const string MOD_AUTHOR = "blargle";

        public static AssetBundle bundle;

        public BlargleBrewMod() : base(MOD_ID, MOD_NAME, MOD_AUTHOR, MOD_VERSION, "1.1.4", Assembly.GetExecutingAssembly()) { }

        protected override void OnPostActivate(Mod mod) {
            Log($"v{MOD_VERSION} initialized");
            Log($"Loading asset bundle...");
            bundle = mod.GetPacks<AssetBundleModPack>().SelectMany(e => e.AssetBundles).First();
            Log($"Asset bundle loaded.");

            AddGameDataObject<BeerCanEmpty>();
            AddGameDataObject<BeerCanClosed>();
            AddGameDataObject<BeerCanOpen>();
            AddGameDataObject<BeerCanProvider>();

            AddGameDataObject<BeerIpa>();
            AddGameDataObject<BeerLight>();
            AddGameDataObject<EmptyMug>();
            AddGameDataObject<EmptyKeg>();
            AddGameDataObject<KegIpa>();
            AddGameDataObject<KegLight>();
            AddGameDataObject<KegIpaProvider>();
            AddGameDataObject<KegLightProvider>();
            AddGameDataObject<EmptyMugProvider>();
            AddGameDataObject<Kegerator>();
            AddGameDataObject<BeerDish>();

            Events.BuildGameDataEvent += delegate (object s, BuildGameDataEventArgs args) {
                RestrictedItemSplits.BlacklistItem(Refs.KegIpa);
                RestrictedItemSplits.AllowItem("BlargleBrew - Kegerator", Refs.KegIpa);
                RestrictedItemSplits.BlacklistItem(Refs.KegLight);
                RestrictedItemSplits.AllowItem("BlargleBrew - Kegerator", Refs.KegLight);
            };
        }

        protected override void OnInitialise() {
            base.OnInitialise();

            /*
            Appliance flipUpCounter = GDOUtils.GetCastedGDO<Appliance, FlipUpCounter>();
            if (flipUpCounter != null) {
                Appliance countertop = GDOUtils.GetExistingGDO(ApplianceReferences.Countertop) as Appliance;
                if (countertop != null) {
                    countertop.Upgrades.Add(flipUpCounter);
                }
            }
            */
        }

        public static void Log(object message) {
            Debug.Log($"[{MOD_ID}] {message}");
        }
    }

    public class BeerDish : ModDish {
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
            { Locale.English, "TODO" }
        };

        public override IDictionary<Locale, UnlockInfo> LocalisedInfo => new Dictionary<Locale, UnlockInfo> {
            { Locale.English, LocalisationUtils.CreateUnlockInfo("Blargle Beer", "TODO", "TODO") }
        };
    }
}