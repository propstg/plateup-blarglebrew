using Kitchen;
using KitchenMods;
using Unity.Entities;

namespace KitchenBlargleBrew.kegerator {

    [UpdateBefore(typeof(ItemTransferGroup))]
    public class FermenterSystem : ItemInteractionSystem, IModSystem {
        private CFermenterState state;

        protected override InteractionType RequiredType => InteractionType.Act;

        protected override bool IsPossible(ref InteractionData data) {
            return Require(data.Target, out state);
        }

        protected override void Perform(ref InteractionData data) {
            BlargleBrewMod.Log("perform, current state = " + state.kegQuantity);

            state.kegQuantity = (state.kegQuantity + 1) % 10;

            BlargleBrewMod.Log("new state = " + state.kegQuantity);
            SetComponent(data.Target, state);
        }
    }
}