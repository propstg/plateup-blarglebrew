using Kitchen;
using KitchenBlargleBrew;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;
using static KitchenData.ItemGroup;

namespace BlargleBrew.michelada {

    class TomatoJuiceUnmixed : CustomItemGroup<TomatoJuiceUnmixed.TomatoJuiceUnmixedItemGroup> {

        public override string UniqueNameID => "BlargleBrew - Tomato Juice Unmixed";
        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("TomatoJuiceUnmixed");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.None;
        public override Item DisposesTo => null;
        public override Item DirtiesTo => null;
        public override bool CanContainSide => false;

        public override List<ItemSet> Sets => new List<ItemSet>() {
            new ItemSet() {
                Max = 1,
                Min = 1,
                IsMandatory = true,
                Items = new List<Item>() {
                    Refs.TomatoSauce,
                }
            },
            new ItemSet() {
                Max = 1,
                Min = 1,
                IsMandatory = true,
                Items = new List<Item>() {
                    Refs.Water,
                }
            },
        };

        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess> {
            new Item.ItemProcess {
                Duration = 3f,
                IsBad = false,
                Process = (Process)GDOUtils.GetExistingGDO(ProcessReferences.Chop),
                Result = Refs.TomatoJuicePitcher
            }
        };


        public override void OnRegister(ItemGroup gameDataObject) {
            MaterialUtils.ApplyMaterial(Prefab, "glass", CommonMaterials.TomatoJuice.glass);
            MaterialUtils.ApplyMaterial(Prefab, "contents", CommonMaterials.TomatoJuice.contents);

            Prefab.GetComponent<TomatoJuiceUnmixedItemGroup>()?.Setup(Prefab);

            if (Prefab.TryGetComponent<ItemGroupView>(out var itemGroupView)) {
                Transform transform = itemGroupView.gameObject.transform.Find("Colour Blind");
                transform.localPosition = new Vector3(0, 0.6f, 0);
            }
        }

        public class TomatoJuiceUnmixedItemGroup : ItemGroupView {
            internal void Setup(GameObject prefab) {
                ComponentGroups = new List<ComponentGroup>() {
                    new ComponentGroup() {
                        Item = Refs.Water,
                        GameObject = GameObjectUtils.GetChildObject(prefab, "contents"),
                    },
                    new ComponentGroup() {
                        Item = Refs.TomatoSauce,
                        GameObject = GameObjectUtils.GetChildObject(prefab, "glass"),
                    },
                };

                ComponentLabels = new List<ColourBlindLabel>() {
                    new ColourBlindLabel() { Text = "Tj", Item = Refs.Water }
                };
            }
        }
    }
}