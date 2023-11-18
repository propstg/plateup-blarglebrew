using BlargleBrew;
using Kitchen;
using KitchenBlargleBrew.components;
using KitchenLib.Utils;
using MessagePack;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace KitchenBlargleBrew.kegerator {

    public class FermenterView : UpdatableObjectView<FermenterView.ViewData> {

        [SerializeField]
        public GameObject[] fermentingGauge;
        [SerializeField]
        public GameObject[] finishedGauge;

        public void Setup(GameObject prefab) {
            fermentingGauge = new GameObject[] {
                GameObjectUtils.GetChildObject(prefab, "fermenter-segment-0"),
                GameObjectUtils.GetChildObject(prefab, "fermenter-segment-1"),
                GameObjectUtils.GetChildObject(prefab, "fermenter-segment-2"),
                GameObjectUtils.GetChildObject(prefab, "fermenter-segment-3"),
                GameObjectUtils.GetChildObject(prefab, "fermenter-segment-4"),
                GameObjectUtils.GetChildObject(prefab, "fermenter-segment-5"),
                GameObjectUtils.GetChildObject(prefab, "fermenter-segment-6"),
                GameObjectUtils.GetChildObject(prefab, "fermenter-segment-7"),
                GameObjectUtils.GetChildObject(prefab, "fermenter-segment-8"),
                GameObjectUtils.GetChildObject(prefab, "fermenter-segment-9"),
                GameObjectUtils.GetChildObject(prefab, "fermenter-segment-10"),
                GameObjectUtils.GetChildObject(prefab, "fermenter-segment-11"),
                GameObjectUtils.GetChildObject(prefab, "fermenter-segment-12"),
                GameObjectUtils.GetChildObject(prefab, "fermenter-segment-13"),
                GameObjectUtils.GetChildObject(prefab, "fermenter-segment-14"),
                GameObjectUtils.GetChildObject(prefab, "fermenter-segment-15"),
                GameObjectUtils.GetChildObject(prefab, "fermenter-segment-16"),
                GameObjectUtils.GetChildObject(prefab, "fermenter-segment-17"),
                GameObjectUtils.GetChildObject(prefab, "fermenter-segment-18"),
                GameObjectUtils.GetChildObject(prefab, "fermenter-segment-19"),
            };
            finishedGauge = new GameObject[] {
                GameObjectUtils.GetChildObject(prefab, "brite-segment-0"),
                GameObjectUtils.GetChildObject(prefab, "brite-segment-1"),
                GameObjectUtils.GetChildObject(prefab, "brite-segment-2"),
                GameObjectUtils.GetChildObject(prefab, "brite-segment-3"),
                GameObjectUtils.GetChildObject(prefab, "brite-segment-4"),
                GameObjectUtils.GetChildObject(prefab, "brite-segment-5"),
                GameObjectUtils.GetChildObject(prefab, "brite-segment-6"),
                GameObjectUtils.GetChildObject(prefab, "brite-segment-7"),
                GameObjectUtils.GetChildObject(prefab, "brite-segment-8"),
                GameObjectUtils.GetChildObject(prefab, "brite-segment-9"),
                GameObjectUtils.GetChildObject(prefab, "brite-segment-10"),
                GameObjectUtils.GetChildObject(prefab, "brite-segment-11"),
                GameObjectUtils.GetChildObject(prefab, "brite-segment-12"),
                GameObjectUtils.GetChildObject(prefab, "brite-segment-13"),
                GameObjectUtils.GetChildObject(prefab, "brite-segment-14"),
                GameObjectUtils.GetChildObject(prefab, "brite-segment-15"),
                GameObjectUtils.GetChildObject(prefab, "brite-segment-16"),
                GameObjectUtils.GetChildObject(prefab, "brite-segment-17"),
                GameObjectUtils.GetChildObject(prefab, "brite-segment-18"),
                GameObjectUtils.GetChildObject(prefab, "brite-segment-19"),
            };
        }

        protected override void UpdateData(ViewData viewData) {
            for (int i = 0; i < 19; i++) {
                fermentingGauge[i].SetActive(viewData.fermentingQuantity > i);
                switch (viewData.colorId) {
                    case 1:
                        MaterialUtils.ApplyMaterial(fermentingGauge[i], "", CommonMaterials.Mug.stoutBeer);
                        break;
                    case 2:
                        MaterialUtils.ApplyMaterial(fermentingGauge[i], "", CommonMaterials.Mug.wheatBeer);
                        break;
                    case 3:
                        MaterialUtils.ApplyMaterial(fermentingGauge[i], "", CommonMaterials.Mug.pumpkinBeer);
                        break;
                    default:
                        MaterialUtils.ApplyMaterial(fermentingGauge[i], "", CommonMaterials.Keg.emptyLabel);
                        break;
                }
            }
            for (int i = 0; i < 19; i++) {
                finishedGauge[i].SetActive(viewData.finishedQuantity > i);
                switch (viewData.colorId) {
                    case 1:
                        MaterialUtils.ApplyMaterial(finishedGauge[i], "", CommonMaterials.Mug.stoutBeer);
                        break;
                    case 2:
                        MaterialUtils.ApplyMaterial(finishedGauge[i], "", CommonMaterials.Mug.wheatBeer);
                        break;
                    case 3:
                        MaterialUtils.ApplyMaterial(finishedGauge[i], "", CommonMaterials.Mug.pumpkinBeer);
                        break;
                    default:
                        MaterialUtils.ApplyMaterial(finishedGauge[i], "", CommonMaterials.Keg.emptyLabel);
                        break;
                }
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

                    SendUpdate(view, new ViewData {fermentingQuantity = fermenterState.fermentingQuantity, finishedQuantity = fermenterState.finishedQuantity, colorId = fermenterState.colorId}, MessageType.SpecificViewUpdate);
                }

                entities.Dispose();
                views.Dispose();
                components.Dispose();
            }
        }

        [MessagePackObject(false)]
        public struct ViewData : ISpecificViewData, IViewData, IViewResponseData, IViewData.ICheckForChanges<ViewData> {

            [Key(1)]
            public int fermentingQuantity;
            [Key(2)]
            public int finishedQuantity;
            [Key(3)]
            public int colorId;

            public bool IsChangedFrom(ViewData check) {
                BlargleBrewMod.Log($"checking if changed. fermentingQuantity = {fermentingQuantity} = {check.finishedQuantity}, finishedQuantity = {finishedQuantity} = {check.finishedQuantity}, colorId = {colorId} = {check.colorId} ");
                return fermentingQuantity == check.fermentingQuantity
                    && finishedQuantity == check.finishedQuantity
                    && colorId == check.colorId;
            }

            public IUpdatableObject GetRelevantSubview(IObjectView view) {
                return view.GetSubView<FermenterView>();
            }
        }
    }
}