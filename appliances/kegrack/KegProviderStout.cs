using KitchenBlargleBrew;
using KitchenData;
using System.Collections.Generic;
using UnityEngine;

namespace BlargleBrew.draft {

    public class KegProviderStout : AbstractKegProvider<KegStout> {

        protected override string prefabName => "KegRackSmallStout";
        protected override string name => "Stout";
        protected override Material[] labelMaterial => CommonMaterials.Keg.stoutLabel;
        protected override bool preventReturns => true;
        protected override bool conditionalProvider => false;
        protected override string labelPath => "keg-bands";
        public override List<Appliance> Upgrades => new List<Appliance>() {
            Refs.KegEmptyProvider
        };
    }
}