using Kitchen;
using KitchenBlargleBrew;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;
using static KitchenData.ItemGroup;

namespace BlargleBrew.draft.extract {

    class ExtractBoiling : CustomItemGroup<ExtractBoiling.ExtractBoilingItemGroupView> {

        public override string UniqueNameID => "ExtractBoiling";
        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("ExtractBoiling");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.Small;
        public override Item DisposesTo => Refs.Pot;

        public override List<ItemSet> Sets => new List<ItemSet>() {
            new ItemSet() {
                Max = 1,
                Min = 1,
                IsMandatory = true,
                Items = new List<Item>() {
                    Refs.ExtractHeated,
                }
            },
            new ItemSet() {
                Max = 1,
                Min = 1,
                IsMandatory = true,
                Items = new List<Item>() {
                    Refs.HopsBag,
                }
            },
        };

        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess> {
            new Item.ItemProcess {
                Duration = 1f,
                IsBad = false,
                Process = Refs.CookProcess,
                Result = Refs.ExtractBoiledWithTrash,
            }
        };


        public override void OnRegister(ItemGroup gameDataObject) {
            MaterialUtils.ApplyMaterial(Prefab, "pot", CommonMaterials.ExtractStout.pot);
            MaterialUtils.ApplyMaterial(Prefab, "liquid", CommonMaterials.ExtractStout.extractDiluted);
            MaterialUtils.ApplyMaterial(Prefab, "foam", CommonMaterials.ExtractStout.foam);
            MaterialUtils.ApplyMaterial(Prefab, "bag/contents", CommonMaterials.Hops.hops);
            MaterialUtils.ApplyMaterial(Prefab, "bag/clip", CommonMaterials.Hops.clip);
            MaterialUtils.ApplyMaterial(Prefab, "bag/bag", CommonMaterials.Hops.bag);

            Prefab.GetComponent<ExtractBoilingItemGroupView>()?.Setup(Prefab);

            if (Prefab.TryGetComponent<ItemGroupView>(out var itemGroupView)) {
                Transform transform = itemGroupView.gameObject.transform.Find("Colour Blind");
                transform.localPosition = new Vector3(0, 0.8f, 0);
            }
        }

        public class ExtractBoilingItemGroupView : ItemGroupView {
            internal void Setup(GameObject prefab) {
                ComponentGroups = new List<ComponentGroup>() {
                    new ComponentGroup() {
                        Item = Refs.ExtractHeated,
                        Objects = new List<GameObject> {
                            GameObjectUtils.GetChildObject(prefab, "pot"),
                            GameObjectUtils.GetChildObject(prefab, "liquid"),
                            GameObjectUtils.GetChildObject(prefab, "foam"),
                        },
                        DrawAll = true,
                    },
                    new ComponentGroup() {
                        Item = Refs.HopsBag,
                        Objects = new List<GameObject> {
                            GameObjectUtils.GetChildObject(prefab, "bag"),
                            GameObjectUtils.GetChildObject(prefab, "bag/bag"),
                            GameObjectUtils.GetChildObject(prefab, "bag/clip"),
                            GameObjectUtils.GetChildObject(prefab, "bag/contents"),
                        },
                        DrawAll = true,
                    },
                };

                ComponentLabels = new List<ColourBlindLabel>() {
                    new ColourBlindLabel() { Text = "Ex", Item = Refs.ExtractHeated },
                    new ColourBlindLabel() { Text = "H", Item = Refs.HopsBag},
                };
            }
        }
    }
}