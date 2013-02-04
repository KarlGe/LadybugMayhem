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

        //CITIZEN
        public const int MAX_CITIZENS = 10;
        public static Vector2 CITIZEN_SPAWN_POS = new Vector2(-200, 100);
    }
}
