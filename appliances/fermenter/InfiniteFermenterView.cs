using BlargleBrew;
using Kitchen;
using KitchenLib.Utils;
using MessagePack;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace KitchenBlargleBrew.appliances.fermenter {
    /*

    public class InfiniteFermenterView : UpdatableObjectView<InfiniteFermenterView.ViewData> {

        [SerializeField]
        public GameObject gaugeGdo;

        public void Setup(GameObject prefab) {
            gaugeGdo = GameObjectUtils.GetChildObject(prefab, "gauge");
        }

        protected override void UpdateData(ViewData viewData) {
            gaugeGdo.transform.rotation = Quaternion.AngleAxis(-25f * viewData.kegQuantity + 100, Vector3.forward);
            switch (viewData.colorId) {
                case 1:
                    MaterialUtils.ApplyMaterial(gaugeGdo, "", CommonMaterials.Keg.stoutLabel);
                    break;
                case 2:
                    MaterialUtils.ApplyMaterial(gaugeGdo, "", CommonMaterials.Keg.wheatLabel);
                    break;
                default:
                    MaterialUtils.ApplyMaterial(gaugeGdo, "", CommonMaterials.Keg.emptyLabel);
                    break;
            }
        }

        public class UpdateView : IncrementalViewSystemBase<VariableProviderView.ViewData> {

            private EntityQuery viewsQuery;

            protected override void Initialise() {
                base.Initialise();
                viewsQuery = GetEntityQuery(new QueryHelper()
                    .All(typeof(CLinkedView), typeof(CFermenterState)));
            }

            protected override void OnUpdate() {
                var entities = viewsQuery.ToEntityArray(Allocator.TempJob);
                var views = viewsQuery.ToComponentDataArray<CLinkedView>(Allocator.Temp);
                var components = viewsQuery.ToComponentDataArray<CFermenterState>(Allocator.Temp);

                for (var i = 0; i < views.Length; i++) {
                    var view = views[i];
                    var fermenterState = components[i];

                    SendUpdate(view, new ViewData {
                        doneFermenting = fermenterState.doneFermenting,
                        kegQuantity = fermenterState.kegQuantity,
                        colorId = fermenterState.colorId,
                        infinite = fermenterState.infinite,
                    }, MessageType.SpecificViewUpdate);
                }

                entities.Dispose();
                views.Dispose();
                components.Dispose();
            }
        }

        [MessagePackObject(false)]
        public struct ViewData : ISpecificViewData, IViewData, IViewResponseData, IViewData.ICheckForChanges<ViewData> {

            [Key(0)]
            public bool doneFermenting;
            [Key(1)]
            public int kegQuantity;
            [Key(2)]
            public int colorId;
            [Key(3)]
            public bool infinite;

            public bool IsChangedFrom(ViewData check) {
                BlargleBrewMod.Log($"checking if changed. doneFermenting = {doneFermenting} = {check.doneFermenting}, kegQuantity = {kegQuantity} = {check.kegQuantity}");
                return doneFermenting == check.doneFermenting && 
                    kegQuantity == check.kegQuantity &&
                    colorId == check.colorId &&
                    infinite == check.infinite;
            }

            public IUpdatableObject GetRelevantSubview(IObjectView view) {
                return view.GetSubView<InfiniteFermenterView>();
            }
        }
    }
    */
}