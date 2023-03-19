using KitchenBlargleBrew;
using KitchenBlargleBrew.kegerator;
using KitchenData;
using KitchenLib.Colorblind;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace BlargleBrew.draft {

    public abstract class AbstractKeg : CustomItem {

        protected abstract string name { get; }
        protected abstract Material[] labelMaterial { get; }
        protected abstract string prefabName { get; }
        protected abstract int colorId { get; }
        protected abstract string hackyColorblindLabel { get; }

        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>(prefabName);
        public override string UniqueNameID => $"BlargleBrew - {name} Keg";
        public override bool AllowSplitMerging => false;
        public override float SplitSpeed => 1f;
        public override int SplitCount => 5;
        public override Item DisposesTo => Refs.EmptyKeg;
        public override List<Item> SplitDepletedItems => new List<Item>() { Refs.EmptyKeg };
        public override List<IItemProperty> Properties => new List<IItemProperty>() {
            new CKegColor { colorId = this.colorId },
            new CKeg { },
        };

        public override void OnRegister(Item gdo) {
            MaterialUtils.ApplyMaterial(Prefab, "keg", CommonMaterials.Keg.metal);
            MaterialUtils.ApplyMaterial(Prefab, "label", labelMaterial);

            GameObject clonedColourBlind = ColorblindUtils.cloneColourBlindObjectAndAddToItem(gdo as Item);
            clonedColourBlind.transform.localPosition = new Vector3(0, 0.9f, 0);
            ColorblindUtils.getTextMeshProFromClonedObject(clonedColourBlind).text = hackyColorblindLabel;
        }
    }
}