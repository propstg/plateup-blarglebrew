using KitchenBlargleBrew;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace BlargleBrew.cards {

    /*
    public class PeanutBowlDish : CustomDish {

        public override string UniqueNameID => "Blargle Beer - Peanut Bowl Dish";
        public override DishType Type => DishType.Side;
        public override GameObject DisplayPrefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("DraftDisplay");
        public override GameObject IconPrefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("DraftDisplay");

        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Small;
        public override bool IsAvailableAsLobbyOption =>
            #if DEBUG
                true;
            #else
                false;
            #endif

        public override List<Unlock> HardcodedRequirements => new List<Unlock> {
            Refs.DraftBeerDish,
        };

        public override HashSet<Item> MinimumIngredients => new HashSet<Item> {
            Refs.Nuts,
        };

        public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>() {
            new Dish.MenuItem() { Phase = MenuPhase.Side, Item = Refs.Nuts, Weight = 1 },
        };

        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string> {
            { Locale.English, "Grab a bowl of nuts and throw it at the customers." }
        };

        public override List<(Locale, UnlockInfo)> InfoList => new List<(Locale, UnlockInfo)> {
            { (Locale.English, LocalisationUtils.CreateUnlockInfo("Peanut Bowl", "Adds a peanut bowl as a side.", "Mmm. Salt.") )}
        };
    }
    */
}