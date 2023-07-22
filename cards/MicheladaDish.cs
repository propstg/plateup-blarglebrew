using KitchenBlargleBrew;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace BlargleBrew.cards {

    public class MicheladaDish : CustomDish {

        public override string UniqueNameID => "Blargle Beer - Michelada";
        public override DishType Type => DishType.Main;
        public override GameObject DisplayPrefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("Michelada");
        public override GameObject IconPrefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("Michelada");

        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Medium;
        public override bool RequiredNoDishItem => true;
        public override bool IsAvailableAsLobbyOption =>
            #if DEBUG
                true;
            #else
                false;
            #endif

        public override List<Unlock> HardcodedRequirements => new List<Unlock> {
            Refs.BoxedBeerDish,
        };

        public override HashSet<Item> MinimumIngredients => new HashSet<Item> {
            Refs.BeerBottleClosed,
            Refs.Lime,
            Refs.Tomato,
            Refs.Water,
            Refs.Pepper,
        };

        public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>() {
            new Dish.MenuItem() { Phase = MenuPhase.Main, Item = Refs.Michelada, Weight = 1 },
        };

        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string> {
            { Locale.English, "Mix an opened bottle beer, lime juice, tomato juice (tomato sauce + water), and (optionally) chopped peppers." }
        };

        public override List<(Locale, UnlockInfo)> InfoList => new List<(Locale, UnlockInfo)> {
            { (Locale.English, LocalisationUtils.CreateUnlockInfo("Michelada", "Adds a Michelada as a main.", "This one is vegetarian :D") )}
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