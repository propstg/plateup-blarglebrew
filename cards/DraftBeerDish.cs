using KitchenBlargleBrew;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace BlargleBrew.cards {

    public class DraftBeerDish : CustomDish {

        public override string UniqueNameID => "Blargle Beer";
        public override DishType Type => DishType.Base;
        public override GameObject DisplayPrefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("DraftDisplay");
        public override GameObject IconPrefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("DraftDisplay");

        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.LargeIncrease;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Medium;
        public override bool IsAvailableAsLobbyOption => true;
        public override List<string> StartingNameSet => new List<string> {
            "I'm Ok",
            "We Don't Card",
        };

        public override HashSet<Item> MinimumIngredients => new HashSet<Item> {
            Refs.BeerStout,
            Refs.BeerWheat,
            Refs.KegStout,
            Refs.KegLight,
            Refs.Mandarin
        };

        public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>() {
            new Dish.MenuItem() { Phase = MenuPhase.Starter, Item = Refs.BeerStout, Weight = 1 },
            new Dish.MenuItem() { Phase = MenuPhase.Starter, Item = Refs.BeerWheat, Weight = 1 },
            new Dish.MenuItem() { Phase = MenuPhase.Main, Item = Refs.BeerStout, Weight = 1 },
            new Dish.MenuItem() { Phase = MenuPhase.Main, Item = Refs.BeerWheat, Weight = 1 },
            new Dish.MenuItem() { Phase = MenuPhase.Side, Item = Refs.BeerStout, Weight = 1 },
            new Dish.MenuItem() { Phase = MenuPhase.Side, Item = Refs.BeerWheat, Weight = 1 },
            new Dish.MenuItem() { Phase = MenuPhase.Side, Item = Refs.MandarinSlice, Weight = 1 },
        };

        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string> {
            { Locale.English, "Load a keg into a kegerator, pour a beer, serve. Change the keg out when empty." }
        };

        public override List<(Locale, UnlockInfo)> InfoList => new List<(Locale, UnlockInfo)> {
            { (Locale.English, LocalisationUtils.CreateUnlockInfo("Draft Beer", "Adds draft beer as a starter and main", "Offers two flavors, stout and wheat") )}
        };

        public override void SetupIconPrefab(GameObject prefab) {
            setupCommonDisplayPrefab(prefab);
        }

        public override void SetupDisplayPrefab(GameObject prefab) {
            setupCommonDisplayPrefab(prefab);
        }
        
        private void setupCommonDisplayPrefab(GameObject prefab) {
            MaterialUtils.ApplyMaterial(prefab, "keg", CommonMaterials.Keg.metal);
            MaterialUtils.ApplyMaterial(prefab, "label", CommonMaterials.Keg.stoutLabel);
            MaterialUtils.ApplyMaterial(prefab, "mug/glass", CommonMaterials.Mug.glass);
            MaterialUtils.ApplyMaterial(prefab, "mug/beer", CommonMaterials.Mug.stoutBeer);
            MaterialUtils.ApplyMaterial(prefab, "mug/foam", CommonMaterials.Mug.stoutFoam);
        }
    }
}