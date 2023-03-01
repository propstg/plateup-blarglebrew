using KitchenBlargleBrew.kegerator;
using KitchenData;
using KitchenLib.Utils;

namespace KitchenBlargleBrew
{
    public class Refs {

        public static Appliance KegIpaProvider => GDOUtils.GetCastedGDO<Appliance, KegIpaProvider>();
        public static Appliance KegLightProvider => GDOUtils.GetCastedGDO<Appliance, KegLightProvider>();
        public static Appliance EmptyMugProvider => GDOUtils.GetCastedGDO<Appliance, EmptyMugProvider>();
        public static Appliance Kegerator => GDOUtils.GetCastedGDO<Appliance, Kegerator>();
        public static Appliance BeerCanProvider => GDOUtils.GetCastedGDO<Appliance, BeerCanProvider>();
        public static Item EmptyKeg => GDOUtils.GetCastedGDO<Item, EmptyKeg>();
        public static Item KegIpa => GDOUtils.GetCastedGDO<Item, KegIpa>();
        public static Item KegLight => GDOUtils.GetCastedGDO<Item, KegLight>();
        public static Item EmptyMug => GDOUtils.GetCastedGDO<Item, EmptyMug>();
        public static Item BeerIpa => GDOUtils.GetCastedGDO<Item, BeerIpa>();
        public static Item BeerLight => GDOUtils.GetCastedGDO<Item, BeerLight>();
        public static Item BeerCanClosed => GDOUtils.GetCastedGDO<Item, BeerCanClosed>();
        public static Item BeerCanOpen => GDOUtils.GetCastedGDO<Item, BeerCanOpen>();
        public static Item BeerCanEmpty => GDOUtils.GetCastedGDO<Item, BeerCanEmpty>();

    }
}