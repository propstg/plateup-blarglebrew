using BlargleBrew;
using KitchenData;
using KitchenLib.Colorblind;
using KitchenLib.Utils;
using UnityEngine;

namespace KitchenBlargleBrew {

    public class BeerBottleClosed : AbstractBeerClosed {

        protected override string name => "Bottle";
        protected override string prefabName => "BeerBottleClosed";
        protected override Item opensTo => Refs.BeerBottleOpen;
        public override Appliance DedicatedProvider => Refs.BeerBottleProvider;

        public override void OnRegister(GameDataObject gdo) {
            MaterialUtils.ApplyMaterial(Prefab, "glass", CommonMaterials.Bottle.glass);
            MaterialUtils.ApplyMaterial(Prefab, "lid", CommonMaterials.Bottle.lid);
            MaterialUtils.ApplyMaterial(Prefab, "liquid", CommonMaterials.Bottle.liquid);

            GameObject clonedColourBlind = ColorblindUtils.cloneColourBlindObjectAndAddToItem(gdo as Item);
            clonedColourBlind.transform.localPosition = new Vector3(0, 0.6f, 0);
            ColorblindUtils.getTextMeshProFromClonedObject(clonedColourBlind).text = "Pil";
        }
    }
}