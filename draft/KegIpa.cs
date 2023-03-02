using KitchenBlargleBrew;
using KitchenData;

namespace BlargleBrew.draft {

    public class KegIpa : AbstractKeg {

        protected override string name => "IPA";
        protected override string labelMaterial => "Metal Black";
        protected override string prefabName => "Keg";
        public override string ColourBlindTag => "IPA";
        public override Appliance DedicatedProvider => Refs.KegIpaProvider;
        public override Item SplitSubItem => Refs.BeerIpa;
    }
}