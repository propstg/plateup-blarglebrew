using Kitchen;
using KitchenMods;
using Unity.Entities;

namespace KitchenBlargleBrew.kegerator {

    [UpdateBefore(typeof(ItemTransferGroup))]
    public class ReturnFullKegToProviderSystem : ItemInteractionSystem, IModSystem {

        private CItemHolder heldItem;
        private CSplittableItem splittableItem;

        protected override InteractionType RequiredType => InteractionType.Grab;

        protected override bool IsPossible(ref InteractionData data) {
            if (Require(data.Target, out CAppliance appliance) && 
                Require(data.Target, out CKegProvider kegProvider) && 
                Require(data.Interactor, out heldItem) && 
                Require(heldItem.HeldItem, out CKeg holdingKeg)) {

                Require(heldItem.HeldItem, out CKegColor kegColor);
                if (appliance.ID == Refs.KegEmptyProvider.ID && Require(heldItem.HeldItem, out CCleanEmptyKeg emptyKeg)) {
                    return true;
                } else if ((appliance.ID == Refs.KegLightProvider.ID && kegColor.colorId == 2) || (appliance.ID == Refs.KegStoutProvider.ID && kegColor.colorId == 1)) {
                    Require(heldItem.HeldItem, out splittableItem);
                    return splittableItem.RemainingCount == splittableItem.TotalCount;
                }
            }
            return false;
        }

        protected override void Perform(ref InteractionData data) {
            EntityManager.DestroyEntity(heldItem.HeldItem);
        }
    }
}