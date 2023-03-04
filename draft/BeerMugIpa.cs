using UnityEngine;

namespace BlargleBrew.draft {

    public class BeerMugIpa : AbstractBeerMug {

        protected override Material[] beerMaterial => CommonMaterials.Mug.ipaBeer;
        protected override Material[] foamMaterial => CommonMaterials.Mug.ipaFoam;
        protected override string name => "IPA";
        protected override string prefabName => "mug";
        public override string ColourBlindTag => "IPA";
    }
}