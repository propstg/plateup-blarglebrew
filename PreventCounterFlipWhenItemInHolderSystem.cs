using BlargleBrew.Kegerator;
using Kitchen;
using KitchenMods;
using Unity.Entities;

namespace KitchenBlargleBrew
{
    [UpdateBefore(typeof(ItemTransferGroup))]
    public class PreventCounterFlipWhenItemInHolderSystem : ItemInteractionSystem, IModSystem {
        private CKegeratorState state;

        protected override InteractionType RequiredType => InteractionType.Act;

        protected override bool IsPossible(ref InteractionData data) {
            return Require(data.Target, out state);
        }

        protected override void Perform(ref InteractionData data) {
            BlargleBrewMod.Log("perform, current state = " + state.open);

            if (isCounterClearOfItems(data)) {
                state.open = !state.open;
                BlargleBrewMod.Log("new state = " + state.open);
                SetComponent(data.Target, state);
            }
        }

        private bool isCounterClearOfItems(InteractionData data) {
            return Require<CItemHolder>(data.Target, out var holder) && holder.HeldItem == default;
        }
    }
}