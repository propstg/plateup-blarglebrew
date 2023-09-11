using Kitchen;
using KitchenBlargleBrew;
using KitchenBlargleBrew.components;
using KitchenLib.Utils;
using KitchenMods;
using MessagePack;
using System.Linq;
using TMPro;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace BlargleBrew.appliances {

    public class ConditionallyPaidProviderView : UpdatableObjectView<ConditionallyPaidProviderView.ViewData> {
        public class UpdateView : IncrementalViewSystemBase<ViewData>, IModSystem {
            EntityQuery viewsQuery;
            protected override void Initialise() {
                base.Initialise();
                RequireSingletonForUpdate<SMoney>();
                viewsQuery = GetEntityQuery(typeof(CConditionallyPaidProvider), typeof(CLinkedView), typeof(CItemProvider));
            }

            protected override void OnUpdate() {
                var entities = viewsQuery.ToEntityArray(Allocator.TempJob);
                var conditionallyPaidProviders = viewsQuery.ToComponentDataArray<CConditionallyPaidProvider>(Allocator.Temp);
                var views = viewsQuery.ToComponentDataArray<CLinkedView>(Allocator.Temp);
                var itemProviders = viewsQuery.ToComponentDataArray<CItemProvider>(Allocator.Temp);

                SMoney money = GetSingleton<SMoney>();
                for (int i = 0; i < views.Length; i++) {
                    CLinkedView view = views[i];
                    CConditionallyPaidProvider conditionallyPaidProvider = conditionallyPaidProviders[i];
                    CItemProvider itemProvider = itemProviders[i];

                    bool paidConditionMet = GameInfo.AllCurrentCards
                        .Select(card => card.CardID)
                        .Any(cardId => cardId == conditionallyPaidProvider.requiredCardId);
                    
                    if (paidConditionMet != conditionallyPaidProvider.paidConditionMet) {
                        conditionallyPaidProvider.paidConditionMet = paidConditionMet;
                        SetComponent<CConditionallyPaidProvider>(entities[i], conditionallyPaidProvider);
                    }

                    if (paidConditionMet && conditionallyPaidProvider.preventBuyingOnCredit && (GetSingleton<SMoney>() - conditionallyPaidProvider.price) < 0) {
                        EntityManager.AddComponent<CPreventItemTransfer>(entities[i]);
                    } else if (Has<CPreventItemTransfer>(entities[i])) {
                        EntityManager.RemoveComponent<CPreventItemTransfer>(entities[i]);
                    }

                    SendUpdate(view, new ViewData() {
                        paidConditionMet = paidConditionMet,
                        price = conditionallyPaidProvider.price,
                    }, MessageType.SpecificViewUpdate);
                }

                entities.Dispose();
                conditionallyPaidProviders.Dispose();
                views.Dispose();
                itemProviders.Dispose();
            }
        }

        [MessagePackObject(false)]
        public class ViewData : ISpecificViewData, IViewData.ICheckForChanges<ViewData> {
            [Key(0)] public int price;
            [Key(1)] public bool paidConditionMet;

            public IUpdatableObject GetRelevantSubview(IObjectView view) => view.GetSubView<ConditionallyPaidProviderView>();

            public bool IsChangedFrom(ViewData check) {
                return price != check.price || paidConditionMet != check.paidConditionMet;
            }
        }

        public GameObject prefab;
        public GameObject price;
        public TextMeshPro textMeshPro;

        protected override void UpdateData(ViewData data) {
            if (price == null) {
                price = GameObjectUtils.GetChildObject(prefab, "CostDisplay");
                textMeshPro = price.GetChild("Title").GetComponent<TextMeshPro>();
            }

            price.SetActive(data.paidConditionMet);
            if (data.paidConditionMet) {
                textMeshPro.text = $"{data.price} <sprite name=\"coin\" color=\"#ffcb00\">";
            }
        }


        public void Setup(GameObject prefab) {
            this.prefab = prefab;
        }
    }
}