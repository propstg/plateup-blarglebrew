using KitchenData;
using KitchenMods;

namespace KitchenBlargleBrew.kegerator {

    public struct CFermenterState : IApplianceProperty, IModComponent {
        
        public int colorId;
        public int finishedQuantity;
        public int fermentingQuantity;
    }
}