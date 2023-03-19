using KitchenBlargleBrew;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace BlargleBrew.cards {

    public class DessertBeerDish : CustomDish {

        public override string UniqueNameID => "Dessert Beer";
        public override DishType Type => DishType.Dessert;
        public override GameObject DisplayPrefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("DraftDisplay");
        public override GameObject IconPrefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("DraftDisplay");

        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Medium;
        public override List<Unlock> HardcodedRequirements => new List<Unlock> {
            Refs.DraftBeerDish,
            Refs.BoxedBeerDish,
        };

        public override HashSet<Item> MinimumIngredients => new HashSet<Item> {
            Refs.BeerStout,
            Refs.BeerWheat,
            Refs.Mandarin,
            Refs.BeerCanClosed,
            Refs.BeerBottleClosed,
            Refs.Lime,
        };

        public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>() {
            new Dish.MenuItem() { Phase = MenuPhase.Dessert, Item = Refs.BeerStout, Weight = 1 },
            new Dish.MenuItem() { Phase = MenuPhase.Dessert, Item = Refs.BeerWheat, Weight = 1 },
            new Dish.MenuItem() { Phase = MenuPhase.Dessert, Item = Refs.BeerCanOpen, Weight = 1 },
            new Dish.MenuItem() { Phase = MenuPhase.Dessert, Item = Refs.BeerBottleOpen, Weight = 1 },
        };

        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string> {
            { Locale.English, "Same recipe as the draft and boxed beers, just more of them." }
        };

        public override List<(Locale, UnlockInfo)> InfoList => new List<(Locale, UnlockInfo)> {
            { (Locale.English, LocalisationUtils.CreateUnlockInfo("One last round", "Customers order more beers for dessert.", "DRINK RESPONSIBLY") )}
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