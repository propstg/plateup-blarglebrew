using UnityEngine;

namespace BlargleBrew.draft {

    public class BeerMugStout : AbstractBeerMug {

        protected override Material[] beerMaterial => CommonMaterials.Mug.stoutBeer;
        protected override Material[] foamMaterial => CommonMaterials.Mug.stoutFoam;
        protected override string name => "Stout";
        protected override string prefabName => "mug";
        public override string ColourBlindTag => "St";
    }
}