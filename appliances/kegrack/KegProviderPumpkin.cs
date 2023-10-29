﻿using KitchenBlargleBrew;
using KitchenData;
using System.Collections.Generic;
using UnityEngine;

namespace BlargleBrew.draft {

    public class KegProviderPumpkin : AbstractKegProvider<KegPumpkin> {

        protected override string prefabName => "PumpkinRack";
        protected override string name => "Keg Rack Pumpkin";
        protected override Material[] labelMaterial => CommonMaterials.Keg.pumpkinLabel;
        protected override Material[] kegMaterial => CommonMaterials.Keg.pumpkinBody;
        protected override bool preventReturns => true;
        protected override bool conditionalProvider => true;
        public override List<Appliance> Upgrades => new List<Appliance>() {
            Refs.KegEmptyProvider
        };
    }
}