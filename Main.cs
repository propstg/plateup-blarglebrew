using ApplianceLib.Api;
using BlargleBrew.cards;
using BlargleBrew.draft;
using Kitchen;
using KitchenBlargleBrew.kegerator;
using KitchenLib;
using KitchenLib.Event;
using KitchenMods;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace KitchenBlargleBrew {

    public class BlargleBrewMod : BaseMod {

        public const string MOD_ID = "blargle.BlargleBrew";
        public const string MOD_NAME = "BlargleBrew";
        public const string MOD_VERSION = "0.1.1";
        public const string MOD_AUTHOR = "blargle";

        public static AssetBundle bundle;

        public BlargleBrewMod() : base(MOD_ID, MOD_NAME, MOD_AUTHOR, MOD_VERSION, ">=1.1.5", Assembly.GetExecutingAssembly()) { }

        protected override void OnPostActivate(Mod mod) {
            Log($"v{MOD_VERSION} initialized");
            Log($"Loading asset bundle...");
            bundle = mod.GetPacks<AssetBundleModPack>().SelectMany(e => e.AssetBundles).First();
            Log($"Asset bundle loaded.");

            AddGameDataObject<BeerCanEmpty>();
            AddGameDataObject<BeerCanClosed>();
            AddGameDataObject<BeerCanOpen>();
            AddGameDataObject<BeerCanProvider>();

            AddGameDataObject<BeerBottleEmpty>();
            AddGameDataObject<BeerBottleClosed>();
            AddGameDataObject<BeerBottleOpen>();
            AddGameDataObject<BeerBottleProvider>();

            AddGameDataObject<BeerMugStout>();
            AddGameDataObject<BeerMugWheat>();
            AddGameDataObject<WheatBeerWithOrange>();
            AddGameDataObject<EmptyMug>();
            AddGameDataObject<EmptyKeg>();
            AddGameDataObject<KegStout>();
            AddGameDataObject<KegWheat>();
            AddGameDataObject<KegProviderStout>();
            AddGameDataObject<KegProviderWheat>();
            AddGameDataObject<EmptyMugProvider>();
            AddGameDataObject<Kegerator>();

            AddGameDataObject<DraftBeerDish>();
            AddGameDataObject<BoxedBeerDish>();
            AddGameDataObject<DessertBeerDish>();

            //AddGameDataObject<Fermenter>();

            Events.BuildGameDataEvent += delegate (object s, BuildGameDataEventArgs args) {
                RestrictedItemSplits.BlacklistItem(Refs.KegStout);
                RestrictedItemSplits.AllowItem("BlargleBrew - Kegerator", Refs.KegStout);
                RestrictedItemSplits.BlacklistItem(Refs.KegLight);
                RestrictedItemSplits.AllowItem("BlargleBrew - Kegerator", Refs.KegLight);
            };
        }

        protected override void OnInitialise() {
            base.OnInitialise();
        }

        public static void Log(object message) {
            Debug.Log($"[{MOD_ID}] {message}");
        }
    }
}