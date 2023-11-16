using Kitchen;
using KitchenBlargleBrew;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;
using static KitchenData.ItemGroup;

namespace BlargleBrew.draft.allgrain {

    class WheatMashUnheated : CustomItemGroup<WheatMashUnheated.WheatMashUnheatedItemGroupView> {

        public override string UniqueNameID => "WheatMashUnheated";
        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("MashUncooked");
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
                    Refs.WheatGrainMilled,
                }
            },
            new ItemSet() {
                Max = 1,
                Min = 1,
                Items = new List<Item>() {
                    Refs.HopsBag,
                }
            },
        };

        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess> {
            new Item.ItemProcess {
                Duration = 10f,
                IsBad = false,
                Process = Refs.CookProcess,
                Result = Refs.WheatBoiled,
            }
        };

        public override void OnRegister(ItemGroup gameDataObject) {
            MaterialUtils.ApplyMaterial(Prefab, "pot", CommonMaterials.WheatBrew.pot);
            MaterialUtils.ApplyMaterial(Prefab, "liquid", CommonMaterials.WheatBrew.water);
            MaterialUtils.ApplyMaterial(Prefab, "bag/contents", CommonMaterials.Keg.wheatLabel);
            MaterialUtils.ApplyMaterial(Prefab, "bag/clip", CommonMaterials.Keg.wheatLabel);
            MaterialUtils.ApplyMaterial(Prefab, "bag/bag", CommonMaterials.Hops.bag);

            Prefab.GetComponent<WheatMashUnheatedItemGroupView>()?.Setup(Prefab);

            if (Prefab.TryGetComponent<ItemGroupView>(out var itemGroupView)) {
                Transform transform = itemGroupView.gameObject.transform.Find("Colour Blind");
                transform.localPosition = new Vector3(0, 0.8f, 0);
            }
        }

        public class WheatMashUnheatedItemGroupView : ItemGroupView {
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
                        Item = Refs.WheatGrainMilled,
                        Objects = new List<GameObject> {
                            GameObjectUtils.GetChildObject(prefab, "bag/contents"),
                            GameObjectUtils.GetChildObject(prefab, "bag/clip"),
                            GameObjectUtils.GetChildObject(prefab, "bag/bag"),
                        },
                        DrawAll = true,
                    },
                    // TODO hops bag
                };

                ComponentLabels = new List<ColourBlindLabel>() {
                    new ColourBlindLabel() { Text = "Wh", Item = Refs.WheatGrainMilled },
                    new ColourBlindLabel() { Text = "H", Item = Refs.HopsBag }
                };
            }
        }
    }
}