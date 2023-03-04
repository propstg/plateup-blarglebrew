using UnityEngine;

namespace BlargleBrew.draft {

    public class KegProviderWheat : AbstractKegProvider<KegWheat> {

        protected override string prefabName => "KegRackLight";
        protected override string name => "Wh";
        protected override Material[] labelMaterial => CommonMaterials.Keg.wheatLabel;
    }
}