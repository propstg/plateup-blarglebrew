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

    class WheatBeerWithOrange : CustomItemGroup<WheatBeerWithOrange.WheatBeerWithOrangeItemGroupView> {

        private const string VFX_NAME = "Freezer Vapour";
        public override string UniqueNameID => "BlargleBrew - Mug Wheat with Orange";
        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("MugWithOrange");
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
                    Refs.BeerWheat
                }
            },
            new ItemSet() {
                Max = 1,
                Min = 1,
                IsMandatory = true,
                Items = new List<Item>() {
                    Refs.MandarinSlice,
                }
            },
        };


        public override void OnRegister(ItemGroup gameDataObject) {
            MaterialUtils.ApplyMaterial(Prefab, "glass", CommonMaterials.Mug.glass);
            if (BlargleBrewMod.IsGreenBeerActive) {
                MaterialUtils.ApplyMaterial(Prefab, "beer", CommonMaterials.wheatGreen);
            } else {
                MaterialUtils.ApplyMaterial(Prefab, "beer", CommonMaterials.Mug.wheatBeer);
                MaterialUtils.ApplyMaterial(Prefab, "foam", CommonMaterials.Mug.wheatFoam);
            }
            MaterialUtils.ApplyMaterial(Prefab, "orange", CommonMaterials.Mug.orange);

            GameObject clonedColourBlind = ColorblindUtils.cloneColourBlindObjectAndAddToItem(gameDataObject);
            clonedColourBlind.transform.localPosition = new Vector3(0, 0.2f, 0);
            ColorblindUtils.getTextMeshProFromClonedObject(clonedColourBlind).text = "WhO";

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
                vfxGameObject.transform.localPosition = Vector3.zero;
                vfxGameObject.transform.rotation = Quaternion.identity;
            }
        }

        public class WheatBeerWithOrangeItemGroupView : ItemGroupView {
            internal void Setup(GameObject prefab) {
                ComponentGroups = new List<ComponentGroup>() {
                    new ComponentGroup() {
                        Item = Refs.BeerWheat,
                        Objects = new List<GameObject>() {
                            GameObjectUtils.GetChildObject(prefab, "beer"),
                            GameObjectUtils.GetChildObject(prefab, "foam"),
                            GameObjectUtils.GetChildObject(prefab, "glass"),
                        },
                        DrawAll = true
                    },
                    new ComponentGroup() {
                        Item = Refs.MandarinSlice,
                        Objects = new List<GameObject>() {
                            GameObjectUtils.GetChildObject(prefab, "orange"),
                        }
                    },
                };
            }
        }
    }
}