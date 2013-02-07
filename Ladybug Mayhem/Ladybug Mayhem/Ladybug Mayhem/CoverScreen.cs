using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace Ladybug_Mayhem
{
    class CoverScreen
    {
        public static DrawSprite CalculateCoverScreen(DrawSprite obj, int Y, int screenWidth, int blockWidth)
        {
            int objDrawAmount;
            int drawAmount = (int)Math.Ceiling((double)screenWidth / (double)blockWidth);
            objDrawAmount = (int)Math.Ceiling((double)screenWidth / (double)blockWidth);
            obj.position.X = (screenWidth - (obj.width * objDrawAmount)) / 2;
            obj.position.Y = Y;
            obj.drawAmount = objDrawAmount;
            return obj;
        }
    }
}
