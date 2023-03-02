using KitchenBlargleBrew;
using KitchenData;

namespace BlargleBrew.draft {

    public class KegLight : AbstractKeg {

        protected override string name => "Light";
        protected override string labelMaterial => "Paper - Postit Yellow";
        protected override string prefabName => "KegLight";
        public override string ColourBlindTag => "Lt";
        public override Appliance DedicatedProvider => Refs.KegLightProvider;
        public override Item SplitSubItem => Refs.BeerLight;
    }
}