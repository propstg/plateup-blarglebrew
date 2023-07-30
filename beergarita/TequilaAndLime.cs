using Kitchen;
using KitchenBlargleBrew;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;
using static KitchenData.ItemGroup;

namespace BlargleBrew.beergarita {

    class TequilaAndLime : CustomItemGroup<TequilaAndLime.TequilaAndLimeItemGroup> {

        public override string UniqueNameID => "BlargleBrew - Tequila and Lime";
        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("TequilaAndLime");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.Medium;
        public override Item DisposesTo => null;
        public override Item DirtiesTo => null;
        public override bool CanContainSide => false;

        public override List<ItemSet> Sets => new List<ItemSet>() {
            new ItemSet() {
                Max = 1,
                Min = 1,
                IsMandatory = true,
                Items = new List<Item>() {
                    Refs.TequilaShot,
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
        };


        public override void OnRegister(ItemGroup gameDataObject) {
            MaterialUtils.ApplyMaterial(Prefab, "glass", CommonMaterials.Beergarita.glass);
            MaterialUtils.ApplyMaterial(Prefab, "lime", CommonMaterials.Beergarita.limeJuice);
            MaterialUtils.ApplyMaterial(Prefab, "straw", CommonMaterials.Beergarita.straw);
            MaterialUtils.ApplyMaterial(Prefab, "tequila", CommonMaterials.Beergarita.tequila);


            Prefab.GetComponent<TequilaAndLimeItemGroup>()?.Setup(Prefab);

            if (Prefab.TryGetComponent<ItemGroupView>(out var itemGroupView)) {
                Transform transform = itemGroupView.gameObject.transform.Find("Colour Blind");
                transform.localPosition = new Vector3(0, 0.4f, 0);
            }
        }

        public class TequilaAndLimeItemGroup : ItemGroupView {
            internal void Setup(GameObject prefab) {
                ComponentGroups = new List<ComponentGroup>() {
                    new ComponentGroup() {
                        Item = Refs.TequilaShot,
                        Objects = new List<GameObject> {
                            GameObjectUtils.GetChildObject(prefab, "glass"),
                            GameObjectUtils.GetChildObject(prefab, "straw"),
                            GameObjectUtils.GetChildObject(prefab, "tequila"),
                        },
                        DrawAll = true,
                    },
                    new ComponentGroup() {
                        Item = Refs.LimeJuice,
                        GameObject = GameObjectUtils.GetChildObject(prefab, "lime"),
                    },
                };

                ComponentLabels = new List<ColourBlindLabel>() {
                    new ColourBlindLabel() { Text = "Te", Item = Refs.TequilaShot },
                    new ColourBlindLabel() { Text = "Li", Item = Refs.LimeJuice },
                };
            }
        }
    }
}