using KitchenBlargleBrew;
using KitchenData;

namespace BlargleBrew.draft {

    public class KegLight : AbstractKeg {

        protected override string name => "Wheat";
        protected override string labelMaterial => "Paper - Postit Yellow";
        protected override string prefabName => "KegLight";
        protected override int colorId => 2;
        public override string ColourBlindTag => "Wh";
        public override Appliance DedicatedProvider => Refs.KegLightProvider;
        public override Item SplitSubItem => Refs.BeerLight;
    }
}