using Kitchen;
using KitchenBlargleBrew;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;
using static KitchenData.ItemGroup;

namespace BlargleBrew.draft.extract {

    class ExtractUncooked : CustomItemGroup<ExtractUncooked.UncookedExtractItemGroupView> {

        public override string UniqueNameID => "UncookedExtract";
        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("ExtractUncooked");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.Small;
        public override Item DisposesTo => Refs.Pot;

        public override List<ItemSet> Sets => new List<ItemSet>() {
            new ItemSet() {
                Max = 2,
                Min = 2,
                IsMandatory = true,
                Items = new List<Item>() {
                    Refs.Pot,
                    Refs.Water,
                }
            },
            new ItemSet() {
                Max = 1,
                Min = 1,
                IsMandatory = true,
                Items = new List<Item>() {
                    Refs.ExtractCanOpen,
                }
            },
        };

        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess> {
            new Item.ItemProcess {
                Duration = 1f,
                IsBad = false,
                Process = Refs.CookProcess,
                Result = Refs.ExtractHeated,
            }
        };

        public override void OnRegister(ItemGroup gameDataObject) {
            MaterialUtils.ApplyMaterial(Prefab, "pot", CommonMaterials.ExtractStout.pot);
            MaterialUtils.ApplyMaterial(Prefab, "liquid", CommonMaterials.ExtractStout.extractDiluted);

            Prefab.GetComponent<UncookedExtractItemGroupView>()?.Setup(Prefab);

            if (Prefab.TryGetComponent<ItemGroupView>(out var itemGroupView)) {
                Transform transform = itemGroupView.gameObject.transform.Find("Colour Blind");
                transform.localPosition = new Vector3(0, 0.8f, 0);
            }
        }

        public class UncookedExtractItemGroupView : ItemGroupView {
            internal void Setup(GameObject prefab) {
                ComponentGroups = new List<ComponentGroup>() {
                    new ComponentGroup() {
                        Item = Refs.Pot,
                        GameObject = GameObjectUtils.GetChildObject(prefab, "pot"),
                    },
                    new ComponentGroup() {
                        Item = Refs.Water,
                        GameObject = GameObjectUtils.GetChildObject(prefab, "liquid"),
                    },
                    new ComponentGroup() {
                        Item = Refs.ExtractCanOpen,
                        GameObject = GameObjectUtils.GetChildObject(prefab, "liquid"),
                    },
                };

                ComponentLabels = new List<ColourBlindLabel>() {
                    new ColourBlindLabel() { Text = "Ex", Item = Refs.Water }
                };
            }
        }
    }
}