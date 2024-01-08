using KitchenBlargleBrew;
using KitchenData;
using System.Collections.Generic;
using UnityEngine;

namespace BlargleBrew.draft {

    public class KegProviderWheat : AbstractKegProvider<KegWheat> {

        protected override string prefabName => "KegRackSmallWheat";
        protected override string name => "Wheat";
        protected override string displayName => "Wheat";
        protected override Material[] labelMaterial => CommonMaterials.Keg.wheatLabel;
        protected override bool preventReturns => true;
        protected override bool conditionalProvider => false;
        protected override string labelPath => "keg-bands";
        public override List<Appliance> Upgrades => new List<Appliance>() {
            Refs.KegEmptyProvider
        };
    }
}