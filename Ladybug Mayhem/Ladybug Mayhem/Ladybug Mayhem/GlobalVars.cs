using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//ikke default
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Ladybug_Mayhem
{
    public class GlobalVars
    {
        //FELLES
        public static MouseState MOUSE_STATE;
        public static MouseState PREVIOUS_MOUSE_STATE;
        public static Random RAND = new Random();
        public static int GROUND_Y_POS;
        public static int SCREEN_HEIGHT = 550;
        public static int SCREEN_WIDTH = 707;

        //BAKGRUNN
        public static Vector2 FIRST_BROWN_BLOCK_POS;
        public static Vector2 WINDOW_POS;

        //LIV
        public const int MAX_LIVES = 5;
        public static int lives { get; set; }
        public const int HEART_WIDTH_HEIGHT = 40;
        public static Rectangle HEART_SPRITE_RECTANGLE = new Rectangle(6, 45,
            92, 92);

        //CITIZEN
        public static String[] CITIZEN_SPRITE_NAME = new String[]{ "Character Boy", "Character Cat Girl", "Character Horn Girl",
            "Character Pink Girl", "Character Princess Girl" };
        public const int MAX_CITIZENS = 10;
        public const int CITIZEN_BOX_WIDTH = 82;
        public const int CITIZEN_BOX_HEIGHT = 100;
        public static Rectangle CITIZEN_SPRITE_RECTANGLE = new Rectangle(7, 50,
            CITIZEN_BOX_WIDTH, CITIZEN_BOX_HEIGHT);

        //LADYBUG
        public static String LADYBUG_SPRITE_NAME = "Enemy Bug";
        public static int MAX_LADYBUGS = 3;
        public const int LADYBUG_HEALTH = 20;
        public const double LADYBUG_SPAWN_TIME = 5000;
        public const double LADYBUG_DESPAWN_TIME = 10000;
        public const double LADYBUG_DEAD_TIME = 2000;
        public const int LADYBUG_BOX_WIDTH = 100;
        public const int LADYBUG_BOX_HEIGHT = 78;
        public static Rectangle LADYBUG_SPRITE_RECTANGLE = new Rectangle(0, 77, LADYBUG_BOX_WIDTH, LADYBUG_BOX_HEIGHT);
        public const int MAX_LADYBUG_SPAWN_POINTS = 5;

        //GEMS
        public static String[] GEM_SPRITE_NAME = new String[] { "Gem Blue", "Gem Green", "Gem Orange" };
        public const int MAX_GEMS = 3;
        public static int gems { get; set; }
        public const int GEM_WIDTH_HEIGHT = 50;
        public static Rectangle GEM_SPRITE_RECTANGLE = new Rectangle(0, 57, 100, 113);
    }
}