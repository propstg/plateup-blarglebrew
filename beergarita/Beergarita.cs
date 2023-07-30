using Kitchen;
using KitchenBlargleBrew;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;
using static KitchenData.ItemGroup;

namespace BlargleBrew.beergarita {

    class Beergarita : CustomItemGroup<Beergarita.BeergaritaItemGroup> {

        public override string UniqueNameID => "BlargleBrew - Beergarita";
        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("Beergarita");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.Large;
        public override Item DisposesTo => null;
        public override Item DirtiesTo => null;
        public override bool CanContainSide => false;

        public override List<ItemSet> Sets => new List<ItemSet>() {
            new ItemSet() {
                Max = 1,
                Min = 1,
                IsMandatory = true,
                Items = new List<Item>() {
                    Refs.TequilaAndLime,
                }
            },
            new ItemSet() {
                Max = 1,
                Min = 1,
                IsMandatory = true,
                Items = new List<Item>() {
                    Refs.BeerBottleOpen,
                }
            },
        };


        public override void OnRegister(ItemGroup gameDataObject) {
            MaterialUtils.ApplyMaterial(Prefab, "glass", CommonMaterials.Beergarita.glass);
            MaterialUtils.ApplyMaterial(Prefab, "lime", CommonMaterials.Beergarita.limeJuice);
            MaterialUtils.ApplyMaterial(Prefab, "straw", CommonMaterials.Beergarita.straw);
            MaterialUtils.ApplyMaterial(Prefab, "tequila", CommonMaterials.Beergarita.tequila);
            MaterialUtils.ApplyMaterial(Prefab, "bottle", CommonMaterials.Bottle.glass);
            MaterialUtils.ApplyMaterial(Prefab, "bottle-holder", CommonMaterials.Beergarita.bottleHolder);
            MaterialUtils.ApplyMaterial(Prefab, "bottle-liquid", CommonMaterials.Bottle.liquid);

            Prefab.GetComponent<BeergaritaItemGroup>()?.Setup(Prefab);

            if (Prefab.TryGetComponent<ItemGroupView>(out var itemGroupView)) {
                Transform transform = itemGroupView.gameObject.transform.Find("Colour Blind");
                transform.localPosition = new Vector3(0, 0.4f, 0);
            }
        }

        public class BeergaritaItemGroup : ItemGroupView {
            internal void Setup(GameObject prefab) {
                ComponentGroups = new List<ComponentGroup>() {
                    new ComponentGroup() {
                        Item = Refs.TequilaAndLime,
                        Objects = new List<GameObject> {
                            GameObjectUtils.GetChildObject(prefab, "glass"),
                            GameObjectUtils.GetChildObject(prefab, "straw"),
                            GameObjectUtils.GetChildObject(prefab, "tequila"),
                            GameObjectUtils.GetChildObject(prefab, "lime"),
                        },
                        DrawAll = true,
                    },
                    new ComponentGroup() {
                        Item = Refs.BeerBottleOpen,
                        Objects = new List<GameObject> {
                            GameObjectUtils.GetChildObject(prefab, "bottle"),
                            GameObjectUtils.GetChildObject(prefab, "bottle-holder"),
                            GameObjectUtils.GetChildObject(prefab, "bottle-liquid"),
                        },
                        DrawAll = true,
                    },
                };

                ComponentLabels = new List<ColourBlindLabel>() {
                    new ColourBlindLabel() { Text = "TeLi", Item = Refs.TequilaAndLime },
                    new ColourBlindLabel() { Text = "Pil", Item = Refs.BeerBottleOpen },
                };
            }
        }
    }
}