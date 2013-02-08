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
        //Nåværende frames muse-status (oppdateres hver frame i Game1)
        public static MouseState MOUSE_STATE;
        //Forrige frames musestatus (oppdateres hver frame i Game1)
        public static MouseState PREVIOUS_MOUSE_STATE;
        public static Random RAND = new Random();
        //Y-posisjonen til banens bakkenivå (/fortau)
        public static int GROUND_Y_POS;
        //Skjermstørrelse
        public static int SCREEN_HEIGHT = 550;
        public static int SCREEN_WIDTH = 707;

        //BAKGRUNN
        public static Vector2 FIRST_BROWN_BLOCK_POS;
        public static Vector2 WINDOW_POS;

        //LIV
        //Maks liv
        public const int MAX_LIVES = 5;
        //Antall liv (oppdateres hver frame i LosingControl)
        public static int lives { get; set; }
        //Ønsket høyde og bredde på hjertene
        public const int HEART_WIDTH_HEIGHT = 40;
        //Hjertenes source-rektangel (beskjæringsrektangel)
        public static Rectangle HEART_SPRITE_RECTANGLE = new Rectangle(6, 45,
            92, 92);

        //CITIZEN
        //Liste over navn på innbyggersprites
        public static String[] CITIZEN_SPRITE_NAME = new String[]{ "Character Boy", "Character Cat Girl", "Character Horn Girl",
            "Character Pink Girl", "Character Princess Girl" };
        //Maks antall innbyggere som kan spawne
        public const int MAX_CITIZENS = 10;
        //Innbyggeres startfart
        public const int CITIZEN_INIT_SPEED = 3;
        //Innbyggeres maksfart
        public const int CITIZEN_MAX_SPEED = 8;
        //Om innbygger nr.2 skal spawne litt tettere opp i innbygger 1 (tallet skal ikke overskride CITIZEN_SPAWN_TIME)
        public const int SECOND_CITIZEN_SPAWN_BONUS = 1000;
        //Hvor lang tid det skal ta mellom hver innbygger spawnes
        public const int CITIZEN_SPAWN_TIME = 3800;
        //Array som inneholder tre "vanskelighetsgrader" for hvor fort neste innbygger skal spawne (tallet skal ikke overskride CITIZEN_SPAWN_TIME)
        public static int[] CITIZEN_SPAWN_SPEEDUP = new int[] { 0, 2500, 2800 };
        //Hvor lang timeout en innbygger har dersom han reddes (klikkes på)
        public const int CITIZEN_RESPAWN_TIME = 2000;
        //Klikkbart- og beskjæringsrektangels bredde og høyde
        public const int CITIZEN_BOX_WIDTH = 82;
        public const int CITIZEN_BOX_HEIGHT = 100;
        //Citizens source-rektangel (beskjæringsrektangel)
        public static Rectangle CITIZEN_SPRITE_RECTANGLE = new Rectangle(7, 50,
            CITIZEN_BOX_WIDTH, CITIZEN_BOX_HEIGHT);

        //LADYBUG
        public static String LADYBUG_SPRITE_NAME = "Enemy Bug";
        public static int MAX_LADYBUGS = 3;
        public static int bugs_killed;
        public const int LADYBUG_HEALTH = 20;
        public const double LADYBUG_SPAWN_TIME = 4500;
        public const double LADYBUG_DESPAWN_TIME = 7500;
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