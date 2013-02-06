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

        //LIV
        public const int HEART_WIDTH_HEIGHT = 40;
        public static Rectangle HEART_SPRITE_RECTANGLE = new Rectangle(6, 45,
            92, 92);

        //CITIZEN
        public static String[] CITIZEN_SPRITE_NAME = new String[]{ "Character Boy", "Character Cat Girl", "Character Horn Girl",
            "Character Pink Girl", "Character Princess Girl" };

        public const int MAX_CITIZENS = 10;
        public const int CITIZEN_BOX_WIDTH = 80;
        public const int CITIZEN_BOX_HEIGHT = 100;
        //public const int CITIZEN_TOP_CROP = 50;
        //public const int CITIZEN_LEFT_CROP = 10;

        public static Vector2 CITIZEN_SPAWN_POS = new Vector2(-200, 100);

        public static Rectangle CITIZEN_SPRITE_RECTANGLE = new Rectangle(10, 50,
            CITIZEN_BOX_WIDTH, CITIZEN_BOX_HEIGHT);
    }
}