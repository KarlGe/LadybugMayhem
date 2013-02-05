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
        private FallingObject[] gameOverText = new FallingObject[8];
        private String[] letterFileNames = new String[] { "G", "A", "M", "E", "O", "V", "E", "R"};
        private int[] letterWidth = new int[] { 0, 73, 77, 95, 54 + 54, 78, 78, 64, 64 };
        private int totalLetterWidth = 0;
        private int xPos = 0;
        private int delay = 10;
        private int currentDelay;

        private Texture2D replayButton;
        private Rectangle replayRectangle;
        private Texture2D exitButton;
        private Rectangle exitRectangle;
        private int space = 20;
        private bool fallingLetters = true;

        private int screenHeight;
        private int screenWidth;
        Game game;

        private int objDrawAmount;
        private int numObjectsToDraw = 0;
        public GameOverScreen(Game game, ContentManager content, int screenWidth, int screenHeight)
        {
            this.screenHeight = screenHeight;
            this.screenWidth = screenWidth;
            this.game = game;
            initialize(content, game);
        }
        public void initialize(ContentManager content, Game game)
        {
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
                if (CheckMousePress.IsBeingPressed(replayRectangle)) Console.Write("Hey");
                if (CheckMousePress.IsBeingPressed(exitRectangle)) game.Exit();
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            grassBlock.Draw(spriteBatch);
            if (!fallingLetters)
            {
                spriteBatch.Draw(replayButton, replayRectangle , Color.White);
                spriteBatch.Draw(exitButton, exitRectangle, Color.White);
            }
            for (int i = 0; i < gameOverText.Length; i++) gameOverText[i].Draw(spriteBatch);
        }
    }
}

