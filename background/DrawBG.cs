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


namespace Innlevering1_bakgrunn
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class DrawBG : Microsoft.Xna.Framework.GameComponent
    {
        private DrawObject brownBlock;
        private DrawObject dirtBlock;
        private DrawObject roofEast;
        private DrawObject roofNorthEast;
        private DrawObject roofNorthWest;
        private DrawObject roofNorth;
        private DrawObject roofSouthEast;
        private DrawObject roofSouthWest;
        private DrawObject roofSouth;
        private DrawObject roofWest;
        private DrawObject stoneBlock;
        private DrawObject windowTall;
        private SpriteBatch spriteBatch;

        public DrawBG(Game game, ContentManager content, SpriteBatch spriteBatch)
            : base(game)
        {
            this.spriteBatch = spriteBatch;
            // TODO: Construct any child components here
            brownBlock = new DrawObject(game, content, "Brown Block", 1, new Vector2(10, 10));
            dirtBlock = new DrawObject(game, content, "Dirt Block", 5, new Vector2(0, roofWest.height));
            roofEast = new DrawObject(game, content, "Roof East", 1, new Vector2(X, Y));
            roofNorthEast = new DrawObject(game, content, "Roof North East", 4, new Vector2(X, Y));
            roofNorthWest = new DrawObject(game, content, "Roof North West", 1, new Vector2(X, Y));

        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here

            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here

            base.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch){
            brownBlock.Draw(spriteBatch);
            dirtBlock.Draw(spriteBatch);
            roofEast.Draw(spriteBatch);
            roofNorthEast.Draw(spriteBatch);
            roofNorthWest.Draw(spriteBatch);
 
        }
    }
}
