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

namespace BlargleBrew.boot {

    class PickledEgg : CustomItemGroup<PickledEgg.PickledEggItemGroupView> {

        public override string UniqueNameID => "BlargleBrew - Pickled Egg";
        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("PickledEgg");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.SideSmall;
        public override Item DisposesTo => null;
        public override Item DirtiesTo => null;
        public override bool CanContainSide => false;

        public override List<ItemSet> Sets => new List<ItemSet>() {
            new ItemSet() {
                Max = 1,
                Min = 1,
                IsMandatory = true,
                Items = new List<Item>() {
                    Refs.Vinegar
                }
            },
            new ItemSet() {
                Max = 1,
                Min = 1,
                IsMandatory = true,
                Items = new List<Item>() {
                    Refs.Egg,
                }
            },
        };


        public override void OnRegister(ItemGroup gameDataObject) {
            MaterialUtils.ApplyMaterial(Prefab, "glass", CommonMaterials.Mug.glass);
            MaterialUtils.ApplyMaterial(Prefab, "eggs", CommonMaterials.snow);

            Prefab.GetComponent<PickledEggItemGroupView>()?.Setup(Prefab);

            if (Prefab.TryGetComponent<ItemGroupView>(out var itemGroupView)) {
                GameObject clonedColourBlind = ColorblindUtils.cloneColourBlindObjectAndAddToItem(gameDataObject);
                ColorblindUtils.setColourBlindLabelObjectOnItemGroupView(itemGroupView, clonedColourBlind);
            }
        }

        public class PickledEggItemGroupView : ItemGroupView {
            internal void Setup(GameObject prefab) {
                ComponentGroups = new List<ComponentGroup>() {
                    new ComponentGroup() {
                        Item = Refs.Vinegar,
                        GameObject = GameObjectUtils.GetChildObject(prefab, "glass")
                    },
                    new ComponentGroup() {
                        Item = Refs.Egg,
                        Objects = new List<GameObject>() {
                            GameObjectUtils.GetChildObject(prefab, "eggs"),
                        }
                    },
                };

                ComponentLabels = new List<ColourBlindLabel>() {
                    new ColourBlindLabel() { Text = "V", Item = Refs.Vinegar },
                    new ColourBlindLabel() { Text = "E", Item = Refs.Egg }
                };
            }
        }
    }
}