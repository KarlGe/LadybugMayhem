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
    /// <summary>
    /// LosingControl er klassen som styrer det som har med innbyggere og hjerter å gjøre. (dvs. at den kontrollerer om spilleren taper)
    /// </summary>
    public class LosingControl
    {
        private static ContentManager _content;

        //Liste som inneholder info om hvordan hjertene skal tegnes
        private static List<DrawSprite> _drawHearts;
        //Liste som inneholder innbyggere
        private static List<Citizen> _citizenList;
        //Variabel som skal oppdateres og sjekkes mot GlobalVars.CITIZEN_RESPAWN_TIME
        private static int _minSpawnTime;
        //Tidtaker
        private static int _spawnTimer;
        //Holder telling på hvor mange innbyggere som har spawnet
        private static int _populationCount;
        /*Boolean som er sann i en Update-sekvens dersom en innbygger er blitt klikket. 
        Er til for at ikke flere innbyggere reddes i samme klikk*/
        private static bool _alreadySavedACitizen;

        /// <summary>
        /// Må kalles på når spillet initialiseres
        /// </summary>
        /// <param name="content">Spillets ContentManager-objekt</param>
        public static void Initialize(ContentManager content)
        {
            _content = content;
            _drawHearts = new List<DrawSprite>();
            _citizenList = new List<Citizen>();
            Reset(content);
        }

        /// <summary>
        /// Må kalles på i spillets Update-metode. Styrer antall innbyggere, hvor ofte de skal spawne, om de klikkes på o.l.
        /// Om en innbygger går ut av skjermen mister man et hjerte
        /// </summary>
        /// <param name="gameTime">Spillets GameTime-objekt</param>
        /// <param name="window">Spillets GameWindow-objekt</param>
        public static void Update(GameTime gameTime, GameWindow window)
        {
            //Tiden siden forrige spawnede innbygger
            _spawnTimer += gameTime.ElapsedGameTime.Milliseconds;
            /*Her legges _spawnTimer sammen med en viss sum som er basert på hvor mange marihøner man har drept. 
            En slags økende vanskelighetsgrad*/
            _minSpawnTime = _spawnTimer + GlobalVars.CITIZEN_RESPAWN_SPEEDUP[GlobalVars.bugs_killed];
            //Hvis variabelen over er større enn den forhåndsbestemte CITIZEN_RESPAWN_TIME og det har blitt spawnet færre enn MAX_CITIZENS
            if (_minSpawnTime >= GlobalVars.CITIZEN_RESPAWN_TIME && _populationCount < GlobalVars.MAX_CITIZENS)
            {
                _citizenList.Add(new Citizen(_content, _populationCount));
                _populationCount++;
                _spawnTimer = 0;
            }

            _alreadySavedACitizen = false;
            //Denne loopen teller nedover, slik at den oppdaterer "siste" citizen først. Dersom man klikker to citizens som overlapper
            //hverandre skal bare en av dem "reddes" (sendes tilbake). Siden loopen teller nedover vil den "øverste" (/"sist innlastede")
            //citizen'en, utifra logikken, være den som reddes. Dette er mest naturlig.
            for (int citizenNumber = _citizenList.Count-1; citizenNumber >= 0; citizenNumber--)
            {    
                //Kaller på innbyggerens egen update-metode
                _citizenList[citizenNumber].Update(gameTime);
                /*Sjekker om musen klikkes i denne framen og passer på at bare "øverste" (/"sist innlastede") citizen sendes tilbake
                (Citizens Saved-metod kalles)*/
                if (CheckMousePress.IsBeingPressed(_citizenList[citizenNumber].GetCitizenBox()) && !_alreadySavedACitizen)
                {
                    _citizenList[citizenNumber].Saved(_citizenList);
                    _alreadySavedACitizen = true;
                }
                //En citizen "dør" (går ut av skjermen). Citizen'en fjernes, et liv trekkes fra, et hjerte fjernes fra _drawHearts
                if (_citizenList[citizenNumber].GetCitizenBox().X > window.ClientBounds.Width)
                {
                    _citizenList.RemoveAt(citizenNumber);
                    GlobalVars.lives--;
                    _drawHearts.RemoveAt(_drawHearts.Count - 1);
                }
            }
        }

        /// <summary>
        /// Kaller på Citizens egne Draw-metoder. Tegner hjerter ved hjelp av DrawSprite-klassen.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public static void Draw(SpriteBatch spriteBatch)
        {
            //Tegnes for hver Citizen i _citizenList
            for (int citizenNumber = 0; citizenNumber < _citizenList.Count; citizenNumber++)
            {
                _citizenList[citizenNumber].Draw(spriteBatch);
            }
            //Tegnes for hvert liv man har
            for (int heartCounter = 0; heartCounter < GlobalVars.lives; heartCounter++)
            {
                _drawHearts[heartCounter].Draw(spriteBatch);
            }
        }


        /// <summary>
        /// Må kalles på dersom spillet skal startes på nytt
        /// </summary>
        /// <param name="content">Spillets Content-objekt</param>
        public static void Reset(ContentManager content)
        {
            //Fjerner alle Citizen-objekter. Legger så til en ny.
            _citizenList.Clear();
            _citizenList.Add(new Citizen(_content, 0));
            _populationCount = 1;
            //Fjerner alle DrawSprite-objekter som tegner hjerter. Legger så inn antallet hjerter som representerer fullt liv.
            _drawHearts.Clear();
            for (int heartCounter = 0; heartCounter < GlobalVars.MAX_LIVES; heartCounter++)
            {
                _drawHearts.Add(new DrawSprite(content, "heart",
                    new Rectangle(5 + ((GlobalVars.HEART_WIDTH_HEIGHT+12) * heartCounter),3, GlobalVars.HEART_WIDTH_HEIGHT, GlobalVars.HEART_WIDTH_HEIGHT),
                    GlobalVars.HEART_SPRITE_RECTANGLE, 1));
            }

            //Bestemmer om andre inbygger skal spawne raskere ved å legge en verdi til tidtakeren på forhånd
            _spawnTimer = GlobalVars.SECOND_CITIZEN_SPAWN_BONUS;

            //Setter liv til fullt
            GlobalVars.lives = GlobalVars.MAX_LIVES;
        }
    }
}