using KitchenBlargleBrew;
using KitchenData;
using UnityEngine;

namespace BlargleBrew.draft {

    public class KegWheat : AbstractKeg {

        protected override string name => "Wheat";
        protected override Material[] labelMaterial => CommonMaterials.Keg.wheatLabel;
        protected override string prefabName => "KegLight";
        protected override int colorId => 2;
        public override string ColourBlindTag => "Wh";
        public override Appliance DedicatedProvider => Refs.KegLightProvider;
        public override Item SplitSubItem => Refs.BeerWheat;
    }
}