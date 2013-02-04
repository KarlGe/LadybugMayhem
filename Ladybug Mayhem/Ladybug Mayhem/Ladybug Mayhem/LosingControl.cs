using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//ikke default
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Ladybug_Mayhem
{
    public class LosingControl
    {
        private static Citizen[] _citizenList;
        private static Rectangle _mousePointer;

        public static void Initialize(ContentManager content)
        {
            _mousePointer = new Rectangle(GlobalVars.MOUSE_STATE.X, GlobalVars.MOUSE_STATE.Y, 1, 1);
            _citizenList = new Citizen[GlobalVars.MAX_CITIZENS];
            for (int citizenNumber = 0; citizenNumber < GlobalVars.MAX_CITIZENS; citizenNumber++)
            {
                _citizenList[citizenNumber] = new Citizen(content, citizenNumber);
            }
        }

        public static void Update(GameTime gameTime)
        {
            _mousePointer.X = GlobalVars.MOUSE_STATE.X;
            _mousePointer.Y = GlobalVars.MOUSE_STATE.Y;
            for (int citizenNumber = 0; citizenNumber < GlobalVars.MAX_CITIZENS; citizenNumber++)
            {
                if (GlobalVars.MOUSE_STATE.LeftButton == ButtonState.Pressed &&
                GlobalVars.PREVIOUS_MOUSE_STATE.LeftButton == ButtonState.Released)
                {
                    if (_mousePointer.Intersects(_citizenList[citizenNumber].getRectangle()))
                    {
                        Console.WriteLine("HEEEEY");
                    }
                }
                _citizenList[citizenNumber].Update();
            }
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            for (int citizenNumber = 0; citizenNumber < GlobalVars.MAX_CITIZENS; citizenNumber++)
            {
                _citizenList[citizenNumber].Draw(spriteBatch);
            }
        }
    }
}
