using Kitchen;
using KitchenMods;
using Unity.Entities;
using UnityEngine;

namespace KitchenBlargleBrew.kegerator {

    [UpdateBefore(typeof(ItemTransferGroup))]
    public class FermenterAddSystem : ItemInteractionSystem, IModSystem {
        private CFermenterState state;
        private CItemProvider itemProvider;
        private CItemHolder itemHolder;
        private CFinishedFerment kegColor;

        protected override InteractionType RequiredType => InteractionType.Act;

        protected override bool IsPossible(ref InteractionData data) {
            if (Require(data.Target, out state) &&
                Require(data.Interactor, out itemHolder) &&
                Require(itemHolder.HeldItem, out kegColor)) {

                Debug.Log("Here");
                Debug.Log(kegColor.colorId == state.colorId);

                // TODO change to CFinishedFerment.colorId
                return kegColor.colorId == state.colorId;
            }

            return false;
        }

        protected override void Perform(ref InteractionData data) {
            BlargleBrewMod.Log("perform, current state = " + state.fermentingQuantity);

            EntityManager.DestroyEntity(itemHolder.HeldItem);
            state.fermentingQuantity++;
            SetComponent(data.Target, state);

            Entity createdPot = EntityManager.CreateEntity((ComponentType) typeof (CCreateItem), (ComponentType) typeof (CHeldBy));
            Context.Set<CCreateItem>(createdPot, (CCreateItem) Refs.Pot.ID);
            Context.Set<CHeldBy>(createdPot, (CHeldBy) data.Interactor);
            Context.Set<CItemHolder>(data.Interactor, (CItemHolder) createdPot);
        }
    }
}