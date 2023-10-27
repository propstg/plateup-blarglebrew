using UnityEngine;

namespace BlargleBrew.draft {

    public class BeerMugPumpkin : AbstractBeerMug {

        protected override Material[] beerMaterial => CommonMaterials.Mug.pumpkinBeer;
        protected override Material[] foamMaterial => CommonMaterials.Mug.pumpkinFoam;
        protected override string name => "Pumpkin Beer";
        protected override string prefabName => "PumpkinMug";
        public override string ColourBlindTag => "P";
    }
}