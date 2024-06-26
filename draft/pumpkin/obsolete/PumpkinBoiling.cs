﻿using BlargleBrew;
using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System;
using System.Collections.Generic;
using UnityEngine;
using static KitchenData.ItemGroup;

namespace KitchenBlargleBrew.draft.pumpkin {

    [Obsolete]
    class PumpkinBoiling : CustomItemGroup<PumpkinBoiling.PumpkinBoilingItemGroupView> {

        public override string UniqueNameID => "PumpkinBoiling";
        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("PumpkinBoiling");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.Small;
        public override Item DisposesTo => Refs.Pot;

        public override List<ItemSet> Sets => new List<ItemSet>() {
            new ItemSet() {
                Max = 1,
                Min = 1,
                IsMandatory = true,
                Items = new List<Item>() {
                    Refs.PumpkinHeated,
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
                Duration = 10f,
                IsBad = false,
                Process = Refs.CookProcess,
                Result = Refs.PumpkinBoiledWithTrash,
            }
        };
        
        public override void OnRegister(ItemGroup gameDataObject) {
            MaterialUtils.ApplyMaterial(Prefab, "pot", CommonMaterials.PumpkinBrew.pot);
            MaterialUtils.ApplyMaterial(Prefab, "liquid", CommonMaterials.PumpkinBrew.pumpkinExtractDiluted);
            MaterialUtils.ApplyMaterial(Prefab, "foam", CommonMaterials.PumpkinBrew.foam);
            MaterialUtils.ApplyMaterial(Prefab, "bag/contents", CommonMaterials.Hops.hops);
            MaterialUtils.ApplyMaterial(Prefab, "bag/clip", CommonMaterials.Hops.clip);
            MaterialUtils.ApplyMaterial(Prefab, "bag/bag", CommonMaterials.Hops.bag);

            Prefab.GetComponent<PumpkinBoilingItemGroupView>()?.Setup(Prefab);

            if (Prefab.TryGetComponent<ItemGroupView>(out var itemGroupView)) {
                Transform transform = itemGroupView.gameObject.transform.Find("Colour Blind");
                transform.localPosition = new Vector3(0, 0.8f, 0);
            }
        }

        public class PumpkinBoilingItemGroupView : ItemGroupView {

            internal void Setup(GameObject prefab) {
                ComponentGroups = new List<ComponentGroup>() {
                    new ComponentGroup() {
                        Item = Refs.PumpkinHeated,
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
                    new ColourBlindLabel() { Text = "PeP", Item = Refs.PumpkinHeated },
                    new ColourBlindLabel() { Text = "H", Item = Refs.HopsBag },
                };
            }
        }
    }
}