namespace BlargleBrew.draft {

    public class BeerMugIpa : AbstractBeerMug {

        protected override string beerMaterial => "Wood - Default";
        protected override string foamMaterial => "Wood - Corkboard";
        protected override string name => "IPA";
        protected override string prefabName => "mug";
        public override string ColourBlindTag => "IPA";
    }
}