using Kitchen;
using KitchenBlargleBrew;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;
using static KitchenData.ItemGroup;

namespace BlargleBrew.draft {

    class StoutFloat : CustomItemGroup<StoutFloat.StoutFloatItemGroupView> {

        public override string UniqueNameID => "BlargleBrew - Stout FLaot";
        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("StoutFloat");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.Small;
        public override Item DisposesTo => null;
        public override Item DirtiesTo => null;
        public override bool CanContainSide => false;

        public override List<ItemSet> Sets => new List<ItemSet>() {
            new ItemSet() {
                Max = 1,
                Min = 1,
                IsMandatory = true,
                Items = new List<Item>() {
                    Refs.BeerStout
                }
            },
            new ItemSet() {
                Max = 1,
                Min = 1,
                IsMandatory = true,
                Items = new List<Item>() {
                    Refs.VanillaIceCream,
                }
            },
        };


        public override void OnRegister(ItemGroup gameDataObject) {
            MaterialUtils.ApplyMaterial(Prefab, "glass", CommonMaterials.StoutFloat.glass);
            MaterialUtils.ApplyMaterial(Prefab, "beer", CommonMaterials.StoutFloat.beer);
            MaterialUtils.ApplyMaterial(Prefab, "foam", CommonMaterials.StoutFloat.foam);
            MaterialUtils.ApplyMaterial(Prefab, "icecream-1", CommonMaterials.StoutFloat.iceCream);
            MaterialUtils.ApplyMaterial(Prefab, "icecream-2", CommonMaterials.StoutFloat.iceCream);
            MaterialUtils.ApplyMaterial(Prefab, "icecream-3", CommonMaterials.StoutFloat.iceCream);

            Prefab.GetComponent<StoutFloatItemGroupView>()?.Setup(Prefab);

            if (Prefab.TryGetComponent<ItemGroupView>(out var itemGroupView)) {
                Transform transform = itemGroupView.gameObject.transform.Find("Colour Blind");
                transform.localPosition = new Vector3(0, 0.3f, 0);
            }
        }

        public class StoutFloatItemGroupView : ItemGroupView {
            internal void Setup(GameObject prefab) {
                ComponentGroups = new List<ComponentGroup>() {
                    new ComponentGroup() {
                        Item = Refs.BeerStout,
                        Objects = new List<GameObject> {
                            GameObjectUtils.GetChildObject(prefab, "glass"),
                            GameObjectUtils.GetChildObject(prefab, "beer"),
                            GameObjectUtils.GetChildObject(prefab, "foam"),
                        },
                        DrawAll = true,
                    },
                    new ComponentGroup() {
                        Item = Refs.VanillaIceCream,
                        Objects = new List<GameObject> {
                            GameObjectUtils.GetChildObject(prefab, "icecream-1"),
                            GameObjectUtils.GetChildObject(prefab, "icecream-2"),
                            GameObjectUtils.GetChildObject(prefab, "icecream-3"),
                        },
                        DrawAll = true,
                    },
                };

                ComponentLabels = new List<ColourBlindLabel>() {
                    new ColourBlindLabel() { Text = "St", Item = Refs.BeerStout },
                    new ColourBlindLabel() { Text = "V", Item = Refs.VanillaIceCream },
                };
            }
        }
    }
}