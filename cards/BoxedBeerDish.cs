using KitchenBlargleBrew;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace BlargleBrew.cards {

    public class BoxedBeerDish : CustomDish {

        public override string UniqueNameID => "BlargleBrew - CannedBeer";
        public override DishType Type => DishType.Main;
        public override GameObject DisplayPrefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("BoxedDisplay");
        public override GameObject IconPrefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("BoxedDisplay");

        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Medium;
        public override bool IsAvailableAsLobbyOption => false;
        public override bool IsUnlockable => true;

        public override List<Unlock> HardcodedRequirements => new List<Unlock> {
            Refs.DraftBeerDish
        };

        public override HashSet<Item> MinimumIngredients => new HashSet<Item> {
            Refs.BeerCanClosed,
            Refs.BeerBottleClosed,
            Refs.Lime,
        };

        public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>() {
            new Dish.MenuItem() { Item = Refs.BeerCanOpen, Phase = MenuPhase.Starter, Weight = 1 },
            new Dish.MenuItem() { Item = Refs.BeerBottleOpen, Phase = MenuPhase.Starter, Weight = 1 },

            new Dish.MenuItem() { Item = Refs.BeerCanOpen, Phase = MenuPhase.Main, Weight = 2 },
            new Dish.MenuItem() { Item = Refs.BeerBottleOpen, Phase = MenuPhase.Main, Weight = 2 },
            new Dish.MenuItem() { Item = Refs.BeerBottleWithLime, Phase = MenuPhase.Main, Weight = 1 },

            new Dish.MenuItem() { Item = Refs.BeerCanOpen, Phase = MenuPhase.Side, Weight = 1 },
            new Dish.MenuItem() { Item = Refs.BeerBottleOpen, Phase = MenuPhase.Side, Weight = 1 },
        };

        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string> {
            { Locale.English, "Grab a canned or bottled beer, crack it open, serve. Add a lime slice, if requested." }
        };

        public override List<(Locale, UnlockInfo)> InfoList => new List<(Locale, UnlockInfo)> {
            { (Locale.English, LocalisationUtils.CreateUnlockInfo("Boxed Beer", "Serve beer out of boxes.", "How hard could it be?") )}
        };

        public override void SetupIconPrefab(GameObject prefab) {
            setupCommonDisplayPrefab(prefab);
        }

        public override void SetupDisplayPrefab(GameObject prefab) {
            setupCommonDisplayPrefab(prefab);
        }

        private void setupCommonDisplayPrefab(GameObject prefab) {
            MaterialUtils.ApplyMaterial(prefab, "box", CommonMaterials.Can.box);
            MaterialUtils.ApplyMaterial(prefab, "metal", CommonMaterials.Can.metal);
            MaterialUtils.ApplyMaterial(prefab, "painted", CommonMaterials.Can.paint);
            MaterialUtils.ApplyMaterial(prefab, "BeerCanOpen/foam", CommonMaterials.Can.foam);
            MaterialUtils.ApplyMaterial(prefab, "BeerCanOpen/metal", CommonMaterials.Can.metal);
            MaterialUtils.ApplyMaterial(prefab, "BeerCanOpen/painted", CommonMaterials.Can.paint);
        }
    }
}