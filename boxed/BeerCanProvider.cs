using BlargleBrew;
using KitchenData;
using KitchenLib.Utils;

namespace KitchenBlargleBrew {

    public class BeerCanProvider : AbstractBoxedBeerProvider {

        protected override string name => "Can";
        protected override string prefabName => "BeerCase";
        protected override int provides => GDOUtils.GetCustomGameDataObject<BeerCanClosed>().GameDataObject.ID;

        public override void OnRegister(Appliance gdo) {
            base.OnRegister(gdo);
            MaterialUtils.ApplyMaterial(Prefab, "box", CommonMaterials.Can.box);
            MaterialUtils.ApplyMaterial(Prefab, "metal", CommonMaterials.Can.metal);
            MaterialUtils.ApplyMaterial(Prefab, "painted", CommonMaterials.Can.paint);
        }
    }
}