namespace BlargleBrew.draft {

    public class BeerMugLight : AbstractBeerMug {

        protected override string beerMaterial => "Paper - Postit Yellow";
        protected override string foamMaterial => "Uncooked Batter";
        protected override string name => "Wheat";
        protected override string prefabName => "BeerLight";
        public override string ColourBlindTag => "Wh";
    }
}