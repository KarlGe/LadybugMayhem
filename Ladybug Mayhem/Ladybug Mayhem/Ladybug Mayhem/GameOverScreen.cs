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
        private Texture2D groundTile;
        private Vector2 position;
        private DrawObject grassBlock;
        private DrawObject dirtBlock;
        private int screenHeight;
        private int screenWidth;
        private int objDrawAmount;
        public GameOverScreen(Game game, ContentManager content, int screenWidth, int screenHeight)
        {
            // TODO: Construct any child components here
            this.screenHeight = screenHeight;
            this.screenWidth = screenWidth;
            grassBlock = new DrawObject(game, content, "Grass Block", 0, new Vector2(0, screenHeight/2));
            dirtBlock = new DrawObject(game, content, "Dirt Block", 2, new Vector2(screenWidth - grassBlock.width * 2, screenHeight - (grassBlock.height*2)));
            coverScreen(grassBlock, screenHeight - grassBlock.height);
        }
        public override void Initialize()
        {   
            position = new Vector2(0, 0);
        }
        protected void LoadContent()
        {
        }
        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            position.X += 1;
        }
        public void updatePosX()
        {
            position.X += 1;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            grassBlock.Draw(spriteBatch);
            dirtBlock.Draw(spriteBatch);
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
