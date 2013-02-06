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

        private static Texture2D _heart;

        private static List<Citizen> _citizenList;

        private static int _spawnTimer;
        private static int _populationCount;
        private static int _lives;

        private static bool _alreadySavedACitizen;
        private static bool _gameOver;
        private static bool _gameOverMessage = false;

        public static void Initialize(ContentManager content)
        {
            _content = content;
            _heart = content.Load<Texture2D>("Heart");
            _citizenList = new List<Citizen>();
            _populationCount = 0;
            _spawnTimer = 0;
            _lives = 5;
            _gameOver = false;
        }

        public static void Update(GameTime gameTime, GameWindow window)
        {
            if (_lives == 0)
                _gameOver = true;

            if (!_gameOver)
            {
                _spawnTimer += gameTime.ElapsedGameTime.Milliseconds;
                if (_spawnTimer >= 5000 && _populationCount < GlobalVars.MAX_CITIZENS)
                {
                    _citizenList.Add(new Citizen(_content));
                    _populationCount++;
                    _spawnTimer = 0;
                }
                _alreadySavedACitizen = false;
                //Denne loopen teller nedover, slik at den oppdaterer "siste" citizen først. Dersom man klikker to citizens som overlapper
                //hverandre skal bare en av dem "reddes" (sendes tilbake). Siden loopen teller nedover vil den "øverste" (/"sist innlastede")
                //citizen'en, utifra logikken, være den som reddes. Dette er mest naturlig.

                for (int citizenNumber = _citizenList.Count - 1; citizenNumber >= 0; citizenNumber--)
                {
                    //Skal citizens fps være litt lavere?
                    _citizenList[citizenNumber].Update(gameTime);
                    //Sjekker om musen klikkes i denne framen og passer på at bare "øverste" (/"sist innlastede") citizen sendes tilbake
                    if (CheckMousePress.IsBeingPressed(_citizenList[citizenNumber].GetCitizenBox()) && !_alreadySavedACitizen)
                    {
                        _citizenList[citizenNumber].Saved(_citizenList);
                        _alreadySavedACitizen = true;
                    }
                    //En citizen "dør" (går ut av skjermen)
                    if (_citizenList[citizenNumber].GetCitizenBox().X > window.ClientBounds.Width)
                    {
                        _citizenList.RemoveAt(citizenNumber);
                        _lives--;
                    }
                }
            }
            else
                if (!_gameOverMessage)
                {
                    Console.WriteLine("Du tapte!");
                    _gameOverMessage = true;
                }
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            for (int citizenNumber = 0; citizenNumber < _citizenList.Count; citizenNumber++)
            {
                _citizenList[citizenNumber].Draw(spriteBatch);
            }
            for (int heartCounter = 0; heartCounter < _lives; heartCounter++)
            {
                spriteBatch.Draw(_heart, new Rectangle(
                    5 + ((GlobalVars.HEART_WIDTH_HEIGHT+12) * heartCounter), 3, GlobalVars.HEART_WIDTH_HEIGHT, GlobalVars.HEART_WIDTH_HEIGHT),
                    GlobalVars.HEART_SPRITE_RECTANGLE, Color.White);
            }
        }
    }
}