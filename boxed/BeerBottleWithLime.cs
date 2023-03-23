using Kitchen;
using KitchenBlargleBrew;
using KitchenData;
using KitchenLib.Colorblind;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.VFX;
using static KitchenData.ItemGroup;

namespace BlargleBrew.draft {

    class BeerBottleWithLime : CustomItemGroup<BeerBottleWithLime.BeerBottleWithLimeItemGroupView> {

        public override string UniqueNameID => "BlargleBrew - Beer Bottle With Lime";
        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("BeerBottleLime");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.Large;
        public override Item DisposesTo => null;
        public override Item DirtiesTo => Refs.BeerBottleEmpty;
        public override bool CanContainSide => false;

        public override List<ItemSet> Sets => new List<ItemSet>() {
            new ItemSet() {
                Max = 1,
                Min = 1,
                IsMandatory = true,
                Items = new List<Item>() {
                    Refs.BeerBottleOpen
                }
            },
            new ItemSet() {
                Max = 1,
                Min = 1,
                IsMandatory = true,
                Items = new List<Item>() {
                    Refs.LimeChopped,
                }
            },
        };


        public override void OnRegister(ItemGroup gameDataObject) {
            MaterialUtils.ApplyMaterial(Prefab, "glass", CommonMaterials.Bottle.glass);
            MaterialUtils.ApplyMaterial(Prefab, "liquid", CommonMaterials.Bottle.liquid);
            MaterialUtils.ApplyMaterial(Prefab, "lime", CommonMaterials.Bottle.lime);

            GameObject clonedColourBlind = ColorblindUtils.cloneColourBlindObjectAndAddToItem(gameDataObject);
            clonedColourBlind.transform.localPosition = new Vector3(0, 0.6f, 0);
            ColorblindUtils.getTextMeshProFromClonedObject(clonedColourBlind).text = "PilLi";
        }

        public class BeerBottleWithLimeItemGroupView : ItemGroupView {
            internal void Setup(GameObject prefab) {
                ComponentGroups = new List<ComponentGroup>() {
                    new ComponentGroup() {
                        Item = Refs.BeerBottleOpen,
                        Objects = new List<GameObject>() {
                            GameObjectUtils.GetChildObject(prefab, "glass"),
                            GameObjectUtils.GetChildObject(prefab, "liquid"),
                        },
                        DrawAll = true
                    },
                    new ComponentGroup() {
                        Item = Refs.LimeChopped,
                        Objects = new List<GameObject>() {
                            GameObjectUtils.GetChildObject(prefab, "lime"),
                        }
                    },
                };
            }
        }
    }
}