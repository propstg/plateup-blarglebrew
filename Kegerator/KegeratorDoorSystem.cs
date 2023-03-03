using Kitchen;
using KitchenMods;
using Unity.Collections;
using Unity.Entities;

namespace KitchenBlargleBrew.kegerator {

    /*
    public class KegeratorLoadedSystem : GameSystemBase, IModSystem {
        private EntityQuery viewsQuery;

        protected override void Initialise() {
            base.Initialise();
            viewsQuery = GetEntityQuery(new QueryHelper()
                .All(typeof(CItemHolder), typeof(CKegeratorState)));
        }

        protected override void OnUpdate() {
            var entities = viewsQuery.ToEntityArray(Allocator.TempJob);
            var holders = viewsQuery.ToComponentDataArray<CItemHolder>(Allocator.Temp);
            var components = viewsQuery.ToComponentDataArray<CKegeratorState>(Allocator.Temp);

            for (var i = 0; i < holders.Length; i++) {
                var entity = entities[i];
                var holder = holders[i];
                var data = components[i];

                if (HasComponent<CKegColor>(holder.HeldItem)) {

                } else {

                }
            }

            entities.Dispose();
            holders.Dispose();
            components.Dispose();
        }
    }
    */

    [UpdateBefore(typeof(ItemTransferGroup))]
    public class KegeratorDoorSystem : ItemInteractionSystem, IModSystem {
        private CKegeratorState state;

        protected override InteractionType RequiredType => InteractionType.Act;

        protected override bool IsPossible(ref InteractionData data) {
            return Require(data.Target, out state);
        }

        protected override void Perform(ref InteractionData data) {
            BlargleBrewMod.Log("perform, current state = " + state.open);

            //if (isCounterClearOfItems(data)) {
                state.open = !state.open;
                BlargleBrewMod.Log("new state = " + state.open);
                SetComponent(data.Target, state);
            //}
        }

        private bool isCounterClearOfItems(InteractionData data) {
            return Require<CItemHolder>(data.Target, out var holder) && holder.HeldItem == default;
        }
    }
}