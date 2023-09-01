using BlargleBrew;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenBlargleBrew.draft.extract {

    public class ExtractBoiledWithTrash : CustomItem {

        public override string UniqueNameID => "ExtractBoiledWithTrash";
        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("ExtractBoiledWithTrash");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.None;
        public override ItemValue ItemValue => ItemValue.None;
        public override string ColourBlindTag => "ExH";


        public override float SplitSpeed => 1f;
        public override int SplitCount => 1;
        public override Item DisposesTo => Refs.Pot;
        public override List<Item> SplitDepletedItems => new List<Item>() { Refs.ExtractBoiled };
        public override Item SplitSubItem => Refs.HopsBag; // TODO empty hops bag
        public override bool AllowSplitMerging => false;


        public override void OnRegister(Item item) {
            MaterialUtils.ApplyMaterial(Prefab, "pot", CommonMaterials.ExtractStout.pot);
            MaterialUtils.ApplyMaterial(Prefab, "liquid", CommonMaterials.ExtractStout.extractDiluted);
            MaterialUtils.ApplyMaterial(Prefab, "foam", CommonMaterials.ExtractStout.foam);
            MaterialUtils.ApplyMaterial(Prefab, "bag/contents", CommonMaterials.Hops.hops);
            MaterialUtils.ApplyMaterial(Prefab, "bag/clip", CommonMaterials.Hops.clip);
            MaterialUtils.ApplyMaterial(Prefab, "bag/bag", CommonMaterials.Hops.bag);
        }
    }
}