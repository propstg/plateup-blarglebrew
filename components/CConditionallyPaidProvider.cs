using KitchenData;
using KitchenMods;

// DO NOT CHANGE NAMESPACE
namespace KitchenBlargleBrew.components {

    public struct CConditionallyPaidProvider : IApplianceProperty, IModComponent {
        public int requiredCardId;
        public int price;
        public bool preventBuyingOnCredit;
    }
}