using BlargleBrew.draft;
using IngredientLib.Ingredient.Items;
using KitchenBlargleBrew.kegerator;
using KitchenData;
using KitchenLib.References;
using KitchenLib.Utils;

namespace KitchenBlargleBrew
{
    public class Refs {

        public static Appliance KegIpaProvider => GDOUtils.GetCastedGDO<Appliance, KegProviderIpa>();
        public static Appliance KegLightProvider => GDOUtils.GetCastedGDO<Appliance, KegProviderWheat>();
        public static Appliance EmptyMugProvider => GDOUtils.GetCastedGDO<Appliance, EmptyMugProvider>();
        public static Appliance Kegerator => GDOUtils.GetCastedGDO<Appliance, Kegerator>();
        public static Item EmptyKeg => GDOUtils.GetCastedGDO<Item, EmptyKeg>();
        public static Item KegIpa => GDOUtils.GetCastedGDO<Item, KegIpa>();
        public static Item KegLight => GDOUtils.GetCastedGDO<Item, KegWheat>();
        public static Item EmptyMug => GDOUtils.GetCastedGDO<Item, EmptyMug>();
        public static Item BeerIpa => GDOUtils.GetCastedGDO<Item, BeerMugIpa>();
        public static Item BeerWheat => GDOUtils.GetCastedGDO<Item, BeerMugWheat>();

        public static Appliance BeerCanProvider => GDOUtils.GetCastedGDO<Appliance, BeerCanProvider>();
        public static Item BeerCanClosed => GDOUtils.GetCastedGDO<Item, BeerCanClosed>();
        public static Item BeerCanOpen => GDOUtils.GetCastedGDO<Item, BeerCanOpen>();
        public static Item BeerCanEmpty => GDOUtils.GetCastedGDO<Item, BeerCanEmpty>();

        public static Appliance BeerBottleProvider => GDOUtils.GetCastedGDO<Appliance, BeerBottleProvider>();
        public static Item BeerBottleClosed => GDOUtils.GetCastedGDO<Item, BeerBottleClosed>();
        public static Item BeerBottleOpen => GDOUtils.GetCastedGDO<Item, BeerBottleOpen>();
        public static Item BeerBottleEmpty => GDOUtils.GetCastedGDO<Item, BeerBottleEmpty>();

        public static Item Mandarin => (Item) GDOUtils.GetExistingGDO(ItemReferences.MandarinRaw);
        public static Item MandarinSlice => (Item) GDOUtils.GetExistingGDO(ItemReferences.MandarinSlice);
        public static Item Lime => GDOUtils.GetCastedGDO<Item, Lime>();
        public static Item LimeChopped => GDOUtils.GetCastedGDO<Item, ChoppedLime>();

    }
}