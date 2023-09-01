using KitchenData;
using KitchenMods;

namespace KitchenBlargleBrew.kegerator {

    public struct CKegColor : IItemProperty, IModComponent {
        
        public int colorId;
    }

    public struct CFinishedFerment : IItemProperty, IModComponent {
        
        public int colorId;
    }

    public struct CKegeratorState : IApplianceProperty, IModComponent {
        
        public bool open;
        public int colorId;
    }
}