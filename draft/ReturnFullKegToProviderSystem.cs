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
            return isAKegProvider(ref data) &&
                Require(data.Interactor, out heldItem) &&
                Require(heldItem.HeldItem, out splittableItem) &&
                Require(heldItem.HeldItem, out CKeg holdingKeg);
        }

        protected override void Perform(ref InteractionData data) {
            if (splittableItem.RemainingCount == splittableItem.TotalCount) {
                EntityManager.DestroyEntity(heldItem.HeldItem);
            }
        }

        private bool isAKegProvider(ref InteractionData data) => isFlaggedAsKegProvider(ref data) || isAnApplianceWithKegProviderId(ref data);

        private bool isFlaggedAsKegProvider(ref InteractionData data) => Require(data.Target, out CKegProvider kegProvider);

        private bool isAnApplianceWithKegProviderId(ref InteractionData data) =>
            Require(data.Target, out CAppliance appliance) && (appliance.ID == Refs.KegLightProvider.ID || appliance.ID == Refs.KegStoutProvider.ID);
    }
}