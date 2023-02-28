using Kitchen;
using KitchenLib.Utils;
using MessagePack;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace KitchenBlargleBrew.kegerator {

    public class KegeratorView : UpdatableObjectView<KegeratorView.ViewData> {

        [SerializeField]
        public GameObject openGdo;
        [SerializeField]
        public GameObject closedGdo;
        [SerializeField]
        public HoldPointContainer holdPointContainer;
        [SerializeField]
        public Transform kegHoldPoint;
        [SerializeField]
        public Transform mugHoldPoint;

        public void Setup(GameObject prefab) {
            openGdo = GameObjectUtils.GetChildObject(prefab, "door/open");
            closedGdo = GameObjectUtils.GetChildObject(prefab, "door/closed");
            holdPointContainer = prefab.GetComponent<HoldPointContainer>();
            kegHoldPoint = GameObjectUtils.GetChildObject(prefab, "KegHoldPoint").transform;
            mugHoldPoint = GameObjectUtils.GetChildObject(prefab, "MugHoldPoint").transform;
        }

        protected override void UpdateData(ViewData viewData) {
            openGdo.SetActive(false);
            closedGdo.SetActive(false);
            //if (viewData.open) {
                //holdPointContainer.HoldPoint = kegHoldPoint;
            //} else {
                //holdPointContainer.HoldPoint = mugHoldPoint;
            //}
        }

        public class UpdateView : IncrementalViewSystemBase<VariableProviderView.ViewData> {

            private EntityQuery viewsQuery;

            protected override void Initialise() {
                base.Initialise();
                viewsQuery = GetEntityQuery(new QueryHelper()
                    .All(typeof(CLinkedView), typeof(CKegeratorState)));
            }

            protected override void OnUpdate() {
                var entities = viewsQuery.ToEntityArray(Allocator.TempJob);
                var views = viewsQuery.ToComponentDataArray<CLinkedView>(Allocator.Temp);
                var components = viewsQuery.ToComponentDataArray<CKegeratorState>(Allocator.Temp);

                for (var i = 0; i < views.Length; i++) {
                    var entity = entities[i];
                    var view = views[i];
                    var data = components[i];

                    SendUpdate(view, new ViewData { open = data.open }, MessageType.SpecificViewUpdate);

                    /*
                    if (!data.open) {
                        EntityManager.AddComponent<CIsInactive>(entity);
                    } else {
                        EntityManager.RemoveComponent<CIsInactive>(entity);
                    }
                    */
                }

                entities.Dispose();
                views.Dispose();
                components.Dispose();
            }
        }

        [MessagePackObject(false)]
        public struct ViewData : ISpecificViewData, IViewData, IViewResponseData, IViewData.ICheckForChanges<ViewData> {

            [Key(0)]
            public bool open;

            public bool IsChangedFrom(ViewData check) {
                BlargleBrewMod.Log($"checking if changed. open != check.open = {open} != {check.open} = {open != check.open}");
                return open != check.open;
            }

            public IUpdatableObject GetRelevantSubview(IObjectView view) {
                return view.GetSubView<KegeratorView>();
            }
        }
    }
}