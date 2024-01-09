using BlargleBrew;
using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System;
using System.Collections.Generic;
using UnityEngine;
using static KitchenData.ItemGroup;

namespace KitchenBlargleBrew.draft.pumpkin {

    class PumpkinMashUnheated : CustomItemGroup<PumpkinMashUnheated.PumpkinMashUnheatedItemGroupView> {

        public override string UniqueNameID => "PumpkinMashUnheated";
        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("PumpkinMashUncooked");
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
                    Refs.PumpkinExtractCanOpen,
                    Refs.PumpkinExtractCanClosed,
                }
            },
            new ItemSet() {
                Max = 1,
                Min = 1,
                Items = new List<Item>() {
                    Refs.PumpkinPieces,
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
                Result = Refs.PumpkinBoiled,
            }
        };

        public override void OnRegister(ItemGroup gameDataObject) {
            MaterialUtils.ApplyMaterial(Prefab, "pot", CommonMaterials.PumpkinBrew.pot);
            MaterialUtils.ApplyMaterial(Prefab, "liquid", CommonMaterials.PumpkinBrew.pumpkinExtractDiluted);
            MaterialUtils.ApplyMaterial(Prefab, "grains/contents", CommonMaterials.Keg.pumpkinLabel);
            MaterialUtils.ApplyMaterial(Prefab, "grains/clip", CommonMaterials.Keg.pumpkinLabel);
            MaterialUtils.ApplyMaterial(Prefab, "grains/bag", CommonMaterials.Hops.bag);
            MaterialUtils.ApplyMaterial(Prefab, "hops/contents", CommonMaterials.Hops.hops);
            MaterialUtils.ApplyMaterial(Prefab, "hops/clip", CommonMaterials.Hops.clip);
            MaterialUtils.ApplyMaterial(Prefab, "hops/bag", CommonMaterials.Hops.bag);

            Prefab.GetComponent<PumpkinMashUnheatedItemGroupView>()?.Setup(Prefab);

            if (Prefab.TryGetComponent<ItemGroupView>(out var itemGroupView)) {
                Transform transform = itemGroupView.gameObject.transform.Find("Colour Blind");
                transform.localPosition = new Vector3(0, 0.8f, 0);
            }
        }

        public class PumpkinMashUnheatedItemGroupView : ItemGroupView {
            internal void Setup(GameObject prefab) {
                ComponentGroups = new List<ComponentGroup>() {
                    new ComponentGroup() {
                        Item = Refs.Pot,
                        GameObject = GameObjectUtils.GetChildObject(prefab, "pot"),
                    },
                    new ComponentGroup() {
                        Item = Refs.PumpkinExtractCanOpen,
                        GameObject = GameObjectUtils.GetChildObject(prefab, "liquid"),
                    },
                    new ComponentGroup() {
                        Item = Refs.PumpkinExtractCanClosed,
                        GameObject = GameObjectUtils.GetChildObject(prefab, "liquid"),
                    },
                    new ComponentGroup() {
                        Item = Refs.PumpkinPieces,
                        Objects = new List<GameObject> {
                            GameObjectUtils.GetChildObject(prefab, "grains/contents"),
                            GameObjectUtils.GetChildObject(prefab, "grains/clip"),
                            GameObjectUtils.GetChildObject(prefab, "grains/bag"),
                        },
                        DrawAll = true,
                    },
                    new ComponentGroup() {
                        Item = Refs.HopsBag,
                        Objects = new List<GameObject> {
                            GameObjectUtils.GetChildObject(prefab, "hops/contents"),
                            GameObjectUtils.GetChildObject(prefab, "hops/clip"),
                            GameObjectUtils.GetChildObject(prefab, "hops/bag"),
                        },
                        DrawAll = true,
                    },
                };

                ComponentLabels = new List<ColourBlindLabel>() {
                    new ColourBlindLabel() { Text = "Pe", Item = Refs.PumpkinExtractCanOpen},
                    new ColourBlindLabel() { Text = "P", Item = Refs.PumpkinPieces},
                    new ColourBlindLabel() { Text = "H", Item = Refs.HopsBag},
                };
            }
        }
    }
}