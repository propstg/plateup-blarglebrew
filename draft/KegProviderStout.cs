using UnityEngine;

namespace BlargleBrew.draft {

    public class KegProviderStout : AbstractKegProvider<KegStout> {

        protected override string prefabName => "KegRackIpa";
        protected override string name => "Stout";
        protected override Material[] labelMaterial => CommonMaterials.Keg.stoutLabel;
    }
}