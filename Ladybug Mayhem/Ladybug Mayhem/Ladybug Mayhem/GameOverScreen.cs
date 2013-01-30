using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace Ladybug_Mayhem
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class GameOverScreen : Microsoft.Xna.Framework.GameComponent
    {
        private Texture2D groundTile;
        private Vector2 position;
        private DrawObject grassBlock;
        private int screenHeight;
        private int screenWidth;
        private int objDrawAmount;
        public GameOverScreen(Game game, ContentManager content, int screenWidth, int screenHeight)
            : base(game)
        {
            // TODO: Construct any child components here
            this.screenHeight = screenHeight;
            this.screenWidth = screenWidth;
            grassBlock = new DrawObject(game, content, "Grass Block", 0, new Vector2(0, screenHeight/2));
            coverScreen(grassBlock, screenHeight - grassBlock.height);
        }
        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here
            base.Initialize();
            
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
            // TODO: Add your update code here
            base.Update(gameTime);
            position.X += 1;
        }
        public void updatePosX()
        {
            position.X += 1;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            grassBlock.Draw(spriteBatch);
        }

        private void coverScreen(DrawObject obj, int Y)
        {
            int drawAmount = (int)Math.Ceiling((double)screenWidth / (double)grassBlock.width);
            objDrawAmount = (int)Math.Ceiling((double)screenWidth / (double)grassBlock.width);
            obj.drawPlacement.X = (screenWidth - (obj.width * objDrawAmount)) / 2;
            obj.drawPlacement.Y = screenHeight - obj.height;
            obj.drawAmount = objDrawAmount;
            Console.Write(screenWidth + " " + obj.width);
        }
    }
}
