using BlargleBrew;
using KitchenData;
using KitchenLib.Utils;

namespace KitchenBlargleBrew {

    public class BeerBottleClosed : AbstractBeerClosed {

        protected override string name => "Bottle";
        protected override string prefabName => "BeerBottleClosed";
        protected override Item opensTo => Refs.BeerBottleOpen;
        public override Appliance DedicatedProvider => Refs.BeerBottleProvider;
        public override string ColourBlindTag => "Pil";

        public override void OnRegister(GameDataObject gdo) {
            MaterialUtils.ApplyMaterial(Prefab, "glass", CommonMaterials.Bottle.glass);
            MaterialUtils.ApplyMaterial(Prefab, "lid", CommonMaterials.Bottle.lid);
            MaterialUtils.ApplyMaterial(Prefab, "liquid", CommonMaterials.Bottle.liquid);
        }
    }
}