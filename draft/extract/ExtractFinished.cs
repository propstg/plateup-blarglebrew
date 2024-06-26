﻿using Kitchen;
using KitchenBlargleBrew;
using KitchenBlargleBrew.kegerator;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;
using static KitchenData.ItemGroup;

namespace BlargleBrew.draft.extract {

    class ExtractFinished : CustomItemGroup<ExtractFinished.ExtractFinishedItemGroupView> {

        public override string UniqueNameID => "ExtractFinished";
        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("ExtractFinished");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.Small;
        public override Item DisposesTo => Refs.Pot;
        public override Appliance DedicatedProvider => Refs.ExtractFermenter;

        public override List<IItemProperty> Properties => new List<IItemProperty>() {
            new CFinishedFerment { colorId = 1 },
        };

        public override List<ItemSet> Sets => new List<ItemSet>() {
            new ItemSet() {
                Max = 1,
                Min = 1,
                IsMandatory = true,
                Items = new List<Item>() {
                    Refs.ExtractCooled,
                }
            },
            new ItemSet() {
                Max = 1,
                Min = 1,
                IsMandatory = true,
                Items = new List<Item>() {
                    Refs.YeastFull,
                }
            },
        };

        public override void OnRegister(ItemGroup gameDataObject) {
            MaterialUtils.ApplyMaterial(Prefab, "pot", CommonMaterials.ExtractStout.pot);
            MaterialUtils.ApplyMaterial(Prefab, "liquid", CommonMaterials.ExtractStout.extractDiluted);
            MaterialUtils.ApplyMaterial(Prefab, "foam", CommonMaterials.ExtractStout.foam);

            Prefab.GetComponent<ExtractFinishedItemGroupView>()?.Setup(Prefab);

            if (Prefab.TryGetComponent<ItemGroupView>(out var itemGroupView)) {
                Transform transform = itemGroupView.gameObject.transform.Find("Colour Blind");
                transform.localPosition = new Vector3(0, 0.8f, 0);
            }
        }

        public class ExtractFinishedItemGroupView : ItemGroupView {
            internal void Setup(GameObject prefab) {
                ComponentGroups = new List<ComponentGroup>() {
                    new ComponentGroup() {
                        Item = Refs.YeastFull,
                        Objects = new List<GameObject> {
                            GameObjectUtils.GetChildObject(prefab, "pot"),
                            GameObjectUtils.GetChildObject(prefab, "liquid"),
                            GameObjectUtils.GetChildObject(prefab, "foam"),
                        },
                        DrawAll = true,
                    },
                };

                ComponentLabels = new List<ColourBlindLabel>() {
                    new ColourBlindLabel() { Text = "ExH", Item = Refs.ExtractCooled },
                    new ColourBlindLabel() { Text = "Y", Item = Refs.YeastFull },
                };
            }
        }
    }
}