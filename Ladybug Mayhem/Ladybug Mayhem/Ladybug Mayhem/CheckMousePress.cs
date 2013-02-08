using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Ladybug_Mayhem
{
    class CheckMousePress
    {
        /// <summary>
        /// Tar imot et rektangel, og sjekker om musen trykker på det området det dekker
        /// Returnerer true/false
        /// </summary>
        /// <param name="rectangle">Rektangel for området som skal sjekkes</param>
        /// <returns></returns>
        public static bool IsBeingPressed(Rectangle rectangle)
        {
            if (GlobalVars.MOUSE_STATE.LeftButton == ButtonState.Pressed && GlobalVars.PREVIOUS_MOUSE_STATE.LeftButton == ButtonState.Released && rectangle.Contains(new Point(GlobalVars.MOUSE_STATE.X, GlobalVars.MOUSE_STATE.Y)))
                return true;
            return false;
        }
    }
}
