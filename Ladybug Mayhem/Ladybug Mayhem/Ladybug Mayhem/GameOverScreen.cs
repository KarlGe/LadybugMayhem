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
        private Vector2 position;
        private DrawObject grassBlock;
        private DrawObject dirtBlock;
        private FallingObject[] title = new FallingObject[8];
        private int screenHeight;
        private int screenWidth;
        private int objDrawAmount;
        private int speedMultiplier = 100;
        private int numObjectsToDraw = 0;
        private int delay = 10;
        private int currentDelay;
        public GameOverScreen(Game game, ContentManager content, int screenWidth, int screenHeight)
        {
            // TODO: Construct any child components here
            this.screenHeight = screenHeight;
            this.screenWidth = screenWidth;
            grassBlock = new DrawObject(game, content, "Grass Block", 0, new Vector2(0, screenHeight / 2));
            dirtBlock = new DrawObject(game, content, "Dirt Block", 2, new Vector2(screenWidth - grassBlock.width * 2, screenHeight - (grassBlock.height * 2)));
            coverScreen(grassBlock, screenHeight - grassBlock.height);
            for (int i = 0; i < title.Length; i++) title[i] = new FallingObject(game, content, "Grass Block", 1, new Vector2(i * 100, 0), true, 10);
        }
        public void Update(GameTime gameTime)
        {
            currentDelay--;
            if (currentDelay < 0 && numObjectsToDraw < title.Length)
            {
                numObjectsToDraw++;
                currentDelay = delay;
            }
            for (int i = 0; i < numObjectsToDraw; i++)
            {
                title[i].falling = true;
                if (title[i].currentYPos > screenHeight - title[i].height) title[i].falling = false;
                title[i].Update(gameTime);
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            grassBlock.Draw(spriteBatch);
            dirtBlock.Draw(spriteBatch);
            for (int i = 0; i < title.Length; i++) title[i].Draw(spriteBatch);
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

