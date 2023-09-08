using Kitchen;
using KitchenBlargleBrew.components;
using KitchenMods;
using Unity.Collections;
using Unity.Entities;

namespace BlargleBrew.appliances.fermenter {

    public class FermenterNightSystem : StartOfNightSystem, IModSystem {

        private EntityQuery fermenterStateQuery;

        protected override void Initialise() {
            base.Initialise();
            fermenterStateQuery = GetEntityQuery(new QueryHelper().All(typeof(CFermenterState)));
        }

        protected override void OnUpdate() {
            var entities = fermenterStateQuery.ToEntityArray(Allocator.TempJob);
            var states = fermenterStateQuery.ToComponentDataArray<CFermenterState>(Allocator.Temp);

            for (var i = 0; i < entities.Length; i++) {
                var entity = entities[i];
                var state = states[i];

                state.finishedQuantity += state.fermentingQuantity;
                state.fermentingQuantity = 0;

                SetComponent<CFermenterState>(entity, state);
            }

            entities.Dispose();
            states.Dispose();
        }
    }
}