using ApplianceLib.Api;
using BlargleBrew.beergarita;
using BlargleBrew.boot;
using BlargleBrew.cards;
using BlargleBrew.draft;
using BlargleBrew.michelada;
using BlargleBrew.tequila;
using HarmonyLib;
using Kitchen;
using KitchenBlargleBrew.boot;
using KitchenBlargleBrew.kegerator;
using KitchenBlargleBrew.michelada;
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
        public const string MOD_VERSION = "0.3.0";
        public const string MOD_AUTHOR = "blargle";

        public static AssetBundle bundle;

        public BlargleBrewMod() : base(MOD_ID, MOD_NAME, MOD_AUTHOR, MOD_VERSION, ">=1.1.7", Assembly.GetExecutingAssembly()) { }

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
            AddGameDataObject<BeerBottleWithLime>();
            AddGameDataObject<BeerBottleProvider>();

            AddGameDataObject<BeerMugStout>();
            AddGameDataObject<BeerMugWheat>();
            AddGameDataObject<WheatBeerWithOrange>();
            AddGameDataObject<EmptyMug>();
            AddGameDataObject<EmptyKeg>();
            AddGameDataObject<CleanEmptyKeg>();
            AddGameDataObject<KegStout>();
            AddGameDataObject<KegWheat>();
            AddGameDataObject<KegProviderStout>();
            AddGameDataObject<KegProviderWheat>();
            AddGameDataObject<EmptyMugProvider>();
            AddGameDataObject<Kegerator>();

            AddGameDataObject<Michelada>();
            AddGameDataObject<TomatoJuice>();
            AddGameDataObject<TomatoJuicePitcher>();
            AddGameDataObject<TomatoJuiceUnmixed>();

            AddGameDataObject<DraftBeerDish>();
            AddGameDataObject<BoxedBeerDish>();
            AddGameDataObject<DessertBeerDish>();

#if DEBUG
            AddGameDataObject<InfiniteFermenterWheat>();
            AddGameDataObject<HomebrewStoutDish>();
#endif
            AddGameDataObject<KegProviderEmpty>();

            AddGameDataObject<EmptyBoot>();
            AddGameDataObject<EmptyBootProvider>();
            AddGameDataObject<StoutBoot>();
            AddGameDataObject<BootDish>();
            AddGameDataObject<MicheladaDish>();

            AddGameDataObject<PickledEgg>();
            AddGameDataObject<PickledEggDish>();

            AddGameDataObject<Beermosa>();
            AddGameDataObject<BottomlessBeermosasDish>();

            AddGameDataObject<StoutFloat>();
            AddGameDataObject<StoutFloatDish>();

            AddGameDataObject<TequilaBottle>();
            AddGameDataObject<TequilaBottleProvider>();
            AddGameDataObject<TequilaShot>();
            AddGameDataObject<TequilaAndLime>();
            AddGameDataObject<TequilaAndLimeDish>();
            AddGameDataObject<Beergarita>();
            AddGameDataObject<BeergaritaDish>();

            //AddGameDataObject<PeanutBowlDish>();

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


    [HarmonyPatch(typeof(MenuBackgroundItemScroller), "CreateItem")]
    public class MenuBackgroundItemScroller_CreateItem_Patch {

        public static void Postfix(ref GameObject __result) {
            Debug.Log(__result);
            if (__result.name.Contains("Beer") || 
                __result.name.Contains("mug") || 
                __result.name.Contains("MugWithOrange") ||
                __result.name.Contains("Stout") ||
                __result.name.Contains("Michelada")) {
                changeRotationSoItemsAreNotTopDown(__result);
                __result.transform.localPosition += new Vector3(0, -0.3f, 0);
            }
        }

        private static void changeRotationSoItemsAreNotTopDown(GameObject item) {
            item.transform.localRotation = Quaternion.Euler(new Vector3(-35, 0, 0));
        }
    }
}