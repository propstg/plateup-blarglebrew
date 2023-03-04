using KitchenBlargleBrew;
using KitchenData;
using UnityEngine;

namespace BlargleBrew.draft {

    public class KegIpa : AbstractKeg {

        protected override string name => "IPA";
        protected override Material[] labelMaterial => CommonMaterials.Keg.ipaLabel;
        protected override string prefabName => "Keg";
        protected override int colorId => 1;
        public override string ColourBlindTag => "IPA";
        public override Appliance DedicatedProvider => Refs.KegIpaProvider;
        public override Item SplitSubItem => Refs.BeerIpa;
    }
}