using BlargleBrew;
using KitchenData;
using KitchenLib.Utils;

namespace KitchenBlargleBrew {

    public class BeerBottleProvider : AbstractBoxedBeerProvider {

        protected override string name => "Bottle";
        protected override string prefabName => "TwelvePack";
        protected override int provides => GDOUtils.GetCustomGameDataObject<BeerBottleClosed>().GameDataObject.ID;

        public override void OnRegister(GameDataObject gdo) {
            base.OnRegister(gdo);
            MaterialUtils.ApplyMaterial(Prefab, "box", CommonMaterials.Bottle.box);
            MaterialUtils.ApplyMaterial(Prefab, "glass", CommonMaterials.Bottle.glass);
            MaterialUtils.ApplyMaterial(Prefab, "lid", CommonMaterials.Bottle.lid);
            MaterialUtils.ApplyMaterial(Prefab, "liquid", CommonMaterials.Bottle.liquid);
        }
    }
}