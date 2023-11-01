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
        public static Material[] rugGreen => wrap(MaterialUtils.GetExistingMaterial("Rug - Green"));
        public static Material[] tomato => wrap(MaterialUtils.GetExistingMaterial("Tomato"));
        public static Material[] plasticGreen => wrap(MaterialUtils.GetExistingMaterial("Plastic - Green"));
        public static Material[] vanilla => wrap(MaterialUtils.GetExistingMaterial("Vanilla"));
        public static Material[] sinkWater => wrap(MaterialUtils.GetExistingMaterial("Sink Water"));

        public static Material[] tequila => wrap(MaterialUtils.CreateTransparent("BlargleBrew - Tequila", 0xF9D1A7, 0.75f));
        public static Material[] pilsner => wrap(MaterialUtils.CreateTransparent("BlargleBrew - Pilsner", 0xFFD15E, 0.75f));
        public static Material[] wheat => wrap(MaterialUtils.CreateTransparent("BlargleBrew - Wheat", 0xFFD15E, 0.75f));
        public static Material[] wheatSack => new Material[] { MaterialUtils.GetExistingMaterial("Sack - Brown"), MaterialUtils.CreateFlat("BlargleBrew - Wheat Sack", 0xAB8C3E) };
        public static Material[] thinGlass => wrap(MaterialUtils.CreateTransparent("BlargleBrew - Thin Glass", 0xF6FEFF, 0.1f));
        public static Material[] pumpkinBeer => wrap(MaterialUtils.CreateTransparent("BlargleBrew - Pumpkin", 0xFF7518, 0.9f));
        public static Material[] pumpkinKeg => wrap(MaterialUtils.CreateFlat("BlargleBrew - Pumpkin Keg", 0xFF7518));

        public static class Bottle {
            public static Material[] box => cardboard;
            public static Material[] glass => CommonMaterials.glass;
            public static Material[] lid => metalBlack;
            public static Material[] liquid => pilsner;
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
            public static Material[] wheatBeer => wheat;
            public static Material[] wheatFoam => uncookedBatter;
            public static Material[] orange => mandarinSkin;
            public static Material[] pumpkinBeer => CommonMaterials.pumpkinBeer;
            public static Material[] pumpkinFoam => metalBlack;
        }

        public static class StoutFloat {
            public static Material[] glass => CommonMaterials.glass;
            public static Material[] beer => woodDefault;
            public static Material[] foam => woodCorkboard;
            public static Material[] iceCream => vanilla;
        }

        public static class Keg {
            public static Material[] dirty => metalDirty;
            public static Material[] metal => metalShiny;
            public static Material[] rack => metalShiny;
            public static Material[] stoutLabel => metalBlack;
            public static Material[] wheatLabel => postitYellow;
            public static Material[] pumpkinLabel => metalBlack;
            public static Material[] pumpkinLabelKegerator => pumpkinKeg;
            public static Material[] pumpkinBody => pumpkinKeg;
            public static Material[] emptyLabel => metalDirty;
        }

        public static class PickledEgg {
            public static Material[] egg => eggWhite;
            public static Material[] glass => CommonMaterials.glass;
        }

        public static class Michelada {
            public static Material[] glass => CommonMaterials.glass;
            public static Material[] beer => pilsner;
            public static Material[] limeJuice => CommonMaterials.limeJuice;
            public static Material[] rim => CommonMaterials.tomatoFlesh;
            public static Material[] pepperBody => CommonMaterials.plasticGreen;
            public static Material[] pepperStem => CommonMaterials.rugGreen;
        }

        public static class TomatoJuice {
            public static Material[] glass => CommonMaterials.glass;
            public static Material[] contents => CommonMaterials.tomato;
        }

        public static class Beermosa {
            public static Material[] glass => CommonMaterials.glass;
            public static Material[] wheatBeer => wheat;
            public static Material[] orangeJuice => mandarinSkin;
        }

        public static class Tequila {
            public static Material[] glass => CommonMaterials.glass;
            public static Material[] liquid => CommonMaterials.tequila;
            public static Material[] lid => CommonMaterials.metalBlack;
            public static Material[] logo => CommonMaterials.lime;

        }

        public static class TequilaAndLime {

            public static Material[] glass => CommonMaterials.glass;
            public static Material[] limeJuice => CommonMaterials.limeJuice;
            public static Material[] straw => CommonMaterials.metalBlack;
            public static Material[] tequila => CommonMaterials.tequila;

        }

        public static class Beergarita {
            public static Material[] glass => CommonMaterials.glass;
            public static Material[] limeJuice => CommonMaterials.limeJuice;
            public static Material[] straw => CommonMaterials.metalBlack;
            public static Material[] tequila => CommonMaterials.tequila;
            public static Material[] bottleHolder => CommonMaterials.plasticGreen;

        }

        public static class Hops {
            public static Material[] bag => wrap(MaterialUtils.CreateTransparent("BlargleBrew - Stout Undiluted", 0xFFFFFF, 0.4f));
            public static Material[] hops => limeJuice;
            public static Material[] clip => metalBlack;
        }

        public static class Yeast {
            public static Material[] glass => CommonMaterials.glass;
            public static Material[] yeast => CommonMaterials.uncookedBatter;
        }

        public static class ExtractStout {
            public static Material[] glass => CommonMaterials.glass;
            public static Material[] extractUndiluted => wrap(MaterialUtils.CreateTransparent("BlargleBrew - Stout Undiluted", 0x964b00, 1.0f));
            public static Material[] extractDiluted => wrap(MaterialUtils.CreateTransparent("BlargleBrew - Stout Diluted", 0x964b00, 0.6f));
            public static Material[] label => CommonMaterials.Keg.stoutLabel;
            public static Material[] lid => label;
            public static Material[] pot => CommonMaterials.metalShiny;
            public static Material[] foam => CommonMaterials.Mug.stoutFoam;
        }

        public static class WheatBrew {
            public static Material[] glass => CommonMaterials.glass;
            public static Material[] water => CommonMaterials.sinkWater;
            public static Material[] wheatBrew => CommonMaterials.wheat;
            public static Material[] pot => CommonMaterials.metalShiny;
            public static Material[] foam => CommonMaterials.Mug.wheatFoam;
        }

        public static class PumpkinBrew {
            public static Material[] glass => CommonMaterials.glass;
            public static Material[] pumpkinExtractUndiluted => CommonMaterials.pumpkinKeg;
            public static Material[] pumpkinExtractDiluted => CommonMaterials.pumpkinBeer;
            public static Material[] pumpkinBrew => CommonMaterials.pumpkinKeg;
            public static Material[] label => CommonMaterials.pumpkinKeg;
            public static Material[] pot => CommonMaterials.metalShiny;
            public static Material[] foam => CommonMaterials.Mug.wheatFoam;
        }
    }
}
