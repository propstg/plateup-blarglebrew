namespace BlargleBrew.draft {

    public class KegProviderIpa : AbstractKegProvider<KegIpa> {

        protected override string prefabName => "KegRackIpa";
        protected override string name => "IPA";
        protected override string labelMaterial => "Metal Black";
    }
}