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
        };

        public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>() {
            new Dish.MenuItem() { Phase = MenuPhase.Starter, Item = Refs.PickledEgg, Weight = 1 },
        };

        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string> {
            { Locale.English, "Add a whole egg to a serving of vinegar. Enjoy!" }
        };

        public override List<(Locale, UnlockInfo)> InfoList => new List<(Locale, UnlockInfo)> {
            { (Locale.English, LocalisationUtils.CreateUnlockInfo("Pickled Egg", "Adds pickled egg as a side.", "Who even enjoys any of this?") )}
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