using BlargleBrew.utils;
using Kitchen;
using KitchenBlargleBrew.components;
using KitchenMods;
using Unity.Entities;
using UnityEngine;

namespace KitchenBlargleBrew.appliances
{

    [UpdateBefore(typeof(TakeFromProvider))]
    public class ConditionalPaidProviderGrabSystem : TransferInteractionProposalSystem, IModSystem {
        private CConditionallyPaidProvider paidProvider;

        protected override bool IsPossible(ref InteractionData data) {
            if (Require(data.Target, out paidProvider) && paidProvider.paidConditionMet) {

                CItemProvider comp;
                if (Has<CPreventUse>(data.Target) || Has<CPreventItemTransfer>(data.Target) || !Require<CItemProvider>(data.Target, out comp)) {
                    return false;
                }
                TransferFlags flags = TransferFlags.Interaction | TransferFlags.NoReturns | TransferFlags.Provider;
                if (comp.ProvidedItem == 0 || comp.Maximum != 0 && comp.Available == 0) {
                    return false;
                }
                CInteractionTransferProposal data1 = InteractionTransferProposal(data.Interactor);
                if (comp.DirectInsertionOnly) {
                    data1.AllowAct = true;
                    data1.AllowGrab = true;
                    flags |= TransferFlags.RequireMerge;
                } else {
                    data1.AllowAct = false;
                    data1.AllowGrab = true;
                }
                Context.Set<CInteractionTransferProposal>(TransferProposalSystem.CreateProposal(Context, this, Context.CreateItemGroup(comp.ProvidedItem, comp.ProvidedComponents), data.Attempt.Target, data.Interactor, flags), data1);
                return true;
            }

            return false;
        }

        public override void SendTransfer(Entity transfer, Entity acceptance, EntityContext ctx) {
            CItemTransferProposal proposal;
            CItemProvider provider;

            if (!Require<CItemTransferProposal>(transfer, out proposal) || !Require<CItemProvider>(proposal.Source, out provider)) {
                return;
            }

            SMoney money = GetSingleton<SMoney>();
            if (paidProvider.preventBuyingOnCredit && money - paidProvider.price < 0) {
                proposal.Status = ItemTransferStatus.Failed;
                SetComponent<CItemTransferProposal>(transfer, proposal);
                return;
            }

            Require<CPosition>(proposal.Destination, out CPosition position);

            --provider.Available;
            SetComponent<CItemProvider>(proposal.Source, provider);

            money -= paidProvider.price;
            SetSingleton<SMoney>(money);

            MoneyPopupUtil.CreateMoneyPopup(EntityManager, this, -paidProvider.price, paidProvider.idForAccounting, position.Position + Vector3.up);
            CSoundEvent.Create(EntityManager, KitchenData.SoundEvent.ItemDelivered);
        }

        public override void ReceiveResult(Entity result, Entity transfer, Entity acceptance, EntityContext ctx) { }

        public override void Tidy(EntityContext ctx, CItemTransferProposal proposal) {
            if (proposal.Status != ItemTransferStatus.Resolved) {
                ctx.Destroy(proposal.Item);
            }
        }
    }
}