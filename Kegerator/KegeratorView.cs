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
        public GameObject labelGdo;

        public void Setup(GameObject prefab) {
            openGdo = GameObjectUtils.GetChildObject(prefab, "door/open");
            closedGdo = GameObjectUtils.GetChildObject(prefab, "door/closed");
            labelGdo = GameObjectUtils.GetChildObject(prefab, "tap label");
        }

        protected override void UpdateData(ViewData viewData) {
            openGdo.SetActive(false);
            closedGdo.SetActive(false);

            switch (viewData.colorId) {
                case 1:
                    MaterialUtils.ApplyMaterial(labelGdo, "", new Material[] {
                        MaterialUtils.GetExistingMaterial("Metal Black")
                    });
                    break;
                case 2:
                    MaterialUtils.ApplyMaterial(labelGdo, "", new Material[] {
                        MaterialUtils.GetExistingMaterial("Paper - Postit Yellow")
                    });
                    break;
                default:
                    MaterialUtils.ApplyMaterial(labelGdo, "", new Material[] {
                        MaterialUtils.GetExistingMaterial("Metal - Dirty")
                    });
                    break;
            }
        }

        public class UpdateView : IncrementalViewSystemBase<VariableProviderView.ViewData> {

            private EntityQuery viewsQuery;

            protected override void Initialise() {
                base.Initialise();
                viewsQuery = GetEntityQuery(new QueryHelper()
                    .All(typeof(CLinkedView), typeof(CKegeratorState), typeof(CItemHolder)));
            }

            protected override void OnUpdate() {
                var entities = viewsQuery.ToEntityArray(Allocator.TempJob);
                var views = viewsQuery.ToComponentDataArray<CLinkedView>(Allocator.Temp);
                var components = viewsQuery.ToComponentDataArray<CKegeratorState>(Allocator.Temp);
                var holders = viewsQuery.ToComponentDataArray<CItemHolder>(Allocator.Temp);

                for (var i = 0; i < views.Length; i++) {
                    var entity = entities[i];
                    var view = views[i];
                    var data = components[i];
                    var holder = holders[i];

                    int color = 0;
                    if (HasComponent<CKegColor>(holder.HeldItem)) {
                        color = GetComponent<CKegColor>(holder.HeldItem).colorId;
                    }

                    SendUpdate(view, new ViewData { open = data.open, colorId = color }, MessageType.SpecificViewUpdate);
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
            [Key(1)]
            public int colorId;

            public bool IsChangedFrom(ViewData check) {
                BlargleBrewMod.Log($"checking if changed. open != check.open = {open} != {check.open} = {open != check.open}");
                return open != check.open && colorId != check.colorId;
            }

            public IUpdatableObject GetRelevantSubview(IObjectView view) {
                return view.GetSubView<KegeratorView>();
            }
        }
    }
}