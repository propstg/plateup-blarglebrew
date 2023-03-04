using UnityEngine;

namespace BlargleBrew.draft {

    public class BeerMugWheat : AbstractBeerMug {

        protected override Material[] beerMaterial => CommonMaterials.Mug.wheatBeer;
        protected override Material[] foamMaterial => CommonMaterials.Mug.wheatFoam;
        protected override string name => "Wheat";
        protected override string prefabName => "BeerLight";
        public override string ColourBlindTag => "Wh";
    }
}