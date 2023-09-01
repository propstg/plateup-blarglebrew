using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;

namespace BlargleBrew.processes {

    public class Cool : CustomProcess {

        public override string UniqueNameID => "cool";
        public override GameDataObject BasicEnablingAppliance => GDOUtils.GetExistingGDO(ApplianceReferences.Freezer);
        public override int EnablingApplianceCount => 2;
        public override Process IsPseudoprocessFor => null;
        public override bool CanObfuscateProgress => true;
        public override List<(Locale, ProcessInfo)> InfoList => new List<(Locale, ProcessInfo)>() {
            (Locale.English, new ProcessInfo() {
                Name = "Cool",
                Icon = "<sprite name=\"snow\">",
            }),
        };
    }
}
