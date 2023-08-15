using KitchenBlargleBrew;
using KitchenBlargleBrew.kegerator;
using KitchenData;
using System.Collections.Generic;
using UnityEngine;

namespace BlargleBrew.draft {

    public class KegProviderEmpty : AbstractKegProvider<CleanEmptyKeg> {

        protected override string prefabName => "KegRackEmpty";
        protected override string name => "Empty";
        protected override Material[] labelMaterial => CommonMaterials.Keg.emptyLabel;
        protected override Material[] kegMaterial => CommonMaterials.Keg.metal;
        protected override bool preventReturns => false;
        public override List<Appliance> Upgrades => new List<Appliance>() {
            Refs.KegEmptyProvider
        };
    }
}