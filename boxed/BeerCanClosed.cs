using BlargleBrew;
using KitchenData;
using KitchenLib.Utils;

namespace KitchenBlargleBrew {

    public class BeerCanClosed : AbstractBeerClosed {

        protected override string name => "Can";
        protected override string prefabName => "BeerCanClosed";
        protected override Item opensTo => Refs.BeerCanOpen;
        public override Appliance DedicatedProvider => Refs.BeerCanProvider;
        public override string ColourBlindTag => "Lt";

        public override void OnRegister(GameDataObject gdo) {
            MaterialUtils.ApplyMaterial(Prefab, "metal", CommonMaterials.Can.metal);
            MaterialUtils.ApplyMaterial(Prefab, "painted", CommonMaterials.Can.paint);
        }
    }
}