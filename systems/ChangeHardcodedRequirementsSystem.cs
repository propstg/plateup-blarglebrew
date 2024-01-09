using Kitchen;
using KitchenBlargleBrew;
using KitchenBlargleBrew.kegerator;
using KitchenMods;
using System.Linq;
using Unity.Collections;
using Unity.Entities;

namespace BlargleBrew.systems {

    /*
    public class ChangeHardcodedRequirementsSystem : StartOfNightSystem, IModSystem {

        //private EntityQuery kegQuery;

        protected override void Initialise() {
            base.Initialise();
            //kegQuery = GetEntityQuery(new QueryHelper().All(typeof(CKeg)));
        }

        protected override void OnUpdate() {
            bool isHomebrewActive = GameInfo.AllCurrentCards
                .Select(card => card.CardID)
                .Any(cardId => cardId == Refs.HomebrewDish.ID);

            if (!isHomebrewActive) {
                Refs.StoutFloatDish.PrerequisiteDishes = new System.Collections.Generic.HashSet<KitchenData.Dish> {
                    Refs.DraftBeerDish
                };
                return;
            }
            Refs.StoutFloatDish.PrerequisiteDishes = new System.Collections.Generic.HashSet<KitchenData.Dish> {
                Refs.HomebrewDish
            };

            //var entities = kegQuery.ToEntityArray(Allocator.TempJob);
            //var kegs = kegQuery.ToComponentDataArray<CKeg>(Allocator.Temp);
//
            //for (var i = 0; i < entities.Length; i++) {
                //var entity = entities[i];
                //var keg = kegs[i];
//
                //EntityManager.AddComponent<CPreservedOvernight>(entity);
            //}
//
            //entities.Dispose();
            //kegs.Dispose();
        }
    }
    */
}