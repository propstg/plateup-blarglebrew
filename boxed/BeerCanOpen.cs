using BlargleBrew;
using KitchenData;
using KitchenLib.Colorblind;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace KitchenBlargleBrew {

    public class BeerCanOpen : CustomItem {

        public override GameObject Prefab => BlargleBrewMod.bundle.LoadAsset<GameObject>("BeerCanOpen");
        public override string UniqueNameID => "BlargleBrew - Beer Can Open";
        public override Item DirtiesTo => Refs.BeerCanEmpty;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;

        public override void OnRegister(GameDataObject gdo) {
            MaterialUtils.ApplyMaterial(Prefab, "metal", CommonMaterials.Can.metal);
            MaterialUtils.ApplyMaterial(Prefab, "painted", CommonMaterials.Can.paint);
            MaterialUtils.ApplyMaterial(Prefab, "foam", CommonMaterials.Can.foam);

            GameObject clonedColourBlind = ColorblindUtils.cloneColourBlindObjectAndAddToItem(gdo as Item);
            clonedColourBlind.transform.localPosition = new Vector3(0, 0.6f, 0);
            ColorblindUtils.getTextMeshProFromClonedObject(clonedColourBlind).text = "Lt";
        }
    }
}