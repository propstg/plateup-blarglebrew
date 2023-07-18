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

    class StoutBoot : CustomItemGroup<StoutBoot.WheatBeerWithOrangeItemGroupView> {

        private const string VFX_NAME = "Freezer Vapour";
        public override string UniqueNameID => "BlargleBrew - Stout Boot";
        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("BeerBoot");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.Large;
        public override Item DisposesTo => null;
        public override Item DirtiesTo => null;
        public override bool CanContainSide => false;
        public override int MaxOrderSharers => 4;

        public override List<ItemSet> Sets => new List<ItemSet>() {
            new ItemSet() {
                Max = 1,
                Min = 1,
                IsMandatory = true,
                Items = new List<Item>() {
                    Refs.EmptyBoot
                }
            },
            new ItemSet() {
                Max = 1,
                Min = 1,
                IsMandatory = true,
                Items = new List<Item>() {
                    Refs.BeerStout,
                }
            },
            new ItemSet() {
                Max = 1,
                Min = 1,
                Items = new List<Item>() {
                    Refs.BeerStout,
                }
            },
            new ItemSet() {
                Max = 1,
                Min = 1,
                Items = new List<Item>() {
                    Refs.BeerStout,
                }
            },
        };


        public override void OnRegister(ItemGroup gameDataObject) {
            MaterialUtils.ApplyMaterial(Prefab, "glass", CommonMaterials.Mug.glass);
            MaterialUtils.ApplyMaterial(Prefab, "layer1", CommonMaterials.Mug.stoutBeer);
            MaterialUtils.ApplyMaterial(Prefab, "layer2", CommonMaterials.Mug.stoutBeer);
            MaterialUtils.ApplyMaterial(Prefab, "layer3", CommonMaterials.Mug.stoutBeer);
            //MaterialUtils.ApplyMaterial(Prefab, "layer4", CommonMaterials.Mug.stoutFoam);

            GameObject vfxGameObject = new GameObject($"Beer VFX - {VFX_NAME}");
            VisualEffectAsset asset = Resources.FindObjectsOfTypeAll<VisualEffectAsset>().Where(vfx => vfx.name == VFX_NAME).FirstOrDefault();
            if (asset != default) {
                VisualEffect vfx = vfxGameObject.GetComponent<VisualEffect>();
                if (vfx == null) {
                    vfx = vfxGameObject.AddComponent<VisualEffect>();
                }
                vfx.visualEffectAsset = asset;

                vfxGameObject.transform.parent = Prefab.transform;
                vfxGameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                vfxGameObject.transform.localPosition = new Vector3(0f, 0.7f, 0f);
                vfxGameObject.transform.rotation = Quaternion.identity;
            }

            Prefab.GetComponent<WheatBeerWithOrangeItemGroupView>()?.Setup(Prefab);

            if (Prefab.TryGetComponent<ItemGroupView>(out var itemGroupView)) {
                Transform transform = itemGroupView.gameObject.transform.Find("Colour Blind");
                transform.localPosition = new Vector3(0, 0.6f, 0);
            }
        }

        public class WheatBeerWithOrangeItemGroupView : ItemGroupView {
            internal void Setup(GameObject prefab) {
                ComponentGroups = new List<ComponentGroup>() {
                    new ComponentGroup() {
                        Item = Refs.EmptyBoot,
                        GameObject = GameObjectUtils.GetChildObject(prefab, "glass")
                    },
                    new ComponentGroup() {
                        Item = Refs.BeerStout,
                        Objects = new List<GameObject>() {
                            GameObjectUtils.GetChildObject(prefab, "layer1"),
                            GameObjectUtils.GetChildObject(prefab, "layer2"),
                            GameObjectUtils.GetChildObject(prefab, "layer3"),
                        }
                    },
                };

                ComponentLabels = new List<ColourBlindLabel>() {
                    new ColourBlindLabel() { Text = "St", Item = Refs.BeerStout }
                };
            }
        }
    }
}