using KitchenBlargleBrew;
using KitchenData;
using System.Collections.Generic;
using UnityEngine;

namespace BlargleBrew.draft {

    public class KegProviderEmpty : AbstractKegProvider<CleanEmptyKeg> {

        protected override string prefabName => "KegRackSmallEmpty";
        protected override string name => "Empty";
        protected override string displayName => "Empty";
        protected override Material[] labelMaterial => CommonMaterials.Keg.emptyLabel;
        protected override Material[] kegMaterial => CommonMaterials.Keg.metal;
        protected override bool preventReturns => false;
        protected override bool conditionalProvider => false;
        protected override string labelPath => "keg-bands";
        public override List<Appliance> Upgrades => new List<Appliance>() {
            Refs.KegLightProvider, Refs.KegStoutProvider
        };
    }
}