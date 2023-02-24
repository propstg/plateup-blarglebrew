using Kitchen;
using KitchenLib;
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

            AddGameDataObject<Mug>();
            AddGameDataObject<EmptyMug>();
            AddGameDataObject<Keg>();
            AddGameDataObject<KegProvider>();
            AddGameDataObject<EmptyMugProvider>();
            AddGameDataObject<Kegerator>();
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
}