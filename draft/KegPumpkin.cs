using KitchenBlargleBrew;
using KitchenData;
using UnityEngine;

namespace BlargleBrew.draft {

    public class KegPumpkin : AbstractKeg {

        protected override string name => "Pumpkin Keg";
        protected override Material[] labelMaterial => CommonMaterials.Keg.pumpkinLabel;
        protected override Material[] kegMaterial => CommonMaterials.Keg.pumpkinBody;
        protected override string prefabName => "PumpkinKeg";
        protected override int colorId => 3;
        protected override string hackyColorblindLabel => "P";
        public override Appliance DedicatedProvider => Refs.KegProviderPumpkin;
        public override Item SplitSubItem => Refs.BeerMugPumpkin;
    }
}