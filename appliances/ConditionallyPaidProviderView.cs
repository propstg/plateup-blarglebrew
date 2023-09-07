using Kitchen;
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
            EntityQuery Views;
            protected override void Initialise() {
                base.Initialise();
                Views = GetEntityQuery(typeof(CConditionallyPaidProvider), typeof(CLinkedView));
            }

            protected override void OnUpdate() {
                NativeArray<CConditionallyPaidProvider> conditionallyPaidProviders = Views.ToComponentDataArray<CConditionallyPaidProvider>(Allocator.Temp);
                NativeArray<CLinkedView> views = Views.ToComponentDataArray<CLinkedView>(Allocator.Temp);
                Debug.Log($"asdf - {views.Length}");

                for (int i = 0; i < views.Length; i++) {
                    CLinkedView view = views[i];
                    CConditionallyPaidProvider conditionallyPaidProvider = conditionallyPaidProviders[i];

                    bool active = GameInfo.AllCurrentCards
                        .Select(card => card.CardID)
                        .Any(cardId => cardId == conditionallyPaidProvider.requiredCardId);
                    Debug.Log(GameInfo.AllCurrentCards);
                    Debug.Log(active);

                    SendUpdate(view, new ViewData() {
                        enabled = active,
                        price = conditionallyPaidProvider.price,
                        preventBuyingOnCredit = conditionallyPaidProvider.preventBuyingOnCredit,
                    }, MessageType.SpecificViewUpdate);
                }

                conditionallyPaidProviders.Dispose();
                views.Dispose();
            }
        }

        [MessagePackObject(false)]
        public class ViewData : ISpecificViewData, IViewData.ICheckForChanges<ViewData> {
            [Key(0)] public int price;
            [Key(1)] public bool enabled;
            [Key(2)] public bool preventBuyingOnCredit;

            public IUpdatableObject GetRelevantSubview(IObjectView view) => view.GetSubView<ConditionallyPaidProviderView>();

            public bool IsChangedFrom(ViewData check) {
                return price != check.price || enabled != check.enabled || preventBuyingOnCredit != check.preventBuyingOnCredit;
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

            Debug.Log("update data");
            price.SetActive(data.enabled);
            if (data.enabled) {
                textMeshPro.text = $"{data.price} <sprite name=\"coin\" color=\"#ffcb00\">";
            }
        }


        public void Setup(GameObject prefab) {
            Debug.Log("ASDF registered");
            this.prefab = prefab;
        }
    }
}