using ApplianceLib.Api;
using BlargleBrew.draft;
using IngredientLib.Util;
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

            AddGameDataObject<BeerMugIpa>();
            AddGameDataObject<BeerMugLight>();
            AddGameDataObject<EmptyMug>();
            AddGameDataObject<EmptyKeg>();
            AddGameDataObject<KegIpa>();
            AddGameDataObject<KegLight>();
            AddGameDataObject<KegProviderIpa>();
            AddGameDataObject<KegProviderLight>();
            AddGameDataObject<EmptyMugProvider>();
            AddGameDataObject<Kegerator>();
            AddGameDataObject<BeerMugDish>();

            Events.BuildGameDataEvent += delegate (object s, BuildGameDataEventArgs args) {
                RestrictedItemSplits.BlacklistItem(Refs.KegIpa);
                RestrictedItemSplits.AllowItem("BlargleBrew - Kegerator", Refs.KegIpa);
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