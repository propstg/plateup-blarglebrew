using BlargleBrew;
using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
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
                }
            },
            new ItemSet() {
                Max = 1,
                Min = 1,
                Items = new List<Item>() {
                    Refs.PumpkinPieces,
                }
            },
        };

        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess> {
            new Item.ItemProcess {
                Duration = 10f,
                IsBad = false,
                Process = Refs.CookProcess,
                Result = Refs.PumpkinMashWithTrash,
            }
        };

        public override void OnRegister(ItemGroup gameDataObject) {
            MaterialUtils.ApplyMaterial(Prefab, "pot", CommonMaterials.PumpkinBrew.pot);
            MaterialUtils.ApplyMaterial(Prefab, "liquid", CommonMaterials.PumpkinBrew.pumpkinExtractDiluted);
            MaterialUtils.ApplyMaterial(Prefab, "bag/contents", CommonMaterials.Keg.pumpkinLabel);
            MaterialUtils.ApplyMaterial(Prefab, "bag/clip", CommonMaterials.Keg.pumpkinLabel);
            MaterialUtils.ApplyMaterial(Prefab, "bag/bag", CommonMaterials.Hops.bag);

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
                        Item = Refs.PumpkinPieces,
                        Objects = new List<GameObject> {
                            GameObjectUtils.GetChildObject(prefab, "bag/contents"),
                            GameObjectUtils.GetChildObject(prefab, "bag/clip"),
                            GameObjectUtils.GetChildObject(prefab, "bag/bag"),
                        },
                        DrawAll = true,
                    },
                };

                ComponentLabels = new List<ColourBlindLabel>() {
                    new ColourBlindLabel() { Text = "Pe", Item = Refs.PumpkinExtractCanOpen},
                    new ColourBlindLabel() { Text = "P", Item = Refs.PumpkinPieces},
                };
            }
        }
    }
}