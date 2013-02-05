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
        private static ContentManager _content;
        private static List<Citizen> _citizenList;
        private static Point _mousePointer;

        private static int _spawnTimer;
        private static int _populationCount;

        private static bool _alreadySavedACitizen;

        public static void Initialize(ContentManager content)
        {
            _content = content;
            _mousePointer = new Point(GlobalVars.MOUSE_STATE.X, GlobalVars.MOUSE_STATE.Y);
            _citizenList = new List<Citizen>();
            _populationCount = 0;
            _spawnTimer = 0;
        }

        public static void Update(GameTime gameTime, GameWindow window)
        {
            _spawnTimer += gameTime.ElapsedGameTime.Milliseconds;
            if (_spawnTimer >= 5000 && _populationCount < GlobalVars.MAX_CITIZENS)
            {
                Console.WriteLine(_populationCount);
                _citizenList.Add(new Citizen(_content, _populationCount));
                _populationCount++;
                _spawnTimer = 0;
            }
            _mousePointer.X = GlobalVars.MOUSE_STATE.X;
            _mousePointer.Y = GlobalVars.MOUSE_STATE.Y;
            _alreadySavedACitizen = false;
            //Denne loopen teller nedover, slik at den oppdaterer "siste" citizen først. Dersom man klikker to citizens som overlapper
            //hverandre skal bare en av dem "reddes" (sendes tilbake). Siden loopen teller nedover vil den "øverste" (/"sist innlastede")
            //citizen'en, utifra logikken, være den som reddes. Dette er mest naturlig.
            for (int citizenNumber = _citizenList.Count-1; citizenNumber >= 0; citizenNumber--)
            {
                //Om musen klikkes i denne framen.
                if (GlobalVars.MOUSE_STATE.LeftButton == ButtonState.Pressed &&
                GlobalVars.PREVIOUS_MOUSE_STATE.LeftButton == ButtonState.Released)
                {
                    //Passer på at bare "øverste" (/"sist innlastede") citizen sendes tilbake
                    if (_citizenList[citizenNumber].GetCitizenBox().Contains(_mousePointer) && !_alreadySavedACitizen)
                    {
                        _citizenList[citizenNumber].Saved(_citizenList);
                        _alreadySavedACitizen = true;
                    }
                }

                if (_citizenList[citizenNumber].GetCitizenBox().X > window.ClientBounds.Width)
                {
                }

                //Skal citizens fps være litt lavere?
                _citizenList[citizenNumber].Update(gameTime);
            }
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            for (int citizenNumber = 0; citizenNumber < _citizenList.Count; citizenNumber++)
            {
                _citizenList[citizenNumber].Draw(spriteBatch);
            }
        }
    }
}