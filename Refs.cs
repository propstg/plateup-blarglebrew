using BlargleBrew.Kegerator;
using KitchenData;
using KitchenLib.Utils;

namespace KitchenBlargleBrew
{
    public class Refs {

        public static Appliance KegProvider => GDOUtils.GetCastedGDO<Appliance, KegProvider>();
        public static Appliance EmptyMugProvider => GDOUtils.GetCastedGDO<Appliance, EmptyMugProvider>();
        public static Appliance Kegerator => GDOUtils.GetCastedGDO<Appliance, Kegerator>();
        public static Item Keg => GDOUtils.GetCastedGDO<Item, Keg>();
        public static Item EmptyMug => GDOUtils.GetCastedGDO<Item, EmptyMug>();
        public static Item Mug => GDOUtils.GetCastedGDO<Item, Mug>();

    }
}