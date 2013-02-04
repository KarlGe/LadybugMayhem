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
        private Texture2D[] title = new Texture2D[8];
        private int[] speedX = new int[8];
        private int screenHeight;
        private int screenWidth;
        private int objDrawAmount;
        private int speedMultiplier = 100;
        public GameOverScreen(Game game, ContentManager content, int screenWidth, int screenHeight)
        {
            // TODO: Construct any child components here
            this.screenHeight = screenHeight;
            this.screenWidth = screenWidth;
            grassBlock = new DrawObject(game, content, "Grass Block", 0, new Vector2(0, screenHeight/2));
            dirtBlock = new DrawObject(game, content, "Dirt Block", 2, new Vector2(screenWidth - grassBlock.width * 2, screenHeight - (grassBlock.height*2)));
            for (int i = 0; i < title.Length; i++) title[i] = content.Load<Texture2D>("Dirt Block");
            coverScreen(grassBlock, screenHeight - grassBlock.height);
        }
        public void Update(GameTime gameTime)
        {
            for (int i = 0; i < title.Length; i++)
            {
                speedX[i] =10;
                speedMultiplier--;
            }

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            grassBlock.Draw(spriteBatch);
            dirtBlock.Draw(spriteBatch);
            for (int i = 0; i < title.Length; i++)spriteBatch.Draw(title[i], new Vector2(100*i, speedX[i]), Color.White);
            Console.Write(speedX[1]);
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
