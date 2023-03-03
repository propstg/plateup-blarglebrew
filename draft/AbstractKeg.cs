using KitchenBlargleBrew;
using KitchenBlargleBrew.kegerator;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace BlargleBrew.draft {

    public abstract class AbstractKeg : CustomItem {

        protected abstract string name { get; }
        protected abstract string labelMaterial { get; }
        protected abstract string prefabName { get; }
        protected abstract int colorId { get; }

        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>(prefabName);
        public override string UniqueNameID => $"BlargleBrew - {name} Keg";
        public override bool AllowSplitMerging => false;
        public override float SplitSpeed => 1f;
        public override int SplitCount => 3;
        public override Item DisposesTo => Refs.EmptyKeg;
        public override List<Item> SplitDepletedItems => new List<Item>() { Refs.EmptyKeg };
        public override List<IItemProperty> Properties => new List<IItemProperty>() {
            new CKegColor { colorId = this.colorId }
        };

        public override void OnRegister(GameDataObject gdo) {
            MaterialUtils.ApplyMaterial(Prefab, "keg", new Material[] { MaterialUtils.GetExistingMaterial("Metal- Shiny") });
            MaterialUtils.ApplyMaterial(Prefab, "label", new Material[] { MaterialUtils.GetExistingMaterial(labelMaterial) });
        }
    }
}