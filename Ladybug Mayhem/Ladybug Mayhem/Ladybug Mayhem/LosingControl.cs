using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//ikke default
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Ladybug_Mayhem
{
    public class LosingControl
    {
        static Citizen[] citizenList;

        public static void Initialize(ContentManager content)
        {
            citizenList = new Citizen[GlobalVars.MAX_CITIZENS];
            for (int citizenNumber = 0; citizenNumber < citizenList.Length; citizenNumber++)
            {
                citizenList[citizenNumber] = new Citizen(content);
            }
        }

        public static void Update()
        {
            for (int citizenNumber = 0; citizenNumber < citizenList.Length; citizenNumber++)
            {
                citizenList[citizenNumber].Update();
            }
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            for (int citizenNumber = 0; citizenNumber < citizenList.Length; citizenNumber++)
            {
                citizenList[citizenNumber].Draw(spriteBatch);
            }
        }
    }
}
