using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


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

        private int screenHeight;
        private int screenWidth;

        private int objDrawAmount;
        private int numObjectsToDraw = 0;
        public GameOverScreen(Game game, ContentManager content, int screenWidth, int screenHeight)
        {
            // TODO: Construct any child components here
            this.screenHeight = screenHeight;
            this.screenWidth = screenWidth;
            grassBlock = new DrawObject(game, content, "Grass Block", 0, new Vector2(0, screenHeight / 2));
            coverScreen(grassBlock, screenHeight - grassBlock.height);
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
            if (!(gameOverText[gameOverText.Length].falling))
            {

            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            grassBlock.Draw(spriteBatch);
            for (int i = 0; i < gameOverText.Length; i++) gameOverText[i].Draw(spriteBatch);
        }

        private void coverScreen(DrawObject obj, int Y)
        {
            int drawAmount = (int)Math.Ceiling((double)screenWidth / (double)grassBlock.width);
            objDrawAmount = (int)Math.Ceiling((double)screenWidth / (double)grassBlock.width);
            obj.drawPlacement.X = (screenWidth - (obj.width * objDrawAmount)) / 2;
            obj.drawPlacement.Y = Y;
            obj.drawAmount = objDrawAmount;
        }
    }
}

