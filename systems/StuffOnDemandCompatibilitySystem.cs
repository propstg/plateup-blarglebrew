using Kitchen;
using KitchenBlargleBrew;
using KitchenData;
using KitchenMods;
using System.Collections.Generic;
using System.Linq;

namespace BlargleBrew.systems {

    public class StuffOnDemandCompatibilitySystem : FranchiseFirstFrameSystem, IModSystem {

        protected override void OnUpdate() {
            BlargleBrewMod.Log("StuffOnDemand compatibility system running");

            new List<Item> { Refs.BeerStout, Refs.WheatFinished, Refs.ExtractFinished }.ForEach(clearProviderIfNeeded);
        }

        private void clearProviderIfNeeded(Item item) {
            var properties = item.DedicatedProvider.Properties;
            var filteredProperties = properties.Where(p => p.GetType() != typeof(CItemProvider));

            if (properties.Count != filteredProperties.Count()) {
                BlargleBrewMod.Log($"Found provider on ${item.name}. Attempting to remove.");
                item.DedicatedProvider.Properties = filteredProperties.ToList();
            }
        }
    }
}