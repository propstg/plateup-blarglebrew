using ApplianceLib.Api;
using BlargleBrew.beergarita;
using BlargleBrew.boot;
using BlargleBrew.cards;
using BlargleBrew.draft;
using BlargleBrew.draft.allgrain;
using BlargleBrew.draft.extract;
using BlargleBrew.michelada;
using BlargleBrew.processes;
using BlargleBrew.tequila;
using HarmonyLib;
using Kitchen;
using KitchenBlargleBrew.appliances.fermenter;
using KitchenBlargleBrew.boot;
using KitchenBlargleBrew.draft.allgrain;
using KitchenBlargleBrew.draft.extract;
using KitchenBlargleBrew.draft.hops;
using KitchenBlargleBrew.draft.pumpkin;
using KitchenBlargleBrew.draft.yeast;
using KitchenBlargleBrew.kegerator;
using KitchenBlargleBrew.michelada;
using KitchenData;
using KitchenLib;
using KitchenLib.Event;
using KitchenLib.References;
using KitchenLib.Utils;
using KitchenMods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace KitchenBlargleBrew {

    public class BlargleBrewMod : BaseMod {

        public const string MOD_ID = "blargle.BlargleBrew";
        public const string MOD_NAME = "BlargleBrew";
        public const string MOD_VERSION = "0.6.0";
        public const string MOD_AUTHOR = "blargle";

        public static AssetBundle bundle;

        public BlargleBrewMod() : base(MOD_ID, MOD_NAME, MOD_AUTHOR, MOD_VERSION, ">=1.1.8", Assembly.GetExecutingAssembly()) { }

        protected override void OnPostActivate(Mod mod) {
            Log($"v{MOD_VERSION} initialized");
            Log($"Loading asset bundle...");
            bundle = mod.GetPacks<AssetBundleModPack>().SelectMany(e => e.AssetBundles).First();
            Log($"Asset bundle loaded.");

            registerBoxedItems();
            registerDraftItems();
            registerDraftPumpkin();
            registerDessertItems();
            registerMicheladaItems();
            registerBootItems();
            registerBeermosaItems();
            registerPickledEggItems();
            registerStoutFloatItems();
            registerTequilaBottle();
            registerTequilaAndLimeDish();
            registerBeergaritaDish();

            registerCoolProcess();
            registerCommonHomebrewItems();
            registerWheatHomebrewItems();
            registerStoutHomebrewItems();
            registerPumpkinHomebrewItems();

            //AddGameDataObject<PeanutBowlDish>();

            Events.BuildGameDataEvent += delegate (object s, BuildGameDataEventArgs args) {
                RestrictedItemSplits.BlacklistItem(Refs.KegStout);
                RestrictedItemSplits.AllowItem("BlargleBrew - Kegerator", Refs.KegStout);
                RestrictedItemSplits.BlacklistItem(Refs.KegLight);
                RestrictedItemSplits.AllowItem("BlargleBrew - Kegerator", Refs.KegLight);
                RestrictedItemSplits.BlacklistItem(Refs.KegPumpkin);
                RestrictedItemSplits.AllowItem("BlargleBrew - Kegerator", Refs.KegPumpkin);
            };
        }

        private void registerBoxedItems() {
            AddGameDataObject<BoxedBeerDish>();
            AddGameDataObject<BeerCanEmpty>();
            AddGameDataObject<BeerCanClosed>();
            AddGameDataObject<BeerCanOpen>();
            AddGameDataObject<BeerCanProvider>();

            AddGameDataObject<BeerBottleEmpty>();
            AddGameDataObject<BeerBottleClosed>();
            AddGameDataObject<BeerBottleOpen>();
            AddGameDataObject<BeerBottleWithLime>();
            AddGameDataObject<BeerBottleProvider>();
        }

        private void registerDraftItems() {
            AddGameDataObject<DraftBeerDish>();
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
        }

        private void registerDraftPumpkin() {
            AddGameDataObject<DraftPumpkinDish>();
            AddGameDataObject<BeerMugPumpkin>();
            AddGameDataObject<KegPumpkin>();
            AddGameDataObject<KegProviderPumpkin>();
        }

        private void registerDessertItems() {
            AddGameDataObject<DessertBeerDish>();
        }

        private void registerMicheladaItems() {
            AddGameDataObject<MicheladaDish>();
            AddGameDataObject<Michelada>();
            AddGameDataObject<TomatoJuice>();
            AddGameDataObject<TomatoJuicePitcher>();
            AddGameDataObject<TomatoJuiceUnmixed>();
        }

        private void registerBootItems() {
            AddGameDataObject<BootDish>();
            AddGameDataObject<EmptyBoot>();
            AddGameDataObject<EmptyBootProvider>();
            AddGameDataObject<StoutBoot>();
        }

        private void registerBeermosaItems() {
            AddGameDataObject<BottomlessBeermosasDish>();
            AddGameDataObject<Beermosa>();
        }

        private void registerPickledEggItems() {
            AddGameDataObject<PickledEggDish>();
            AddGameDataObject<PickledEgg>();
        }

        private void registerStoutFloatItems() {
            AddGameDataObject<StoutFloatDish>();
            AddGameDataObject<StoutFloat>();
        }

        private void registerTequilaBottle() {
            AddGameDataObject<TequilaBottle>();
            AddGameDataObject<TequilaBottleProvider>();
            AddGameDataObject<TequilaShot>();
        }

        private void registerTequilaAndLimeDish() {
            AddGameDataObject<TequilaAndLime>();
            AddGameDataObject<TequilaAndLimeDish>();
        }

        private void registerBeergaritaDish() {
            AddGameDataObject<Beergarita>();
            AddGameDataObject<BeergaritaDish>();
        }

        private void registerCommonHomebrewItems() {
            AddGameDataObject<HopsBagEmpty>();
            AddGameDataObject<HopsBag>();
            AddGameDataObject<HopsBagProvider>();
            AddGameDataObject<YeastFull>();
            AddGameDataObject<YeastProvider>();
            AddGameDataObject<KegProviderEmpty>();
        }

        private void registerCoolProcess() {
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
        }

        private void registerWheatHomebrewItems() {
            AddGameDataObject<HomebrewWheatDish>();
            AddGameDataObject<WheatFermenter>();
            AddGameDataObject<WheatGrainPortion>();
            AddGameDataObject<WheatGrainMilled>();
            AddGameDataObject<WheatGrainProvider>();
            AddGameDataObject<WheatGrainEmptyBag>();

            AddGameDataObject<WheatMashUnheated>();
            AddGameDataObject<WheatMashWithTrash>();
            AddGameDataObject<WheatHeated>();
            AddGameDataObject<WheatBoiling>();
            AddGameDataObject<WheatBoiledWithTrash>();
            AddGameDataObject<WheatBoiled>();
            AddGameDataObject<WheatCooled>();
            AddGameDataObject<WheatFinished>();
        }

        private void registerStoutHomebrewItems() {
            AddGameDataObject<HomebrewStoutDish>();
            AddGameDataObject<ExtractFermenter>();
            AddGameDataObject<ExtractCanClosed>();
            AddGameDataObject<ExtractCanOpen>();
            AddGameDataObject<ExtractCanProvider>();
            AddGameDataObject<ExtractUncooked>();
            AddGameDataObject<ExtractHeated>();
            AddGameDataObject<ExtractBoiling>();
            AddGameDataObject<ExtractBoiledWithTrash>();
            AddGameDataObject<ExtractBoiled>();
            AddGameDataObject<ExtractCooled>();
            AddGameDataObject<ExtractFinished>();
        }

        private void registerPumpkinHomebrewItems() {
            AddGameDataObject<HomebrewPumpkinDish>();
            AddGameDataObject<PumpkinFermenter>();
            AddGameDataObject<PumpkinExtractCanClosed>();
            AddGameDataObject<PumpkinExtractCanOpen>();
            AddGameDataObject<PumpkinExtractCanProvider>();

            AddGameDataObject<PumpkinMashUnheated>();
            AddGameDataObject<PumpkinMashWithTrash>();
            AddGameDataObject<PumpkinHeated>();
            AddGameDataObject<PumpkinBoiling>();
            AddGameDataObject<PumpkinBoiledWithTrash>();
            AddGameDataObject<PumpkinBoiled>();
            AddGameDataObject<PumpkinFinished>();
            AddGameDataObject<PumpkinCooled>();
        }

        protected override void OnInitialise() {
            base.OnInitialise();
        }

        private bool colorblindSetup = false;
        protected override void OnUpdate() {
            if (!colorblindSetup) {
                colorblindSetup = true;
                new List<Appliance> { Refs.KegLightProvider, Refs.KegStoutProvider, Refs.KegProviderPumpkin }
                    .Select(appliance => appliance.Prefab)
                    .ForEach(prefab => {
                        var existingColourBlindChild = GameObjectUtils.GetChild(prefab, "Colour Blind");
                        if (existingColourBlindChild != null) {
                            existingColourBlindChild.name = "asdf";
                        }

                        prefab.AddApplianceColorblindLabel("10 <sprite name=\"coin\" color=\"#ffcb00\">");
                        var newColorBlindPrefab = GameObjectUtils.GetChild(prefab, "Colour Blind");
                        newColorBlindPrefab.transform.localPosition = new Vector3(0.0f, 2.5f, 0.0f);
                        newColorBlindPrefab.name = "CostDisplay";
                        newColorBlindPrefab.GetChild("Title").SetActive(true);
                        newColorBlindPrefab.SetActive(false);
                        UnityEngine.Object.Destroy(newColorBlindPrefab.GetComponentInChildren<ColourBlindMode>());
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
            if (__result.name.Contains("Beer") || 
                __result.name.Contains("mug") || 
                __result.name.Contains("MugWithOrange") ||
                __result.name.Contains("PumpkinMug") ||
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
