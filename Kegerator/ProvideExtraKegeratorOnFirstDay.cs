using Kitchen;
using KitchenBlargleBrew;
using KitchenBlargleBrew.kegerator;
using KitchenMods;
using Unity.Entities;

namespace BlargleBrew.kegerator {

    [UpdateAfter(typeof(ProvideStartingEnvelopes))]
    [UpdateInGroup(typeof(ChangeModeGroup))]
    public class ProvideExtraKegeratorOnFirstDay : RestaurantSystem, IModSystem {

        private static bool hasSpawned = false;
        private EntityQuery kegeratorQuery;

        protected override void Initialise() {
            base.Initialise();
            kegeratorQuery = GetEntityQuery(new QueryHelper().All(typeof(CKegeratorState)));
        }

        protected override void OnUpdate() {
            if (!Has<SLayout>()) {
                return;
            }

            var entities = kegeratorQuery.ToEntityArray(Unity.Collections.Allocator.TempJob);

            if (entities.Length == 1) {
                if (!hasSpawned) {
                    BlargleBrewMod.Log($"Found one kegerator. Spawning another");
                    PostHelpers.CreateApplianceParcel(EntityManager, GetFallbackTile(), Refs.Kegerator.ID);
                    hasSpawned = true;
                }
            } else {
                hasSpawned = false;
            }

            entities.Dispose();
        }
    }
}