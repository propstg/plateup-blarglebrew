using KitchenLib.Utils;
using UnityEngine;

namespace BlargleBrew {

    class CommonMaterials {
        private static Material[] wrap(Material material) => new Material[] { material };

        public static Material[] glass => wrap(MaterialUtils.GetExistingMaterial("IngredientLib - \"Glass\""));
        public static Material[] cardboard => wrap(MaterialUtils.GetExistingMaterial("Cardboard"));
        public static Material[] metalBlack => wrap(MaterialUtils.GetExistingMaterial("Metal Black"));
        public static Material[] metalDirty => wrap(MaterialUtils.GetExistingMaterial("Metal - Dirty"));
        public static Material[] metalShiny => wrap(MaterialUtils.GetExistingMaterial("Metal- Shiny"));
        public static Material[] metalShinyBlue => wrap(MaterialUtils.GetExistingMaterial("Metal- Shiny Blue"));
        public static Material[] postitYellow => wrap(MaterialUtils.GetExistingMaterial("Paper - Postit Yellow"));
        public static Material[] snow => wrap(MaterialUtils.GetExistingMaterial("Snow"));
        public static Material[] uncookedBatter => wrap(MaterialUtils.GetExistingMaterial("Uncooked Batter"));
        public static Material[] woodCorkboard => wrap(MaterialUtils.GetExistingMaterial("Wood - Corkboard"));
        public static Material[] woodDefault => wrap(MaterialUtils.GetExistingMaterial("Wood - Default"));
        public static Material[] mandarinSkin => wrap(MaterialUtils.GetExistingMaterial("Mandarin Skin"));
        public static Material[] lime => wrap(MaterialUtils.GetExistingMaterial("IngredientLib - \"Lime\""));
        public static Material[] limeJuice => wrap(MaterialUtils.GetExistingMaterial("IngredientLib - \"Lime Juice\""));
        public static Material[] eggWhite => wrap(MaterialUtils.GetExistingMaterial("Egg - White"));
        public static Material[] tomatoFlesh => wrap(MaterialUtils.GetExistingMaterial("Tomato Flesh"));


        public static class Bottle {
            public static Material[] box => cardboard;
            public static Material[] glass => CommonMaterials.glass;
            public static Material[] lid => metalBlack;
            public static Material[] liquid => postitYellow;
            public static Material[] lime => CommonMaterials.lime;
        }

        public static class Can {
            public static Material[] box => cardboard;
            public static Material[] metal => metalShiny;
            public static Material[] paint => metalShinyBlue;
            public static Material[] foam => snow;
        }

        public static class Mug {
            public static Material[] glass => CommonMaterials.glass;
            public static Material[] stoutBeer => woodDefault;
            public static Material[] stoutFoam => woodCorkboard;
            public static Material[] wheatBeer => postitYellow;
            public static Material[] wheatFoam => uncookedBatter;
            public static Material[] orange => mandarinSkin;
        }

        public static class Keg {
            public static Material[] dirty => metalDirty;
            public static Material[] metal => metalShiny;
            public static Material[] rack => metalShiny;
            public static Material[] stoutLabel => metalBlack;
            public static Material[] wheatLabel => postitYellow;
            public static Material[] emptyLabel => metalDirty;
        }

        public static class PickledEgg {
            public static Material[] egg => eggWhite;
            public static Material[] glass => CommonMaterials.glass;
        }

        public static class Michelada {
            public static Material[] glass => CommonMaterials.glass;
            public static Material[] beer => postitYellow;
            public static Material[] limeJuice => CommonMaterials.limeJuice;
            public static Material[] rim => CommonMaterials.tomatoFlesh;
        }
    }
}
