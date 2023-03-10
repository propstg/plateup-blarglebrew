using BlargleBrew;
using KitchenData;
using KitchenLib.Colorblind;
using KitchenLib.Utils;
using UnityEngine;

namespace KitchenBlargleBrew {

    public class BeerCanClosed : AbstractBeerClosed {

        protected override string name => "Can";
        protected override string prefabName => "BeerCanClosed";
        protected override Item opensTo => Refs.BeerCanOpen;
        public override Appliance DedicatedProvider => Refs.BeerCanProvider;

        public override void OnRegister(GameDataObject gdo) {
            MaterialUtils.ApplyMaterial(Prefab, "metal", CommonMaterials.Can.metal);
            MaterialUtils.ApplyMaterial(Prefab, "painted", CommonMaterials.Can.paint);

            GameObject clonedColourBlind = ColorblindUtils.cloneColourBlindObjectAndAddToItem(gdo as Item);
            clonedColourBlind.transform.localPosition = new Vector3(0, 0.9f, 0);
            ColorblindUtils.getTextMeshProFromClonedObject(clonedColourBlind).text = "Lt";
        }
    }
}