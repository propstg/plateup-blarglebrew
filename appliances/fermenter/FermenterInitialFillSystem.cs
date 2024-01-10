using Kitchen;
using KitchenBlargleBrew;
using KitchenBlargleBrew.components;
using KitchenMods;
using System;
using Unity.Collections;
using Unity.Entities;

namespace BlargleBrew.appliances.fermenter {

    public class FermenterInitialFillSystem : GenericSystemBase, IModSystem {

        private static readonly int minimumKegs = 3;

        private EntityQuery fermenterStateQuery;
        private EntityQuery customerScheduleQuery;

        protected override void Initialise() {
            base.Initialise();
            fermenterStateQuery = GetEntityQuery(new QueryHelper().All(typeof(CFermenterState), typeof(CNewlySpawnedFermenter)));
            customerScheduleQuery = GetEntityQuery(new QueryHelper().All(typeof(CScheduledCustomer)));
            RequireForUpdate(fermenterStateQuery);
        }

        protected override void OnUpdate() {
            using var entities = fermenterStateQuery.ToEntityArray(Allocator.TempJob);
            using var states = fermenterStateQuery.ToComponentDataArray<CFermenterState>(Allocator.Temp);

            int groups = customerScheduleQuery.CalculateEntityCount();
            int maxGroupSize = GetSingleton<SKitchenParameters>().Parameters.MaximumGroupSize;

            int kegs = minimumKegs + (int) Math.Ceiling((groups * maxGroupSize * 2) / 5f);

            BlargleBrewMod.Log($"Found {groups} customer groups");
            BlargleBrewMod.Log($"Found maximum group size of {maxGroupSize}");
            BlargleBrewMod.Log($"Setting kegs for newly spawned kegs to (groups * maxGroupSize * 2) / 5 + minimumKegs = ({groups} * {maxGroupSize} * 2) / 5 + {minimumKegs} = {kegs}");

            for (var i = 0; i < entities.Length; i++) {
                var entity = entities[i];
                var state = states[i];

                BlargleBrewMod.Log($"Found newly spawned fermenter. Adding {kegs} finished kegs.");

                state.finishedQuantity += kegs;

                SetComponent<CFermenterState>(entity, state);
                EntityManager.RemoveComponent<CNewlySpawnedFermenter>(entity);

                BlargleBrewMod.Log($"Removed newly spawned flag.");
            }
        }
    }
}