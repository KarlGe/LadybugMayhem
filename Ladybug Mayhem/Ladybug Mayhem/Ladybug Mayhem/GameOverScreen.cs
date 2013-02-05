using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Ladybug_Mayhem
{
    public class GameOverScreen
    {
        private DrawObject grassBlock;
        /* Setter opp en array med "fallende objekter", lager ogs� en array med navnene p� filene som skal brukes, 
         * til slutt lages en array som inneholder bredden p� alle disse bildene, dette er n�dvendig for � finne
         * den totale bredden p� bokstavene, med mellomrom som legges imellom (tallet etter + p� den 5. plassen)
         */
        private FallingObject[] gameOverText = new FallingObject[8];
        private String[] letterFileNames = new String[] { "G", "A", "M", "E", "O", "V", "E", "R"};
        private int[] letterWidth = new int[] { 0, 73, 77, 95, 54 + 54, 78, 78, 64, 64 };
        private int totalLetterWidth = 0;
        private int xPos = 0; //Settes til midten av skjermen, minus halvparten av bredden til bokstavene
        private int delay = 10; // Hvor mange frames som skal g� f�r neste bokstav begynner � falle
        private int currentDelay;
        private int numObjectsToDraw = 0;// Bestemmer hvilke bokstaver i arrayen som skal falle
        private bool fallingLetters = true;

        /* Replay og exit knapp med rektangler, mellomrom imellom dem, 
         * og til slutt en variabel som sier ifra om spilleren har valgt � spille p� nytt
         */
        private Texture2D replayButton;
        private Rectangle replayRectangle;
        private Texture2D exitButton;
        private Rectangle exitRectangle;
        private int space = 20;
        public bool replay { get; protected set; }
        
        private int screenHeight;
        private int screenWidth;
        Game game;
        ContentManager content;

        //Hvor mange 
        private int objDrawAmount;
        
        public GameOverScreen(Game game, ContentManager content, int screenWidth, int screenHeight)
        {
            this.screenHeight = screenHeight;
            this.screenWidth = screenWidth;
            this.game = game;
            this.content = content;
            initialize();
        }
        /// <summary>
        /// Henter ut replayButton og exitButton og setter rektangelet deres, henter ut grassblock og dekker skjermen med det
        /// Til slutt regnes den totale bredden p� bokstavene ut, for s� � plassere �n og �n bokstav ut ifra det
        /// </summary>
        public void initialize()
        {
            replay = false;
            replayButton = content.Load<Texture2D>(@"GameOverScreen\startOver");
            replayRectangle = new Rectangle(screenWidth / 2 - replayButton.Width - space, screenHeight / 2 - replayButton.Height / 2, replayButton.Width, replayButton.Height);

            exitButton = content.Load<Texture2D>(@"GameOverScreen\exit");
            exitRectangle = new Rectangle(screenWidth / 2 + space, screenHeight / 2 - exitButton.Height / 2, exitButton.Width, exitButton.Height);
            
            grassBlock = new DrawObject(game, content, "Grass Block", 0, new Vector2(0, screenHeight / 2));
            grassBlock = CoverScreen.CalculateCoverScreen(grassBlock, screenHeight - grassBlock.height, screenWidth, grassBlock.width);

            for (int i = 0; i < letterWidth.Length; i++) totalLetterWidth += letterWidth[i];
            xPos = (screenWidth / 2) - (totalLetterWidth / 2);
            for (int i = 0; i < gameOverText.Length; i++) gameOverText[i] = new FallingObject(game, content, @"GameOverScreen\GameOverLetters\" + letterFileNames[i], 1, new Vector2(xPos += letterWidth[i], -100), true, 10);
        }
        /// <summary>
        /// F�r bokstaver til � falle, med en delay fra starten for n�r de skal falle
        /// Hvis bokstavene treffer punktet som er markert slutter de � falle
        /// Hvis den siste bokstaven har sluttet � falle vises de to knappene
        /// Hvis replay knappen trykkes settes replay boolean til true, og spillet skal startes p� nytt
        /// </summary>
        public void Update(GameTime gameTime)
        {
            currentDelay--;
            if (currentDelay < 0 && numObjectsToDraw < gameOverText.Length)
            {
                numObjectsToDraw++;
                currentDelay = delay;
            }
            for (int i = 0; i < numObjectsToDraw; i++)
            {
                gameOverText[i].falling = true;
                if (gameOverText[i].currentYPos > screenHeight - grassBlock.height) gameOverText[i].falling = false;
                gameOverText[i].Update(gameTime);
            }
            if (!(gameOverText[gameOverText.Length-1].falling))
            {   
                fallingLetters = false;
                if (CheckMousePress.IsBeingPressed(replayRectangle)) replay = true;
                if (CheckMousePress.IsBeingPressed(exitRectangle)) game.Exit();
            }
        }
        /// <summary>
        /// Tegner de fallende bokstavene, og de to knappene hvis bokstavene har sluttet � falle
        /// </summary>
        public void Draw(SpriteBatch spriteBatch)
        {
            grassBlock.Draw(spriteBatch);
            for (int i = 0; i < gameOverText.Length; i++) gameOverText[i].Draw(spriteBatch);
            if (!fallingLetters)
            {
                spriteBatch.Draw(replayButton, replayRectangle , Color.White);
                spriteBatch.Draw(exitButton, exitRectangle, Color.White);
            }
            
        }
        /// <summary>
        /// Setter tilbake n�dvendige variabler for � kunne kj�re gameOverScreen p� nytt
        /// </summary>
        public void reset()
        {
            for (int i = 0; i < gameOverText.Length; i++) 
            {
                gameOverText[i].currentYPos = -100;
                gameOverText[i].falling = true;
            }
            numObjectsToDraw = 0;
            fallingLetters = true;
            replay = false;
        }
    }
}

