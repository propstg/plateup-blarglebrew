using Kitchen;
using KitchenBlargleBrew.kegerator;
using KitchenMods;
using System.Linq;
using Unity.Entities;

namespace KitchenBlargleBrew.appliances.kegerator {

    [UpdateBefore(typeof(ItemTransferGroup))]
    public class ReturnFullKegToProviderSystem : ItemInteractionSystem, IModSystem {

        private CItemHolder heldItem;
        private CSplittableItem splittableItem;

        protected override InteractionType RequiredType => InteractionType.Grab;

        protected override bool IsPossible(ref InteractionData data) {
            bool isHomebrewActive = GameInfo.AllCurrentCards
                .Select(card => card.CardID)
                .Any(cardId => cardId == Refs.HomebrewDish.ID);

            if (!isHomebrewActive &&
                Require(data.Target, out CAppliance appliance) &&
                Require(data.Target, out CKegProvider kegProvider) &&
                Require(data.Interactor, out heldItem) &&
                Require(heldItem.HeldItem, out CKeg holdingKeg)) {

                Require(heldItem.HeldItem, out CKegColor kegColor);
                if (appliance.ID == Refs.KegEmptyProvider.ID && Require(heldItem.HeldItem, out CCleanEmptyKeg emptyKeg)) {
                    return true;
                } else if (doesHeldKegMatchKegRack(appliance, kegColor)) {
                    Require(heldItem.HeldItem, out splittableItem);
                    return splittableItem.RemainingCount == splittableItem.TotalCount;
                }
            }
            return false;
        }

        private bool doesHeldKegMatchKegRack(CAppliance rack, CKegColor heldKeg) {
            return (rack.ID == Refs.KegLightProvider.ID && heldKeg.colorId == 2) ||
                (rack.ID == Refs.KegStoutProvider.ID && heldKeg.colorId == 1) ||
                (rack.ID == Refs.KegProviderPumpkin.ID && heldKeg.colorId == 3);
        }

        protected override void Perform(ref InteractionData data) {
            EntityManager.DestroyEntity(heldItem.HeldItem);
        }
    }
}