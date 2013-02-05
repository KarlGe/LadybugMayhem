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
        private static Point _mousePointer;

        private static bool _alreadySavedACitizen;

        public static void Initialize(ContentManager content)
        {
            _mousePointer = new Point(GlobalVars.MOUSE_STATE.X, GlobalVars.MOUSE_STATE.Y);
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
            _alreadySavedACitizen = false;
            //Denne loopen teller nedover, slik at den oppdaterer "siste" citizen først. Dersom man klikker to citizens som overlapper
            //hverandre skal bare en av dem "reddes" (sendes tilbake). Siden loopen teller nedover vil den "øverste" (/"sist innlastede")
            //citizen'en, utifra logikken, være den som reddes. Dette er mest naturlig.
            for (int citizenNumber = GlobalVars.MAX_CITIZENS - 1; citizenNumber >= 0; citizenNumber--)
            {
                if (GlobalVars.MOUSE_STATE.LeftButton == ButtonState.Pressed &&
                GlobalVars.PREVIOUS_MOUSE_STATE.LeftButton == ButtonState.Released)
                {
                    if (_citizenList[citizenNumber].GetCitizenBox().Contains(_mousePointer) && !_alreadySavedACitizen)
                    {
                        _citizenList[citizenNumber].Saved(_citizenList);
                        _alreadySavedACitizen = true;
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