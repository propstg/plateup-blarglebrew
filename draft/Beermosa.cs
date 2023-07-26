using Kitchen;
using KitchenBlargleBrew;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;
using static KitchenData.ItemGroup;

namespace BlargleBrew.draft {

    class Beermosa : CustomItemGroup<Beermosa.BeermosaItemGroupView> {

        private const string VFX_NAME = "Freezer Vapour";
        public override string UniqueNameID => "BlargleBrew - Beermosa";
        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("Beermosa");
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
                    Refs.BeerWheat
                }
            },
            new ItemSet() {
                Max = 1,
                Min = 1,
                IsMandatory = true,
                Items = new List<Item>() {
                    Refs.OrangeJuice,
                }
            },
        };


        public override void OnRegister(ItemGroup gameDataObject) {
            MaterialUtils.ApplyMaterial(Prefab, "glass", CommonMaterials.Beermosa.glass);
            MaterialUtils.ApplyMaterial(Prefab, "beer", CommonMaterials.Beermosa.wheatBeer);
            MaterialUtils.ApplyMaterial(Prefab, "lime", CommonMaterials.Beermosa.wheatBeer);
            MaterialUtils.ApplyMaterial(Prefab, "sauce", CommonMaterials.Beermosa.orangeJuice);

            Prefab.GetComponent<BeermosaItemGroupView>()?.Setup(Prefab);

            if (Prefab.TryGetComponent<ItemGroupView>(out var itemGroupView)) {
                Transform transform = itemGroupView.gameObject.transform.Find("Colour Blind");
                transform.localPosition = new Vector3(0, 0.6f, 0);
            }
        }

        public class BeermosaItemGroupView : ItemGroupView {
            internal void Setup(GameObject prefab) {
                ComponentGroups = new List<ComponentGroup>() {
                    new ComponentGroup() {
                        Item = Refs.BeerWheat,
                        Objects = new List<GameObject> {
                            GameObjectUtils.GetChildObject(prefab, "glass"),
                            GameObjectUtils.GetChildObject(prefab, "beer"),
                            GameObjectUtils.GetChildObject(prefab, "lime"),
                        },
                        DrawAll = true,
                    },
                    new ComponentGroup() {
                        Item = Refs.OrangeJuice,
                        GameObject = GameObjectUtils.GetChildObject(prefab, "sauce"),
                    },
                };

                ComponentLabels = new List<ColourBlindLabel>() {
                    new ColourBlindLabel() { Text = "Wh", Item = Refs.BeerWheat },
                    new ColourBlindLabel() { Text = "Oj", Item = Refs.OrangeJuice },
                };
            }
        }
    }
}