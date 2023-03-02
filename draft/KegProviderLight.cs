namespace BlargleBrew.draft {

    public class KegProviderLight : AbstractKegProvider<KegLight> {

        protected override string prefabName => "KegRackLight";
        protected override string name => "Lt";
        protected override string labelMaterial => "Paper - Postit Yellow";
    }
}