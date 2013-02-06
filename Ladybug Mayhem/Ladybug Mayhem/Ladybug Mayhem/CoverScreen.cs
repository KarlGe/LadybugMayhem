using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace Ladybug_Mayhem
{
    class CoverScreen
    {
        public static DrawObject CalculateCoverScreen(DrawObject obj, int Y, int screenWidth, int blockWidth)
        {
            int objDrawAmount;
            int drawAmount = (int)Math.Ceiling((double)screenWidth / (double)blockWidth);
            objDrawAmount = (int)Math.Ceiling((double)screenWidth / (double)blockWidth);
            obj.drawPlacement.X = (screenWidth - (obj.width * objDrawAmount)) / 2;
            obj.drawPlacement.Y = Y;
            obj.drawAmount = objDrawAmount;
            return obj;
        }
    }
}
