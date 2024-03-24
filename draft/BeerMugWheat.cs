using KitchenBlargleBrew;
using KitchenData;
using UnityEngine;

namespace BlargleBrew.draft {

    public class BeerMugWheat : AbstractBeerMug {

        protected override Material[] beerMaterial => BlargleBrewMod.IsGreenBeerActive ? CommonMaterials.wheatGreen : CommonMaterials.Mug.wheatBeer;
        protected override Material[] foamMaterial => BlargleBrewMod.IsGreenBeerActive ? CommonMaterials.wheatGreenFoam : CommonMaterials.Mug.wheatFoam;
        protected override string name => "Wheat";
        protected override string prefabName => "BeerLight";
        public override string ColourBlindTag => "Wh";
    }
}