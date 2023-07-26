using Kitchen;
using KitchenBlargleBrew;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace BlargleBrew.michelada {

    public class TomatoJuicePitcher : CustomItem {

        public override string UniqueNameID => "Tomato Juice Pitcher";
        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("TomatoJuicePitcher");
        public override bool AllowSplitMerging => false;
        public override float SplitSpeed => 1f;
        public override int SplitCount => 5;
        public override Item SplitSubItem => Refs.TomatoJuice;
        public override Item DisposesTo => null;
        public override bool PreventExplicitSplit => false;
        public override string ColourBlindTag => "Tj";

        public override void OnRegister(Item gameDataObject) {
            MaterialUtils.ApplyMaterial(Prefab, "glass", CommonMaterials.TomatoJuice.glass);
            MaterialUtils.ApplyMaterial(Prefab, "contents-1", CommonMaterials.TomatoJuice.contents);
            MaterialUtils.ApplyMaterial(Prefab, "contents-2", CommonMaterials.TomatoJuice.contents);
            MaterialUtils.ApplyMaterial(Prefab, "contents-3", CommonMaterials.TomatoJuice.contents);
            MaterialUtils.ApplyMaterial(Prefab, "contents-4", CommonMaterials.TomatoJuice.contents);
            MaterialUtils.ApplyMaterial(Prefab, "contents-5", CommonMaterials.TomatoJuice.contents);

            if (!Prefab.HasComponent<ObjectsSplittableView>()) {
                var splittable = Prefab.AddComponent<ObjectsSplittableView>();
                var items = new List<GameObject>() {
                    Prefab.GetChild("contents-1"),
                    Prefab.GetChild("contents-2"),
                    Prefab.GetChild("contents-3"),
                    Prefab.GetChild("contents-4"),
                    Prefab.GetChild("contents-5")
                };
                ReflectionUtils.GetField<ObjectsSplittableView>("Objects").SetValue(splittable, items);
            }

            if (Prefab.TryGetComponent<ItemGroupView>(out var itemGroupView)) {
                Transform transform = itemGroupView.gameObject.transform.Find("Colour Blind");
                transform.localPosition = new Vector3(0, 0.6f, 0);
            }
        }
    }
}