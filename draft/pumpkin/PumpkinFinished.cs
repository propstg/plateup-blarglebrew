using BlargleBrew;
using Kitchen;
using KitchenBlargleBrew.kegerator;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;
using static KitchenData.ItemGroup;

namespace KitchenBlargleBrew.draft.pumpkin {

    class PumpkinFinished : CustomItemGroup<PumpkinFinished.PumpkinFinishedItemGroupView> {

        public override string UniqueNameID => "PumpkinFinished";
        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("PumpkinFinished");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.Small;
        public override Item DisposesTo => Refs.Pot;
        public override Appliance DedicatedProvider => Refs.PumpkinFermenter;

        public override List<IItemProperty> Properties => new List<IItemProperty>() {
            new CFinishedFerment { colorId = 3 },
        };

        public override List<ItemSet> Sets => new List<ItemSet>() {
            new ItemSet() {
                Max = 1,
                Min = 1,
                IsMandatory = true,
                Items = new List<Item>() {
                    Refs.PumpkinCooled,
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

        // TODO materials
        public override void OnRegister(ItemGroup gameDataObject) {
            BlargleBrewMod.Log("Registering PumpkinFinished");
            MaterialUtils.ApplyMaterial(Prefab, "pot", CommonMaterials.WheatBrew.pot);
            MaterialUtils.ApplyMaterial(Prefab, "liquid", CommonMaterials.WheatBrew.wheatBrew);
            MaterialUtils.ApplyMaterial(Prefab, "foam", CommonMaterials.WheatBrew.foam);

            Prefab.GetComponent<PumpkinFinishedItemGroupView>()?.Setup(Prefab);

            if (Prefab.TryGetComponent<ItemGroupView>(out var itemGroupView)) {
                Transform transform = itemGroupView.gameObject.transform.Find("Colour Blind");
                transform.localPosition = new Vector3(0, 0.8f, 0);
            }
            BlargleBrewMod.Log("Registered PumpkinFinished");
        }

        public class PumpkinFinishedItemGroupView : ItemGroupView {
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
                    new ColourBlindLabel() { Text = "PEH", Item = Refs.PumpkinCooled },
                    new ColourBlindLabel() { Text = "Y", Item = Refs.YeastFull },
                };
            }
        }
    }
}