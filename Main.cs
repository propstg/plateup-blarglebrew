using ApplianceLib.Api;
using BlargleBrew.beergarita;
using BlargleBrew.boot;
using BlargleBrew.cards;
using BlargleBrew.draft;
using BlargleBrew.draft.extract;
using BlargleBrew.michelada;
using BlargleBrew.processes;
using BlargleBrew.tequila;
using HarmonyLib;
using Kitchen;
using KitchenBlargleBrew.boot;
using KitchenBlargleBrew.draft.extract;
using KitchenBlargleBrew.draft.yeast;
using KitchenBlargleBrew.kegerator;
using KitchenBlargleBrew.michelada;
using KitchenData;
using KitchenLib;
using KitchenLib.Event;
using KitchenLib.References;
using KitchenLib.Utils;
using KitchenMods;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace KitchenBlargleBrew
{
    /*
     * Custom appliance view:

https://github.com/UrFriendKen/PlateUpIceCreamParlour/blob/master/Customs/Appliances/IceCreamStation.cs
https://github.com/UrFriendKen/PlateUpIceCreamParlour/blob/master/LimitedVariableProviderView.cs



Goal:

x 1. Show coins above the keg provider always
2. Only show coins above keg providers when homebrew card equipped
3. Subtract coins when taking a provider
4. Subtract coins when taking from a provider only when homebrew card equipped
5. Prevent taking from a provider when coins are no 
    */

    public class BlargleBrewMod : BaseMod {

        public const string MOD_ID = "blargle.BlargleBrew";
        public const string MOD_NAME = "BlargleBrew";
        public const string MOD_VERSION = "0.4.0";
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
            AddGameDataObject<Fermenter>();
            AddGameDataObject<HomebrewStoutDish>();
            AddGameDataObject<HopsBag>();
            AddGameDataObject<YeastFull>();
            AddGameDataObject<ExtractCanClosed>();
            AddGameDataObject<ExtractCanOpen>();
            AddGameDataObject<ExtractUncooked>();
            AddGameDataObject<ExtractHeated>();
            AddGameDataObject<ExtractBoiling>();
            AddGameDataObject<ExtractBoiledWithTrash>();
            AddGameDataObject<ExtractBoiled>();
            AddGameDataObject<ExtractCooled>();
            AddGameDataObject<ExtractFinished>();
            AddGameDataObject<Cool>();

            Events.BuildGameDataEvent += delegate (object s, BuildGameDataEventArgs args) {
                if (args.gamedata.TryGet(ApplianceReferences.Freezer, out Appliance freezer)) {
                    if (!freezer.Processes.Select(x => x.GetType()).Contains(typeof(Cool))) {
                        freezer.Processes.Add(new Appliance.ApplianceProcesses() {
                            Process = Refs.CoolProcess,
                            IsAutomatic = true,
                            Speed = 1f,
                            Validity = ProcessValidity.Generic
                        });
                    }
                }
            };
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

        private bool colorblindSetup = false;
        protected override void OnUpdate() {
            if (!colorblindSetup) {
                colorblindSetup = true;
                new List<Appliance> { Refs.KegLightProvider, Refs.KegStoutProvider }
                    .Select(appliance => appliance.Prefab)
                    .ForEach(prefab => {
                        Object.Destroy(GameObjectUtils.GetChild(prefab, "Colour Blind"));
                        prefab.AddApplianceColorblindLabel("10 <sprite name=\"coin\" color=\"#ffcb00\">");
                        var newColorBlindPrefab = GameObjectUtils.GetChild(prefab, "Colour Blind");
                        newColorBlindPrefab.transform.localPosition = new Vector3(0.0f, 2.5f, 0.0f);
                        newColorBlindPrefab.name = "CostDisplay";
                        newColorBlindPrefab.GetChild("Title").SetActive(true);
                        Object.Destroy(newColorBlindPrefab.GetComponentInChildren<ColourBlindMode>());
                    });
            }
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