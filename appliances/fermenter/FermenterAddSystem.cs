using Kitchen;
using KitchenBlargleBrew.components;
using KitchenBlargleBrew.kegerator;
using KitchenMods;
using Unity.Entities;

namespace KitchenBlargleBrew.appliances.fermenter
{

    [UpdateBefore(typeof(ItemTransferGroup))]
    public class FermenterAddSystem : ItemInteractionSystem, IModSystem {
        private CFermenterState state;
        private CItemProvider itemProvider;
        private CItemHolder itemHolder;
        private CFinishedFerment finishedFerment;

        protected override InteractionType RequiredType => InteractionType.Grab;

        protected override bool IsPossible(ref InteractionData data) {
            if (Require(data.Target, out state) &&
                Require(data.Interactor, out itemHolder) &&
                Require(itemHolder.HeldItem, out finishedFerment)) {

                return finishedFerment.colorId == state.colorId;
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