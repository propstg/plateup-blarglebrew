using KitchenBlargleBrew;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace BlargleBrew.cards {

    public class BottomlessBeermosasDish : CustomDish {

        public override string UniqueNameID => "Blargle Beer - bottomless beermosas";
        public override DishType Type => DishType.Main;
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override CardType CardType => CardType.Default;
        public override GameObject DisplayPrefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("DraftDisplay");
        public override GameObject IconPrefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("DraftDisplay");

        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Medium;
        public override bool IsAvailableAsLobbyOption =>
            #if DEBUG
                true;
            #else
                false;
            #endif

        public override bool RequiredNoDishItem => true;

        public override List<Unlock> HardcodedRequirements => new List<Unlock> {
            Refs.DraftBeerDish
        };

        public override HashSet<Item> MinimumIngredients => new HashSet<Item> {
            Refs.BeerWheat,
            Refs.KegLight,
            Refs.OrangeJuice
        };

        public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>() {
            new Dish.MenuItem() { Phase = MenuPhase.Starter, Item = Refs.Beermosa, Weight = 1 },
            new Dish.MenuItem() { Phase = MenuPhase.Main, Item = Refs.Beermosa, Weight = 1 },
            new Dish.MenuItem() { Phase = MenuPhase.Side, Item = Refs.Beermosa, Weight = 1 },
            new Dish.MenuItem() { Phase = MenuPhase.Dessert, Item = Refs.Beermosa, Weight = 1 },
        };

        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string> {
            { Locale.English, "Add orange juice to a wheat beer." }
        };

        public override List<(Locale, UnlockInfo)> InfoList => new List<(Locale, UnlockInfo)> {
            { (Locale.English, LocalisationUtils.CreateUnlockInfo("Bottomless Beermosas", "Adds Beermosas for all phases", "") )}
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