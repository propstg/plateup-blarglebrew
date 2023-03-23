using KitchenData;
using KitchenMods;

namespace KitchenBlargleBrew.kegerator {

    public struct CFermenterState : IApplianceProperty, IModComponent {
        
        public int colorId;
        public bool doneFermenting;
        public int kegQuantity;
        public bool infinite;
    }
}