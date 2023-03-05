﻿using KitchenBlargleBrew;
using KitchenData;
using UnityEngine;

namespace BlargleBrew.draft {

    public class KegStout : AbstractKeg {

        protected override string name => "Stout";
        protected override Material[] labelMaterial => CommonMaterials.Keg.stoutLabel;
        protected override string prefabName => "Keg";
        protected override int colorId => 1;
        public override string ColourBlindTag => "St";
        public override Appliance DedicatedProvider => Refs.KegStoutProvider;
        public override Item SplitSubItem => Refs.BeerStout;
    }
}