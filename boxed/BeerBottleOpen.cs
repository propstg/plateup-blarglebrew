using BlargleBrew;
using KitchenData;
using KitchenLib.Colorblind;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace KitchenBlargleBrew {

    public class BeerBottleOpen : CustomItem {

        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("BeerBottleOpen");
        public override string UniqueNameID => "BlargleBrew - Beer Bottle Open";
        public override Item DirtiesTo => Refs.BeerBottleEmpty;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;

        public override void OnRegister(GameDataObject gdo) {
            MaterialUtils.ApplyMaterial(Prefab, "glass", CommonMaterials.Bottle.glass);
            MaterialUtils.ApplyMaterial(Prefab, "liquid", CommonMaterials.Bottle.liquid);

            GameObject clonedColourBlind = ColorblindUtils.cloneColourBlindObjectAndAddToItem(gdo as Item);
            clonedColourBlind.transform.localPosition = new Vector3(0, 0.6f, 0);
            ColorblindUtils.getTextMeshProFromClonedObject(clonedColourBlind).text = "Pil";
        }
    }
}