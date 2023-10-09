using KitchenData;
using KitchenMods;

// DO NOT CHANGE NAMESPACE
namespace KitchenBlargleBrew.kegerator {

    public struct CKegeratorState : IApplianceProperty, IModComponent {

        public bool open;
        public int colorId;
    }
}