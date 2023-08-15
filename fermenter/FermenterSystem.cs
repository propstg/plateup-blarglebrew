using Kitchen;
using KitchenMods;
using Unity.Entities;
using UnityEngine;

namespace KitchenBlargleBrew.kegerator {

    [UpdateBefore(typeof(ItemTransferGroup))]
    public class FermenterSystem : ItemInteractionSystem, IModSystem {
        private CFermenterState state;
        private CItemProvider itemProvider;
        private CItemHolder itemHolder;
        private CKegColor kegColor;

        protected override InteractionType RequiredType => InteractionType.Act;

        protected override bool IsPossible(ref InteractionData data) {
            if (Require(data.Target, out state) &&
                Require(data.Interactor, out itemHolder) &&
                Require(itemHolder.HeldItem, out kegColor)) {

                Debug.Log("Here");
                Debug.Log(kegColor.colorId == state.colorId || (kegColor.colorId == 0 && state.finishedQuantity > 0));

                return kegColor.colorId == state.colorId || (kegColor.colorId == 0 && state.finishedQuantity > 0);
            }

            return false;
        }

        protected override void Perform(ref InteractionData data) {
            BlargleBrewMod.Log("perform, current state = " + state.fermentingQuantity);

            if (kegColor.colorId == state.colorId) {
                EntityManager.DestroyEntity(itemHolder.HeldItem);
                state.fermentingQuantity++;
            } else if (kegColor.colorId == 0 && state.finishedQuantity > 0) {
                state.finishedQuantity--;
                EntityManager.DestroyEntity(itemHolder.HeldItem);
                Entity smsPaper = EntityManager.CreateEntity((ComponentType) typeof (CCreateItem), (ComponentType) typeof (CHeldBy), (ComponentType) typeof (CKeg));
                Context.Set<CCreateItem>(smsPaper, (CCreateItem) Refs.KegLight.ID);
                Context.Set<CHeldBy>(smsPaper, (CHeldBy) data.Interactor);
                Context.Set<CItemHolder>(data.Interactor, (CItemHolder) smsPaper);
            }
            SetComponent(data.Target, state);
        }
    }
}