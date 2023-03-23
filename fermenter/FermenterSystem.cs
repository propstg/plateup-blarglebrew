using Kitchen;
using KitchenMods;
using Unity.Entities;
using UnityEngine;

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

            if (!state.infinite) {
                state.kegQuantity = (state.kegQuantity + 1) % 10;
            }

            if (Require(data.Interactor, out CItemHolder itemHolder) && Require(itemHolder.HeldItem, out CKegColor kegColor)) {
                if (kegColor.colorId == 0) {
                    EntityManager.DestroyEntity(itemHolder.HeldItem);
                }
            }

            BlargleBrewMod.Log("new state = " + state.kegQuantity);
            SetComponent(data.Target, state);
        }
    }
}