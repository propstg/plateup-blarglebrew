using Kitchen;
using KitchenBlargleBrew.components;
using KitchenBlargleBrew.kegerator;
using KitchenMods;
using Unity.Entities;
using UnityEngine;

namespace KitchenBlargleBrew.appliances.fermenter {

    [UpdateBefore(typeof(ItemTransferGroup))]
    public class FermenterGrabSystem : ItemInteractionSystem, IModSystem {
        private CFermenterState state;
        private CItemProvider itemProvider;
        private CItemHolder itemHolder;
        private CKegColor kegColor;

        protected override InteractionType RequiredType => InteractionType.Grab;

        protected override bool IsPossible(ref InteractionData data) {
            if (Require(data.Target, out state) &&
                Require(data.Interactor, out itemHolder) &&
                Require(itemHolder.HeldItem, out kegColor)) {

                Debug.Log(kegColor.colorId == 0 && state.finishedQuantity > 0);

                return kegColor.colorId == 0 && state.finishedQuantity > 0;
            }

            return false;
        }

        protected override void Perform(ref InteractionData data) {
            BlargleBrewMod.Log("perform grab, current state = " + state.fermentingQuantity);

            state.finishedQuantity--;
            EntityManager.DestroyEntity(itemHolder.HeldItem);
            Entity createdKeg = EntityManager.CreateEntity((ComponentType) typeof (CCreateItem), (ComponentType) typeof (CHeldBy), (ComponentType) typeof (CKeg));
            Context.Set<CCreateItem>(createdKeg, (CCreateItem) Refs.KegStout.ID);
            Context.Set<CHeldBy>(createdKeg, (CHeldBy) data.Interactor);
            Context.Set<CItemHolder>(data.Interactor, (CItemHolder) createdKeg);
            SetComponent(data.Target, state);
        }
    }
}