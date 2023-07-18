using Kitchen;
using KitchenBlargleBrew;
using KitchenData;
using KitchenLib.Colorblind;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;
using static KitchenData.ItemGroup;

namespace BlargleBrew.boot {

    class Michelada : CustomItemGroup<Michelada.MicheladaItemGroupView> {

        public override string UniqueNameID => "BlargleBrew - Michelada";
        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("Michelada");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.ExtraLarge;
        public override Item DisposesTo => null;
        public override Item DirtiesTo => null;
        public override bool CanContainSide => false;

        public override List<ItemSet> Sets => new List<ItemSet>() {
            new ItemSet() {
                Max = 1,
                Min = 1,
                IsMandatory = true,
                Items = new List<Item>() {
                    Refs.BeerBottleOpen,
                }
            },
            new ItemSet() {
                Max = 1,
                Min = 1,
                IsMandatory = true,
                Items = new List<Item>() {
                    Refs.LimeJuice,
                }
            },
            new ItemSet() {
                Max = 1,
                Min = 1,
                Items = new List<Item>() {
                    Refs.TomatoSauce,
                }
            },
            new ItemSet() {
                Max = 1,
                Min = 0,
                Items = new List<Item>() {
                    Refs.Pepper,
                }
            },
        };


        public override void OnRegister(ItemGroup gameDataObject) {
            MaterialUtils.ApplyMaterial(Prefab, "glass", CommonMaterials.Michelada.glass);
            MaterialUtils.ApplyMaterial(Prefab, "beer", CommonMaterials.Michelada.limeJuice);
            MaterialUtils.ApplyMaterial(Prefab, "lime", CommonMaterials.Michelada.beer);
            MaterialUtils.ApplyMaterial(Prefab, "sauce", CommonMaterials.tomatoFlesh);
            MaterialUtils.ApplyMaterial(Prefab, "rim", CommonMaterials.snow);
            MaterialUtils.ApplyMaterial(Prefab, "pepper-body", CommonMaterials.Michelada.pepperBody);
            MaterialUtils.ApplyMaterial(Prefab, "pepper-stem", CommonMaterials.Michelada.pepperStem);

            Prefab.GetComponent<MicheladaItemGroupView>()?.Setup(Prefab);

            if (Prefab.TryGetComponent<ItemGroupView>(out var itemGroupView)) {
                Transform transform = itemGroupView.gameObject.transform.Find("Colour Blind");
                transform.localPosition = new Vector3(0, 0.6f, 0);
            }
        }

        public class MicheladaItemGroupView : ItemGroupView {
            internal void Setup(GameObject prefab) {
                ComponentGroups = new List<ComponentGroup>() {
                    new ComponentGroup() {
                        Item = Refs.BeerBottleOpen,
                        Objects = new List<GameObject> {
                            GameObjectUtils.GetChildObject(prefab, "glass"),
                            GameObjectUtils.GetChildObject(prefab, "beer"),
                            GameObjectUtils.GetChildObject(prefab, "rim"),
                        },
                        DrawAll = true,
                    },
                    new ComponentGroup() {
                        Item = Refs.LimeJuice,
                        GameObject = GameObjectUtils.GetChildObject(prefab, "lime"),
                    },
                    new ComponentGroup() {
                        Item = Refs.TomatoSauce,
                        GameObject = GameObjectUtils.GetChildObject(prefab, "sauce"),
                    },
                    new ComponentGroup() {
                        Item = Refs.Pepper,
                        Objects = new List<GameObject> {
                            GameObjectUtils.GetChildObject(prefab, "pepper-body"),
                            GameObjectUtils.GetChildObject(prefab, "pepper-stem"),
                        },
                        DrawAll = true,
                    },
                };

                ComponentLabels = new List<ColourBlindLabel>() {
                    new ColourBlindLabel() { Text = "Pi", Item = Refs.BeerBottleOpen },
                    new ColourBlindLabel() { Text = "Li", Item = Refs.LimeJuice },
                    new ColourBlindLabel() { Text = "T", Item = Refs.TomatoSauce },
                    new ColourBlindLabel() { Text = "C", Item = Refs.Pepper }
                };
            }
        }
    }
}