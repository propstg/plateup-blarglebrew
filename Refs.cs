using BlargleBrew.boot;
using BlargleBrew.cards;
using BlargleBrew.draft;
using BlargleBrew.michelada;
using IngredientLib.Ingredient.Items;
using KitchenBlargleBrew.boot;
using KitchenBlargleBrew.kegerator;
using KitchenBlargleBrew.michelada;
using KitchenData;
using KitchenLib.References;
using KitchenLib.Utils;

namespace KitchenBlargleBrew
{
    public class Refs {

        public static Appliance KegStoutProvider => GDOUtils.GetCastedGDO<Appliance, KegProviderStout>();
        public static Appliance KegLightProvider => GDOUtils.GetCastedGDO<Appliance, KegProviderWheat>();
        public static Appliance EmptyMugProvider => GDOUtils.GetCastedGDO<Appliance, EmptyMugProvider>();
        public static Appliance Kegerator => GDOUtils.GetCastedGDO<Appliance, Kegerator>();
        public static Item EmptyKeg => GDOUtils.GetCastedGDO<Item, EmptyKeg>();
        public static Item KegStout => GDOUtils.GetCastedGDO<Item, KegStout>();
        public static Item KegLight => GDOUtils.GetCastedGDO<Item, KegWheat>();
        public static Item EmptyMug => GDOUtils.GetCastedGDO<Item, EmptyMug>();
        public static Item BeerStout => GDOUtils.GetCastedGDO<Item, BeerMugStout>();
        public static Item BeerWheat => GDOUtils.GetCastedGDO<Item, BeerMugWheat>();
        public static ItemGroup WheatBeerWithOrange => GDOUtils.GetCastedGDO<ItemGroup, WheatBeerWithOrange>();

        public static Appliance BeerCanProvider => GDOUtils.GetCastedGDO<Appliance, BeerCanProvider>();
        public static Item BeerCanClosed => GDOUtils.GetCastedGDO<Item, BeerCanClosed>();
        public static Item BeerCanOpen => GDOUtils.GetCastedGDO<Item, BeerCanOpen>();
        public static Item BeerCanEmpty => GDOUtils.GetCastedGDO<Item, BeerCanEmpty>();

        public static Appliance BeerBottleProvider => GDOUtils.GetCastedGDO<Appliance, BeerBottleProvider>();
        public static Item BeerBottleClosed => GDOUtils.GetCastedGDO<Item, BeerBottleClosed>();
        public static Item BeerBottleOpen => GDOUtils.GetCastedGDO<Item, BeerBottleOpen>();
        public static Item BeerBottleWithLime => GDOUtils.GetCastedGDO<Item, BeerBottleWithLime>();
        public static Item BeerBottleEmpty => GDOUtils.GetCastedGDO<Item, BeerBottleEmpty>();

        public static Item Mandarin => (Item) GDOUtils.GetExistingGDO(ItemReferences.MandarinRaw);
        public static Item MandarinSlice => (Item) GDOUtils.GetExistingGDO(ItemReferences.MandarinSlice);
        public static Item Lime => GDOUtils.GetCastedGDO<Item, Lime>();
        public static Item LimeChopped => GDOUtils.GetCastedGDO<Item, ChoppedLime>();
        public static Item LimeJuice => GDOUtils.GetCastedGDO<Item, LimeJuice>();

        public static Dish DraftBeerDish => GDOUtils.GetCastedGDO<Dish, DraftBeerDish>();
        public static Dish BoxedBeerDish => GDOUtils.GetCastedGDO<Dish, BoxedBeerDish>();
        public static Dish DessertBeerDish => GDOUtils.GetCastedGDO<Dish, DessertBeerDish>();
        public static Dish BootDish => GDOUtils.GetCastedGDO<Dish, BootDish>();
        public static Dish PickledEggDish => GDOUtils.GetCastedGDO<Dish, PickledEggDish>();
        //public static Dish PeanutBowlDish => GDOUtils.GetCastedGDO<Dish, PeanutBowlDish>();

        public static Item EmptyBoot => GDOUtils.GetCastedGDO<Item, EmptyBoot>();
        public static Item StoutBoot => GDOUtils.GetCastedGDO<Item, StoutBoot>();
        public static Appliance EmptyBootProvider => GDOUtils.GetCastedGDO<Appliance, EmptyBootProvider>();


        public static Item Egg => (Item) GDOUtils.GetExistingGDO(ItemReferences.Egg);
        public static Item Vinegar => GDOUtils.GetCastedGDO<Item, VinegarIngredient>();
        public static Item PickledEgg => GDOUtils.GetCastedGDO<Item, PickledEgg>();

        public static Item Nuts => (Item) GDOUtils.GetExistingGDO(ItemReferences.NutsIngredient);
        public static Item Tomato => (Item) GDOUtils.GetExistingGDO(ItemReferences.Tomato);
        public static Item TomatoSauce => (Item) GDOUtils.GetExistingGDO(ItemReferences.TomatoSauce);
        public static Item Pepper => GDOUtils.GetCastedGDO<Item, Pepper>();

        public static Item Michelada => GDOUtils.GetCastedGDO<Item, Michelada>();
        public static Item MicheladaDish => GDOUtils.GetCastedGDO<Item, MicheladaDish>();

        public static Item Water => (Item) GDOUtils.GetExistingGDO(ItemReferences.Water);
        public static Item TomatoJuice => GDOUtils.GetCastedGDO<Item, TomatoJuice>();
        public static Item TomatoJuiceUnmixed => GDOUtils.GetCastedGDO<Item, TomatoJuiceUnmixed>();
        public static Item TomatoJuicePitcher => GDOUtils.GetCastedGDO<Item, TomatoJuicePitcher>();

        public static Item OrangeJuice => GDOUtils.GetCastedGDO<Item, OrangeJuiceIngredient>();
        public static Item Beermosa => GDOUtils.GetCastedGDO<Item, Beermosa>();
        public static Item BottomlessBeermosasDish => GDOUtils.GetCastedGDO<Item, BottomlessBeermosasDish>();

        public static Item VanillaIceCream => (Item) GDOUtils.GetExistingGDO(ItemReferences.IceCreamVanilla);
        public static Item StoutFloat => GDOUtils.GetCastedGDO<Item, StoutFloat>();
        public static Item StoutFloatDish => GDOUtils.GetCastedGDO<Item, StoutFloatDish>();
        
    }
}