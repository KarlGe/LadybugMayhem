using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//ikke default
using Microsoft.Xna.Framework;

namespace Ladybug_Mayhem
{
    public class GlobalVars
    {
        //FELLES
        public static Random RAND = new Random();

        //CITIZEN
        public const int MAX_CITIZENS = 10;
        public static Vector2 CITIZEN_SPAWN_POS = new Vector2(-200, 100);
    }
}
